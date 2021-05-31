﻿using System;
using Dalamud.Data;
using Lumina.Excel.GeneratedSheets;

namespace RoleplayersToolbox.Tools.Housing {
    internal enum HousingArea {
        Mist = 339,
        LavenderBeds = 340,
        Goblet = 341,
        Shirogane = 641,
    }

    internal static class HousingAreaExtensions {
        public static string Name(this HousingArea area) => area switch {
            HousingArea.Mist => "Mist",
            HousingArea.LavenderBeds => "Lavender Beds",
            HousingArea.Goblet => "Goblet",
            HousingArea.Shirogane => "Shirogane",
            _ => throw new ArgumentOutOfRangeException(nameof(area), area, null),
        };

        public static ushort CityStateTerritoryType(this HousingArea area) => area switch {
            HousingArea.Mist => 129,
            HousingArea.LavenderBeds => 132,
            HousingArea.Goblet => 130,
            HousingArea.Shirogane => 628,
            _ => throw new ArgumentOutOfRangeException(nameof(area), area, null),
        };

        public static TerritoryType CityState(this HousingArea area, DataManager data) {
            return data.GetExcelSheet<TerritoryType>().GetRow(area.CityStateTerritoryType());
        }
    }
}