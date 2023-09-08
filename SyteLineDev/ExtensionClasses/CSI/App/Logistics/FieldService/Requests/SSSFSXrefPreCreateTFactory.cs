//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSXrefPreCreateTFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSXrefPreCreateTFactory
    {
        public ISSSFSXrefPreCreateT Create(IApplicationDB appDB)
        {
            var _SSSFSXrefPreCreateT = new Logistics.FieldService.Requests.SSSFSXrefPreCreateT(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSXrefPreCreateTExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSXrefPreCreateT>(_SSSFSXrefPreCreateT);

            return iSSSFSXrefPreCreateTExt;
        }
    }
}
