using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data
{
    public class Contract
    {
        public static void Requires<T>(bool assertion, string message) where T : Exception, new()
        {
            if (!assertion)
            {
                throw Activator.CreateInstance(typeof(T), message) as T;
            }
        }
    }
}
