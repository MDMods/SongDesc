using MelonLoader;
using UnityEngine;
using static MuseDashMirror.BattleComponent;
using static MuseDashMirror.UICreate.CanvasCreate;
using static MuseDashMirror.UICreate.TextGameObjectCreate;

namespace SongDesc
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            GameStartEvent += CreateText;
        }

        private void CreateText()
        {
            CreateCanvas("Song Description Canvas", "Camera_2D");
            CreateTextGameObject("Song Description Canvas", "ChartName", ChartName, TextAnchor.UpperRight, true, new Vector3(316.8f, 504f, 0f), new Vector2(960, 60), 40);
            CreateTextGameObject("Song Description Canvas", "Author + Level", MusicAuthor + "  -  Lvl." + ChartLevel, TextAnchor.UpperRight, true, new Vector3(302.4f, 453.6f, 0f), new Vector2(960, 60), 30);
        }
    }
}