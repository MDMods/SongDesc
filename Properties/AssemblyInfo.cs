﻿using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;
using SongDesc;
using Main = SongDesc.Main;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SongDesc")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SongDesc")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("fa5c392a-8fc5-41fc-b5e6-62501085e01a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(MelonBuildInfo.Version)]
[assembly: AssemblyFileVersion(MelonBuildInfo.Version)]
[assembly: MelonInfo(typeof(Main), MelonBuildInfo.Name, MelonBuildInfo.Version, MelonBuildInfo.Author)]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]