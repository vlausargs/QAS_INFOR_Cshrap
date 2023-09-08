//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLineTransValidQtyFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROLineTransValidQtyFactory
    {
        public ISSSFSSROLineTransValidQty Create(IApplicationDB appDB)
        {
            var _SSSFSSROLineTransValidQty = new SSSFSSROLineTransValidQty(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROLineTransValidQtyExt = timerfactory.Create<ISSSFSSROLineTransValidQty>(_SSSFSSROLineTransValidQty);

            return iSSSFSSROLineTransValidQtyExt;
        }
    }
}

