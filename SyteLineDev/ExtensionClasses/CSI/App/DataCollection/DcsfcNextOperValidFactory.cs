//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcNextOperValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcNextOperValidFactory
    {
        public IDcsfcNextOperValid Create(IApplicationDB appDB)
        {
            var _DcsfcNextOperValid = new DcsfcNextOperValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcNextOperValidExt = timerfactory.Create<IDcsfcNextOperValid>(_DcsfcNextOperValid);

            return iDcsfcNextOperValidExt;
        }
    }
}

