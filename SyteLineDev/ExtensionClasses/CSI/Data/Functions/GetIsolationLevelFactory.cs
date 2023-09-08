//PROJECT NAME: MG.MGCore
//CLASS NAME: GetIsolationLevelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class GetIsolationLevelFactory : IGetIsolationLevelFactory
    {
        public IGetIsolationLevel Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetIsolationLevel = new GetIsolationLevel(appDB);

            return _GetIsolationLevel;
        }
    }
}
