//PROJECT NAME: CSIEmployee
//CLASS NAME: PMTAttachFromTempFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PMTAttachFromTempFactory
    {
        public IPMTAttachFromTemp Create(IApplicationDB appDB)
        {
            var _PMTAttachFromTemp = new PMTAttachFromTemp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPMTAttachFromTempExt = timerfactory.Create<IPMTAttachFromTemp>(_PMTAttachFromTemp);

            return iPMTAttachFromTempExt;
        }
    }
}
