//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CheckCoLineAndBlanketFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class AU_CheckCoLineAndBlanketFactory
    {
        public IAU_CheckCoLineAndBlanket Create(IApplicationDB appDB)
        {
            var _AU_CheckCoLineAndBlanket = new AU_CheckCoLineAndBlanket(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_CheckCoLineAndBlanketExt = timerfactory.Create<IAU_CheckCoLineAndBlanket>(_AU_CheckCoLineAndBlanket);

            return iAU_CheckCoLineAndBlanketExt;
        }
    }
}
