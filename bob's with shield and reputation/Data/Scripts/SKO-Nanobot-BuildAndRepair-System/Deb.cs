using Sandbox.ModAPI;
using VRage.Utils;

namespace BattleStarNanoBuildAndRepairSystem
{
    internal class Deb
    {
        private static bool EnableDebug = false;

        public static void Write(string msg)
        {
            if (EnableDebug)
            {
                MyAPIGateway.Utilities.ShowMessage("SKO Debug", msg);
                MyLog.Default.WriteLineAndConsole("SKO Debug: " + msg);
            }
        }
    }
}
