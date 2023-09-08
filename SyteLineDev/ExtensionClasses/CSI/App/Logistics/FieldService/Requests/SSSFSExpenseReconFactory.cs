//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSExpenseReconFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSExpenseReconFactory
    {
        public ISSSFSExpenseRecon Create(IApplicationDB appDB)
        {
            var _SSSFSExpenseRecon = new SSSFSExpenseRecon(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSExpenseReconExt = timerfactory.Create<ISSSFSExpenseRecon>(_SSSFSExpenseRecon);

            return iSSSFSExpenseReconExt;
        }
    }
}