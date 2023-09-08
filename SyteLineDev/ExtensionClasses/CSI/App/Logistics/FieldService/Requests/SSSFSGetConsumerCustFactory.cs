//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetConsumerCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSGetConsumerCustFactory
    {
        public ISSSFSGetConsumerCust Create(IApplicationDB appDB)
        {
            var _SSSFSGetConsumerCust = new SSSFSGetConsumerCust(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSGetConsumerCustExt = timerfactory.Create<ISSSFSGetConsumerCust>(_SSSFSGetConsumerCust);

            return iSSSFSGetConsumerCustExt;
        }
    }
}
