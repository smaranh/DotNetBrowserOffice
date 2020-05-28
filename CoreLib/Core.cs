using DotNetBrowser.Engine;
using System;

namespace ESRI.ArcGIS.Mapping.OfficeIntegration.Core
{
    public static class Core
    {

        public static IEngine createEngine(string userdatadir)
        {
            IEngine engine = EngineFactory.Create(new EngineOptions.Builder
            {
                RenderingMode = RenderingMode.HardwareAccelerated,
                RemoteDebuggingPort = 9222,
                ChromiumDirectory = @"C:\DEV\testing\dotnetbrowser\binaries",
                UserDataDirectory = userdatadir
            }
            .Build());
            return engine;
        }
    }
}