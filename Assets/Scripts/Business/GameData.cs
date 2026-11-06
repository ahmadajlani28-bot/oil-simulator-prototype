using UnityEngine;
using System.Collections.Generic;

namespace OilSimulator
{
    public static class GameData
    {
        public static float Cash = 1200f;
        public static float FuelCostPerUnit = 0.75f;
        public static float CurrentMarketPrice = 48f;
        public static string CurrentRegion = "Coastal Ridge";
        public static string Weather = "Clear";
        public static List<JobDefinition> Jobs = new List<JobDefinition>();
        public static List<OilSite> Sites = new List<OilSite>();
        public static int PlayerLevel = 1;
    }
}
