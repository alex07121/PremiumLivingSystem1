using System;
using System.ComponentModel;
using System.Diagnostics;

namespace PremiumLivingSystem
{
    internal static class DesignModeHelper
    {
        public static bool IsDesignMode()
        {
            try
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return true;

                using (Process p = Process.GetCurrentProcess())
                {
                    string name = p.ProcessName ?? string.Empty;
                    if (name.Equals("devenv", StringComparison.OrdinalIgnoreCase) ||
                        name.Equals("XDesProc", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // If anything goes wrong, assume not design mode to avoid hiding real issues at runtime
            }

            return false;
        }
    }
}
