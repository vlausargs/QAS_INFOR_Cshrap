//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROStoreVarsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSROStoreVarsFactory
    {
        public ISSSFSSROStoreVars Create(IApplicationDB appDB)
        {
            var _SSSFSSROStoreVars = new SSSFSSROStoreVars(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSROStoreVarsExt = timerfactory.Create<ISSSFSSROStoreVars>(_SSSFSSROStoreVars);

            return iSSSFSSROStoreVarsExt;
        }
    }
}
