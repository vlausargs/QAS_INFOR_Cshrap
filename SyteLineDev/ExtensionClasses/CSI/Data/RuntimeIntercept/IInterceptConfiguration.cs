using CSI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface IInterceptConfiguration
    {
        /// <summary>
        /// Is true when data loads that could be serviced through this IDO should be.
        /// </summary>
        bool InterceptEnabled(string ido);

        /// <summary>
        /// Is true when method calls that could be serviced through this IDO method should be.
        /// </summary>
        bool InterceptEnabled(string ido, string method);
    }
}
