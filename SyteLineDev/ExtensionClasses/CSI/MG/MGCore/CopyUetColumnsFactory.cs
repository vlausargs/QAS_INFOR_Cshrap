//PROJECT NAME: MG.MGCore
//CLASS NAME: CopyUetColumnsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class CopyUetColumnsFactory : ICopyUetColumnsFactory
    {
        public ICopyUetColumns Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _CopyUetColumns = new CopyUetColumns(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCopyUetColumnsExt = timerfactory.Create<MG.MGCore.ICopyUetColumns>(_CopyUetColumns);

            return iCopyUetColumnsExt;
        }
    }
}
