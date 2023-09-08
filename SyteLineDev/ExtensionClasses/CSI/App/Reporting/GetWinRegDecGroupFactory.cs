//PROJECT NAME: Reporting
//CLASS NAME: GetWinRegDecGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Reporting
{
    public class GetWinRegDecGroupFactory : IGetWinRegDecGroupFactory
    {
        public IGetWinRegDecGroup Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _GetWinRegDecGroup = new GetWinRegDecGroup(appDB);


            return _GetWinRegDecGroup;
        }
        public IGetWinRegDecGroup Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetWinRegDecGroup = new GetWinRegDecGroup(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetWinRegDecGroupExt = timerfactory.Create<IGetWinRegDecGroup>(_GetWinRegDecGroup);

            return iGetWinRegDecGroupExt;
        }
    }
}
