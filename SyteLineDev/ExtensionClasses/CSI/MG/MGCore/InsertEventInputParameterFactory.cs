//PROJECT NAME: MG.MGCore
//CLASS NAME: InsertEventInputParameterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class InsertEventInputParameterFactory : IInsertEventInputParameterFactory
    {
        public IInsertEventInputParameter Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _InsertEventInputParameter = new InsertEventInputParameter(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInsertEventInputParameterExt = timerfactory.Create<MG.MGCore.IInsertEventInputParameter>(_InsertEventInputParameter);

            return iInsertEventInputParameterExt;
        }
    }
}
