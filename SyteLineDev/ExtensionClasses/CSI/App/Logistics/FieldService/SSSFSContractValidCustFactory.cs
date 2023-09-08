//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSContractValidCustFactory
    {
        public ISSSFSContractValidCust Create(IApplicationDB appDB)
        {
            var _SSSFSContractValidCust = new Logistics.FieldService.SSSFSContractValidCust(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSContractValidCustExt = timerfactory.Create<Logistics.FieldService.ISSSFSContractValidCust>(_SSSFSContractValidCust);

            return iSSSFSContractValidCustExt;
        }
    }
}
