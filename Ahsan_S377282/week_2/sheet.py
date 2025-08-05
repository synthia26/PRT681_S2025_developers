import pandas as pd
import json

# --- Config ---
INPUT_XLSX  = "NA_PPN_with_postcode_coords1.xlsx"
SHEET       = "2024-25 survey data"
OUTPUT_JSON = "survey_grouped_with_area.json"

# Initialize 'grouped' dictionary outside the try block
# This ensures it's always defined, even if an error occurs during processing.
grouped = {}

try:
    # 1) Read raw sheet (no header) to pull area & nematode names
    # This 'raw' DataFrame is used to get specific rows for area and nematode names,
    # independent of the main DataFrame's header setting.
    raw = pd.read_excel(INPUT_XLSX, sheet_name=SHEET, header=None)

    # If row 0 contains the main headers, and area names are in the row *after* that (row 1, index 1),
    # then adjust the index here. Original comment said "second row = area labels",
    # which would be index 1 if row 0 is the header.
    area_names     = raw.iloc[0,  8:24].tolist()  # Now correctly targets row 1 (second row) for area labels
    nematode_names = raw.iloc[2,  8:24].tolist()  # Still targets row 2 (third row) for nematode names

    # 2) Load main DataFrame using row 0 (index 0) as header
    # This is crucial if 'matched_lat' and 'matched_lon' are in row 0.
    df = pd.read_excel(INPUT_XLSX, sheet_name=SHEET, header=0) # Changed header from 1 to 0

    # --- IMPORTANT DEBUG STEP ---
    # Print all column names to help identify the correct 'matched_lat' and 'matched_lon'
    print("Columns found in the DataFrame after loading:")
    print(df.columns.tolist())
    print("-" * 30)

    # 3) Use only your postcode-matched coords
    # Check if 'matched_lat' and 'matched_lon' columns exist before trying to use them
    if "matched_lat" in df.columns and "matched_lon" in df.columns:
        df["lat"] = df["matched_lat"]
        df["lng"] = df["matched_lon"]
    else:
        print("Error: 'matched_lat' or 'matched_lon' column not found.")
        print("Please check the column names printed above and adjust your script accordingly.")
        exit() # Exit the script if the crucial columns are missing

    # 4) Metadata columns to carry through
    meta_cols = [
        "Sample ID","Sampling State","Sampling Region",
        "Site Description","Plant Associated",
        "Collected by","Material","lat","lng"
    ]

    # 5) Build grouped dict, dropping zero counts
    # Start the loop from DataFrame index 3, which corresponds to row 4 in Excel
    for _, row in df.iloc[3:].iterrows(): # Modified this line
        # Ensure all meta_cols exist in the DataFrame before accessing
        current_row_meta = {}
        for c in meta_cols:
            if c in row:
                current_row_meta[c] = row[c]
            else:
                print(f"Warning: Metadata column '{c}' not found in row. Skipping this column for this record.")
                current_row_meta[c] = None # Assign None or handle as appropriate

        base = current_row_meta

        for idx in range(8, 24):
            # Check if the column index exists before accessing
            if idx < len(row):
                count = row.iloc[idx]
            else:
                print(f"Warning: Column index {idx} out of bounds for row. Skipping.")
                continue

            if pd.isna(count) or count == 0:
                continue

            # Ensure area_names and nematode_names have enough elements
            if (idx - 8) < len(area_names) and (idx - 8) < len(nematode_names):
                area = area_names[idx - 8]
                nem  = nematode_names[idx - 8]
            else:
                print(f"Warning: Index for area_names or nematode_names out of bounds for idx {idx}. Skipping.")
                continue

            rec = dict(base)
            rec.update({
                "common_nematode_name":          area,
                "nematode":      nem,
                "sample_size":   float(count)
            })
            grouped.setdefault(nem, []).append(rec)

    # 6) Write JSON
    with open(OUTPUT_JSON, "w", encoding="utf-8") as f:
        json.dump(grouped, f, indent=2, ensure_ascii=False)

    total = sum(len(v) for v in grouped.values())
    print(f"Wrote {total} records across {len(grouped)} nematode groups to '{OUTPUT_JSON}'.")

except FileNotFoundError:
    print(f"Error: The file '{INPUT_XLSX}' was not found. Please ensure it's in the correct directory.")
except KeyError as e:
    print(f"A column error occurred: {e}. Please check your Excel file's column names and the 'header' parameter.")
except Exception as e:
    print(f"An unexpected error occurred: {e}")