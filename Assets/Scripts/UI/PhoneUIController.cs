using UnityEngine;
using UnityEngine.UI;

namespace OilSimulator
{
    public class PhoneUIController : MonoBehaviour
    {
        public Text cashText;
        public Text marketText;
        public Text jobText;
        public Text siteText;
        public Text weatherText;

        private JobManager jobManager;
        private MarketSystem marketSystem;
        private OilSite activeSite;

        private void Start()
        {
            jobManager = FindObjectOfType<JobManager>();
            marketSystem = FindObjectOfType<MarketSystem>();
            var siteObjects = FindObjectsOfType<OilSite>();
            if (siteObjects != null && siteObjects.Length > 0)
            {
                activeSite = siteObjects[0];
            }
        }

        private void Update()
        {
            if (cashText != null)
            {
                cashText.text = $"Cash: ${GameData.Cash:0.0}";
            }

            if (marketText != null && marketSystem != null)
            {
                marketText.text = $"Market: ${marketSystem.CurrentPrice:0.0}/bbl\n{marketSystem.CurrentEvent}";
            }

            if (jobText != null && jobManager != null)
            {
                var job = jobManager.GetCurrentJob(0);
                if (job != null)
                {
                    jobText.text = $"Job: {job.Title}\nPayout: ${job.Payout:0.0}\nRoute: {job.DistanceKm} km";
                }
            }

            if (siteText != null && activeSite != null)
            {
                siteText.text = $"Site: {activeSite.SiteName}\nInventory: {activeSite.StoredOil:0.0} bbl";
            }

            if (weatherText != null)
            {
                weatherText.text = $"Region: {GameData.CurrentRegion}\nWeather: {GameData.Weather}";
            }
        }
    }
}
