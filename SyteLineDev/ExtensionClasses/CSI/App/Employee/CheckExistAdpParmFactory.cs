//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckExistAdpParmFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CheckExistAdpParmFactory
    {
        public ICheckExistAdpParm Create(IApplicationDB appDB)
        {
            var _CheckExistAdpParm = new CheckExistAdpParm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckExistAdpParmExt = timerfactory.Create<ICheckExistAdpParm>(_CheckExistAdpParm);

            return iCheckExistAdpParmExt;
        }
    }
}
