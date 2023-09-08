//PROJECT NAME: CSIProduct
//CLASS NAME: EDWcValuesCurrOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class EDWcValuesCurrOperFactory
    {
        public IEDWcValuesCurrOper Create(IApplicationDB appDB)
        {
            var _EDWcValuesCurrOper = new EDWcValuesCurrOper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEDWcValuesCurrOperExt = timerfactory.Create<IEDWcValuesCurrOper>(_EDWcValuesCurrOper);

            return iEDWcValuesCurrOperExt;
        }
    }
}
