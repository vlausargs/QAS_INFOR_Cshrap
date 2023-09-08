//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBPerUnitFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBPerUnitFactory
    {
        public IMultiFSBPerUnit Create(IApplicationDB appDB)
        {
            var _MultiFSBPerUnit = new MultiFSBPerUnit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMultiFSBPerUnitExt = timerfactory.Create<IMultiFSBPerUnit>(_MultiFSBPerUnit);

            return iMultiFSBPerUnitExt;
        }
    }
}
