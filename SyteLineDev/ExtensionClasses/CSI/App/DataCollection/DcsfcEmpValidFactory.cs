//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcEmpValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcEmpValidFactory
    {
        public IDcsfcEmpValid Create(IApplicationDB appDB)
        {
            var _DcsfcEmpValid = new DcsfcEmpValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcEmpValidExt = timerfactory.Create<IDcsfcEmpValid>(_DcsfcEmpValid);

            return iDcsfcEmpValidExt;
        }
    }
}
