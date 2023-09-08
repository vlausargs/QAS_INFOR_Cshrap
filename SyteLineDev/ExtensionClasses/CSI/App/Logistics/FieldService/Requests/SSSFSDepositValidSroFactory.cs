//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositValidSroFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSDepositValidSroFactory
    {
        public ISSSFSDepositValidSro Create(IApplicationDB appDB)
        {
            var _SSSFSDepositValidSro = new SSSFSDepositValidSro(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSDepositValidSroExt = timerfactory.Create<ISSSFSDepositValidSro>(_SSSFSDepositValidSro);

            return iSSSFSDepositValidSroExt;
        }
    }
}
