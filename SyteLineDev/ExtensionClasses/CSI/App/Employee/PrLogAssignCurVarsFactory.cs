//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogAssignCurVarsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrLogAssignCurVarsFactory
    {
        public IPrLogAssignCurVars Create(IApplicationDB appDB)
        {
            var _PrLogAssignCurVars = new PrLogAssignCurVars(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrLogAssignCurVarsExt = timerfactory.Create<IPrLogAssignCurVars>(_PrLogAssignCurVars);

            return iPrLogAssignCurVarsExt;
        }
    }
}
