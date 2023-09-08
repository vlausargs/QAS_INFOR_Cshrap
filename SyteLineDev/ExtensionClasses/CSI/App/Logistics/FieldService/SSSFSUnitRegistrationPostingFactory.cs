//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSUnitRegistrationPostingFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public class SSSFSUnitRegistrationPostingFactory
    {
        public ISSSFSUnitRegistrationPosting Create(IApplicationDB appDB)
        {
            var _SSSFSUnitRegistrationPosting = new SSSFSUnitRegistrationPosting(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSUnitRegistrationPostingExt = timerfactory.Create<ISSSFSUnitRegistrationPosting>(_SSSFSUnitRegistrationPosting);

            return iSSSFSUnitRegistrationPostingExt;
        }
    }
}