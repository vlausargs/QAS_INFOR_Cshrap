using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MG
{
    public interface ICSIExtensionClassBase
    {
        IApplicationDB AppDB { get; }
        IBunchedLoadCollection BunchedLoadCollection { get; }
        IMGInvoker MGInvoker { get; }
        IParameterProvider ParameterProvider { get; }
        IUserMessageLogger UserMessageLogger { get; }
        IMongooseDependencies MongooseDependencies { get; }
        [Obsolete("Please use IUserPrincipal. Obsolete since 9/15/2021. Remove at 12/15/2021.")]
        string UserName { get; }
        ICache MemoryCache { get; }

        bool FireApplicationEvent(
            string eventName,
            bool synchronous,
            bool transactional,
            out string result,
            ref CSIApplicationEventParameter[] parameters);
    }
}
