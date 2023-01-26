using Assets.Scripts.Common;
using Assets.Scripts.Database;
using Assets.Scripts.PeroTools.Commons;
using Assets.Scripts.PeroTools.Nice.Datas;
using Assets.Scripts.PeroTools.Nice.Interface;
using HarmonyLib;
using MelonLoader;
using System;

namespace SongDesc
{
    [HarmonyPatch(typeof(SpecialSongManager), "HideBmsCheck")]
    public class HideBmsCheckPatch
    {
        private static void Postfix(MusicInfo selectedMusic, ref int selectedDifficulty, string __result)
        {
            Main.MusicAuthor = selectedMusic.author;
            switch (selectedDifficulty)
            {
                case 1:
                    Main.ChartLevel = selectedMusic.difficulty1;
                    break;

                case 2:
                    Main.ChartLevel = selectedMusic.difficulty2;
                    break;

                case 3:
                    Main.ChartLevel = selectedMusic.difficulty3;
                    break;

                case 4:
                    Main.ChartLevel = selectedMusic.difficulty4;
                    break;

                case 5:
                    Main.ChartLevel = selectedMusic.difficulty5;
                    break;
            }
        }
    }

    [HarmonyPatch(typeof(MusicInfo), "GetLocal")]
    internal class GetLocalPatch
    {
        private static void Postfix(LocalALBUMInfo __result)
        {
            Main.ChartName = __result.name;
        }
    }
}