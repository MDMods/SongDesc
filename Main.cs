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
                SetGameObject("ChartName", ChartName, 40, new Vector3(316.8f, 504f, 0f));
                SetGameObject("Author + Level", MusicAuthor + "  -  Lvl." + ChartLevel, 30, new Vector3(302.4f, 453.6f, 0f));
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
            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);
            canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvas.GetComponent<CanvasScaler>().screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        }

        private static GameObject SetGameObject(string name, string text, int size, Vector3 position)
        {
            GameObject canvas = GameObject.Find("Song Description Canvas");
            GameObject gameobject = new GameObject(name);
            gameobject.transform.SetParent(canvas.transform);
            Text gameobject_text = gameobject.AddComponent<Text>();
            gameobject_text.text = text;
            gameobject_text.alignment = TextAnchor.UpperRight;
            gameobject_text.font = font;
            gameobject_text.fontSize = size;
            gameobject_text.color = Color.white;
            gameobject_text.transform.localPosition = position;
            RectTransform rectTransform = gameobject_text.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(960, 60);
            rectTransform.localScale = new Vector3(1, 1, 1);
            return gameobject;
        }
    }
}