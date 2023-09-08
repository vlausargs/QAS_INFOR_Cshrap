//PROJECT NAME: CSIProduct
//CLASS NAME: SetWcValuesForCurrOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SetWcValuesForCurrOperFactory
    {
        public ISetWcValuesForCurrOper Create(IApplicationDB appDB)
        {
            var _SetWcValuesForCurrOper = new SetWcValuesForCurrOper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetWcValuesForCurrOperExt = timerfactory.Create<ISetWcValuesForCurrOper>(_SetWcValuesForCurrOper);

            return iSetWcValuesForCurrOperExt;
        }
    }
}
