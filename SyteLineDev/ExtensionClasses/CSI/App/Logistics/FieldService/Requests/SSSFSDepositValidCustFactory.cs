//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSDepositValidCustFactory
    {
        public ISSSFSDepositValidCust Create(IApplicationDB appDB)
        {
            var _SSSFSDepositValidCust = new SSSFSDepositValidCust(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSDepositValidCustExt = timerfactory.Create<ISSSFSDepositValidCust>(_SSSFSDepositValidCust);

            return iSSSFSDepositValidCustExt;
        }
    }
}