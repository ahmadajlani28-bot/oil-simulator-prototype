using UnityEngine;

namespace OilSimulator
{
    public class OilSite : MonoBehaviour
    {
        public string SiteName = "North Creek Lease";
        public float MinYield = 20f;
        public float MaxYield = 50f;
        public float StoredOil = 0f;
        public float LeaseCost = 1800f;

        public void Initialize(string siteName, float minYield, float maxYield, float leaseCost)
        {
            SiteName = siteName;
            MinYield = minYield;
            MaxYield = maxYield;
            LeaseCost = leaseCost;
        }

        public float EstimateProduction()
        {
            return Random.Range(MinYield, MaxYield);
        }

        public float Produce()
        {
            float produced = EstimateProduction();
            StoredOil += produced;
            Debug.Log($"Site {SiteName} produced {produced:0.0} oil.");
            return produced;
        }

        public float Sell(float amount)
        {
            float saleAmount = Mathf.Min(amount, StoredOil);
            StoredOil -= saleAmount;
            float payout = saleAmount * GameData.CurrentMarketPrice;
            GameData.Cash += payout;
            Debug.Log($"Sold {saleAmount:0.0} oil for ${payout:0.0}.");
            return payout;
        }
    }
}
