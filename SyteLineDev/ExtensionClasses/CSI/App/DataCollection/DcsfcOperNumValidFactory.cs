//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcOperNumValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcOperNumValidFactory
    {
        public IDcsfcOperNumValid Create(IApplicationDB appDB)
        {
            var _DcsfcOperNumValid = new DcsfcOperNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcOperNumValidExt = timerfactory.Create<IDcsfcOperNumValid>(_DcsfcOperNumValid);

            return iDcsfcOperNumValidExt;
        }
    }
}
