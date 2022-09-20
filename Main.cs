using Assets.Scripts.PeroTools.Commons;
using FormulaBase;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace SongDesc
{
    public class Main : MelonMod
    {
        private static bool Set;
        internal static string ChartName;
        internal static string ChartLevel;
        internal static string MusicAuthor;
        private static Font font { get; set; }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "GameMain")
            {
                var asset = Addressables.LoadAssetAsync<Font>("Normal");
                font = asset.WaitForCompletion();
            }
            else
            {
                Set = false;
                if (font != null)
                {
                    Addressables.Release(font);
                }
            }
        }

        public override void OnUpdate()
        {
            if (Singleton<StageBattleComponent>.instance.isInGame && !Set)
            {
                SetCanvas();
                SetGameObject("ChartName", ChartName, 40, new Vector3(2.2f, 3.5f, 90f));
                SetGameObject("Author + Level", MusicAuthor + "  " + ChartLevel, 30, new Vector3(2.1f, 3.15f, 90f));
                Set = true;
            }
        }

        private static void SetCanvas()
        {
            GameObject canvas = new GameObject();
            canvas.name = "Song Description Canvas";
            canvas.AddComponent<Canvas>();
            canvas.AddComponent<CanvasScaler>();
            canvas.AddComponent<GraphicRaycaster>();
            canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            canvas.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera_2D").GetComponent<Camera>();
            canvas.GetComponent<Canvas>().sortingOrder = 0;
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
            canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
        }

        private static GameObject SetGameObject(string name, string text, int size, Vector3 position)
        {
            GameObject canvas = GameObject.Find("Song Description Canvas");
            GameObject gameobject = new GameObject(name);
            gameobject.transform.SetParent(canvas.transform);
            gameobject.transform.position = position;
            Text gameobject_text = gameobject.AddComponent<Text>();
            gameobject_text.text = text;
            gameobject_text.alignment = TextAnchor.UpperRight;
            gameobject_text.font = font;
            gameobject_text.color = Color.white;
            gameobject_text.fontSize = size * Screen.height / 1080;
            gameobject_text.transform.position = position;
            RectTransform rectTransform = gameobject_text.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(Screen.width * 1 / 2, 60);
            rectTransform.localScale = new Vector3(1, 1, 1);
            return gameobject;
        }
    }
}