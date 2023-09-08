//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSCustContactValidCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSCustContactValidCustFactory
    {
        public ISSSFSCustContactValidCust Create(IApplicationDB appDB)
        {
            var _SSSFSCustContactValidCust = new SSSFSCustContactValidCust(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSCustContactValidCustExt = timerfactory.Create<ISSSFSCustContactValidCust>(_SSSFSCustContactValidCust);

            return iSSSFSCustContactValidCustExt;
        }
    }
}
