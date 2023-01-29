using MelonLoader;
using UnityEngine;
using static MuseDashMirror.BattleComponent;
using static MuseDashMirror.UICreate;

namespace SongDesc
{
    public class Main : MelonMod
    {
        private bool Set;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName != "GameMain")
            {
                Set = false;
                LoadFonts();
            }
        }

        public override void OnUpdate()
        {
            if (IsInGame && !Set)
            {
                CreateCanvas("Song Description Canvas", "Camera_2D", new Vector2(1920, 1080));
                CreateTextGameObject("Song Description Canvas", "ChartName", ChartName, TextAnchor.UpperRight, true, new Vector3(316.8f, 504f, 0f), new Vector2(960, 60), 40);
                CreateTextGameObject("Song Description Canvas", "Author + Level", MusicAuthor + "  -  Lvl." + ChartLevel, TextAnchor.UpperRight, true, new Vector3(302.4f, 453.6f, 0f), new Vector2(960, 60), 30);
                UnloadFonts();
                Set = true;
            }
        }
    }
}