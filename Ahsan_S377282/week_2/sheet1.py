import pandas as pd
import json
import re

# File paths
INPUT_XLSX = "NA_PPN_with_postcode_coords1.xlsx"
SHEET_NAME = "NA PPN review data"
OUTPUT_JSON = "review_grouped.json"

# 1) Load the sheet
df = pd.read_excel(INPUT_XLSX, sheet_name=SHEET_NAME)

# 2) Determine final lat/lon (use matched if available, else original)
if "matched_lat" in df.columns and "matched_lon" in df.columns:
    df["lat_final"] = df["matched_lat"].fillna(-df["Latitude (°S)"])
    df["lon_final"] = df["matched_lon"].fillna(df["Longitude (°E)"])
else:
    df["lat_final"] = -df["Latitude (°S)"]
    df["lon_final"] = df["Longitude (°E)"]

# 3) Group by genus (first word), treat “sp.”/“spp.” as Unassigned
grouped = {}
for _, row in df.iterrows():
    taxa = str(row.get("Nematode Taxa", "")).strip()
    if not taxa:
        continue

    parts = taxa.split()
    if len(parts) >= 2 and parts[1].lower() not in ("sp.", "spp."):
        genus, species = parts[0], parts[1]
    else:
        genus, species = "Unassigned", None

    rec = {
        "lat":    row["lat_final"],
        "lng":    row["lon_final"],
        "region": row.get("Region"),
        "state":  row.get("State"),
        "plant":  row.get("Plants Associated"),
        "reference": row.get("Reference"),
        "full_name": taxa,
        "species":   species
    }

    grouped.setdefault(genus, []).append(rec)

# 4) Write out JSON
with open(OUTPUT_JSON, "w", encoding="utf-8") as f:
    json.dump(grouped, f, indent=2, ensure_ascii=False)

print(f"Wrote {sum(len(v) for v in grouped.values())} records across {len(grouped)} groups to '{OUTPUT_JSON}'.")
