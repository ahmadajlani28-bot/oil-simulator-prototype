using UnityEngine;

namespace OilSimulator
{
    public class BusinessManager : MonoBehaviour
    {
        public void AddSite(OilSite site)
        {
            if (site == null)
            {
                return;
            }

            GameData.Sites.Add(site);
        }

        public void PurchaseLease(OilSite site)
        {
            if (site == null)
            {
                return;
            }

            if (GameData.Cash >= site.LeaseCost)
            {
                GameData.Cash -= site.LeaseCost;
                AddSite(site);
                Debug.Log($"Purchased lease for {site.SiteName}.");
            }
            else
            {
                Debug.Log("Not enough cash to lease the site.");
            }
        }
    }
}
