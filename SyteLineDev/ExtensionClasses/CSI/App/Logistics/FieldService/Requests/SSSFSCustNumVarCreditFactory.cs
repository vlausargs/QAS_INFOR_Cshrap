//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSCustNumVarCreditFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSCustNumVarCreditFactory
    {
        public ISSSFSCustNumVarCredit Create(IApplicationDB appDB)
        {
            var _SSSFSCustNumVarCredit = new SSSFSCustNumVarCredit(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSCustNumVarCreditExt = timerfactory.Create<ISSSFSCustNumVarCredit>(_SSSFSCustNumVarCredit);

            return iSSSFSCustNumVarCreditExt;
        }
    }
}
