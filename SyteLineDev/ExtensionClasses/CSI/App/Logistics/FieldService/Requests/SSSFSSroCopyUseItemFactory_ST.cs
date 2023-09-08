//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSroCopyUseItFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSSroCopyUseItFactory_ST
    {
        public ISSSFSSroCopyUseIt_ST Create(IApplicationDB appDB)
        {
            var _SSSFSSroCopyUseIt_ST = new Logistics.FieldService.Requests.SSSFSSroCopyUseIt_ST(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSSroCopyUseIt_STExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSSroCopyUseIt_ST>(_SSSFSSroCopyUseIt_ST);

            return iSSSFSSroCopyUseIt_STExt;
        }
    }
}
