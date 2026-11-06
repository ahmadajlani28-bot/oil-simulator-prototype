using UnityEngine;
using UnityEngine.UI;

namespace OilSimulator
{
    public class GameBootstrap : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialize()
        {
            if (FindObjectOfType<GameBootstrap>() != null)
            {
                return;
            }

            var bootstrap = new GameObject("GameBootstrap");
            bootstrap.AddComponent<GameBootstrap>();
        }

        private void Awake()
        {
            CreateWorld();
        }

        private void CreateWorld()
        {
            if (FindObjectOfType<TruckController>() != null)
            {
                return;
            }

            GameObject truck = GameObject.CreatePrimitive(PrimitiveType.Cube);
            truck.name = "Truck";
            truck.transform.position = Vector3.zero;
            truck.transform.localScale = new Vector3(2f, 1f, 4f);
            truck.AddComponent<TruckController>();

            var cameraGO = new GameObject("Main Camera");
            cameraGO.tag = "MainCamera";
            Camera mainCam = cameraGO.AddComponent<Camera>();
            mainCam.clearFlags = CameraClearFlags.SolidColor;
            mainCam.backgroundColor = new Color(0.14f, 0.17f, 0.22f);
            mainCam.transform.position = new Vector3(0f, 7f, -10f);
            mainCam.transform.rotation = Quaternion.Euler(18f, 0f, 0f);

            GameObject siteGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            siteGO.name = "StarterSite";
            siteGO.transform.position = new Vector3(25f, 0f, 10f);
            siteGO.transform.localScale = new Vector3(3f, 0.5f, 3f);
            OilSite site = siteGO.AddComponent<OilSite>();
            site.Initialize("North Creek Lease", 20f, 45f, 1800f);
            site.Produce();

            GameObject marketGO = new GameObject("MarketSystem");
            MarketSystem market = marketGO.AddComponent<MarketSystem>();
            market.UpdateMarket();

            GameObject jobGO = new GameObject("JobManager");
            jobGO.AddComponent<JobManager>();

            GameObject businessGO = new GameObject("BusinessManager");
            businessGO.AddComponent<BusinessManager>();
            businessGO.GetComponent<BusinessManager>().AddSite(site);

            CreatePhoneUI();
            Debug.Log("Oil Simulator bootstrap complete.");
        }

        private void CreatePhoneUI()
        {
            GameObject canvasGO = new GameObject("PhoneCanvas");
            Canvas canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);
            canvasGO.AddComponent<GraphicRaycaster>();

            GameObject panel = new GameObject("PhonePanel");
            panel.transform.SetParent(canvasGO.transform, false);
            Image panelImage = panel.AddComponent<Image>();
            panelImage.color = new Color(0.08f, 0.09f, 0.12f, 0.9f);
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(0.02f, 0.05f);
            panelRect.anchorMax = new Vector2(0.38f, 0.95f);
            panelRect.offsetMin = Vector2.zero;
            panelRect.offsetMax = Vector2.zero;

            CreateTextElement(panel.transform, "CashText", new Vector2(0.02f, 0.86f), new Vector2(0.96f, 0.92f), "Cash: $0");
            CreateTextElement(panel.transform, "MarketText", new Vector2(0.02f, 0.68f), new Vector2(0.96f, 0.82f), "Market: $0/bbl");
            CreateTextElement(panel.transform, "JobText", new Vector2(0.02f, 0.42f), new Vector2(0.96f, 0.64f), "Job: ...");
            CreateTextElement(panel.transform, "SiteText", new Vector2(0.02f, 0.20f), new Vector2(0.96f, 0.38f), "Site: ...");
            CreateTextElement(panel.transform, "WeatherText", new Vector2(0.02f, 0.02f), new Vector2(0.96f, 0.18f), "Region: ...");

            PhoneUIController ui = canvasGO.AddComponent<PhoneUIController>();
            ui.cashText = GameObject.Find("CashText").GetComponent<Text>();
            ui.marketText = GameObject.Find("MarketText").GetComponent<Text>();
            ui.jobText = GameObject.Find("JobText").GetComponent<Text>();
            ui.siteText = GameObject.Find("SiteText").GetComponent<Text>();
            ui.weatherText = GameObject.Find("WeatherText").GetComponent<Text>();
        }

        private void CreateTextElement(Transform parent, string name, Vector2 anchorMin, Vector2 anchorMax, string defaultText)
        {
            GameObject go = new GameObject(name);
            go.transform.SetParent(parent, false);
            go.AddComponent<Text>();
            var text = go.GetComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.fontSize = 24;
            text.color = Color.white;
            text.alignment = TextAnchor.UpperLeft;
            text.text = defaultText;

            RectTransform rect = go.GetComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;
        }
    }
}
