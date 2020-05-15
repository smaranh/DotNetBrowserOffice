using DotNetBrowser.Engine;
using System;

namespace CoreLib
{
    public static class Core
    {
        public static IEngine engine;
        public static bool isExcelAlive = false;
        public static bool isPptAlive = false;

        public static void InititateEngine()
        {
            if (engine == null)
            {
                if (isExcelAlive || isPptAlive)
                {
                    engine = createEngine();
                }
            }
        }

        public static void DisposeEngine()
        {
            if (engine != null)
            {
                if (!isExcelAlive && !isPptAlive)
                {
                    engine?.Dispose();
                }
            }
        }

        private static IEngine createEngine()
        {
            IEngine engine = EngineFactory.Create(new EngineOptions.Builder
            {
                RenderingMode = RenderingMode.HardwareAccelerated,
                RemoteDebuggingPort = 9222,
                ChromiumDirectory = @"C:\DEV\testing\dotnetbrowser\binaries",
                UserDataDirectory = @"C:\DEV\testing\dotnetbrowser\userdata"
            }
            .Build());
            return engine;
        }
    }
}