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
            Main.ChartName = VariableUtils.GetResult<string>(Singleton<DataManager>.instance["Account"]["SelectedMusicName"]);
            Main.ChartLevel = VariableUtils.GetResult<string>(Singleton<DataManager>.instance["Account"]["SelectedMusicLevel"]);
            Main.MusicAuthor = selectedMusic.author;
            MelonLogger.Msg(Main.MusicAuthor);
            if (__result != null)
            {
                if (__result.EndsWith("_map4"))
                {
                    Main.ChartLevel = selectedMusic.difficulty4;
                }
                if (__result.EndsWith("_map5"))
                {
                    Main.ChartLevel = selectedMusic.difficulty5;
                }
            }
        }
    }
}