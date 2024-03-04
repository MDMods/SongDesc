using MelonLoader;
using MuseDashMirror.Attributes.EventAttributes.PatchEvents;
using MuseDashMirror.EventArguments;
using MuseDashMirror.Models;
using UnityEngine;
using static MuseDashMirror.UIComponents.CanvasUtils;
using static MuseDashMirror.UIComponents.TextGameObjectUtils;
using static MuseDashMirror.BattleComponent;

namespace SongDesc;

internal partial class Main : MelonMod
{
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("SongDesc is loaded!");
    }

    [GameStartPatch]
    private static void CreateDescription(object sender, GameStartEventArgs args)
    {
        var canvas = CreateCameraCanvas("Song Description Canvas", CameraDimension.TwoD);
        CreateEllipseText("ChartName", canvas,
            new EllipseTextParameters(ChartName, 40.., 40, TextAnchor.UpperRight),
            new TransformParameters(new Vector3(5.45f, 3.5f, 90f), new RightEdgePositionStrategy()));
        CreateEllipseText("Author + Level", canvas,
            new EllipseTextParameters(MusicAuthor + "  -  Lvl." + ChartLevel, 24..^(9 + ChartLevel.Length), 30, TextAnchor.UpperRight),
            new TransformParameters(new Vector3(5.45f, 3.2f, 90f), new RightEdgePositionStrategy()));
    }
}