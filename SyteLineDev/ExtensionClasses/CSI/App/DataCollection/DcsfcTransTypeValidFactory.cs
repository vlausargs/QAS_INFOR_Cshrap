//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcTransTypeValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcTransTypeValidFactory
    {
        public IDcsfcTransTypeValid Create(IApplicationDB appDB)
        {
            var _DcsfcTransTypeValid = new DcsfcTransTypeValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcTransTypeValidExt = timerfactory.Create<IDcsfcTransTypeValid>(_DcsfcTransTypeValid);

            return iDcsfcTransTypeValidExt;
        }
    }
}

