using System;
using UnityEngine;

namespace OilSimulator
{
    [Serializable]
    public class JobDefinition
    {
        public string Title;
        public string Description;
        public float Payout;
        public float DistanceKm;
        public float EstimatedDurationMinutes;
        public float FuelCost;
        public bool IsOilContract;

        public JobDefinition(string title, string description, float payout, float distanceKm, float estimatedDurationMinutes, float fuelCost, bool isOilContract = false)
        {
            Title = title;
            Description = description;
            Payout = payout;
            DistanceKm = distanceKm;
            EstimatedDurationMinutes = estimatedDurationMinutes;
            FuelCost = fuelCost;
            IsOilContract = isOilContract;
        }
    }
}
