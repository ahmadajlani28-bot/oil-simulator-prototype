using UnityEngine;

namespace OilSimulator
{
    public class MarketSystem : MonoBehaviour
    {
        public float BasePrice = 48f;
        public float Volatility = 4f;
        public string CurrentEvent = "Local demand is steady.";

        private float currentPrice;

        public float CurrentPrice
        {
            get { return currentPrice; }
            private set { currentPrice = Mathf.Max(20f, value); }
        }

        private void Awake()
        {
            CurrentPrice = BasePrice;
            GameData.CurrentMarketPrice = CurrentPrice;
        }

        public void UpdateMarket()
        {
            float swing = Random.Range(-Volatility, Volatility);
            CurrentPrice = BasePrice + swing;
            GameData.CurrentMarketPrice = CurrentPrice;
            CurrentEvent = swing >= 0f ? "Buyer demand rose this week." : "A refinery slowdown lowered the market.";
        }
    }
}
