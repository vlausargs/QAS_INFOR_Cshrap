//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcLotValidFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcsfcLotValidFactory
    {
        public IDcsfcLotValid Create(IApplicationDB appDB)
        {
            var _DcsfcLotValid = new DcsfcLotValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcsfcLotValidExt = timerfactory.Create<IDcsfcLotValid>(_DcsfcLotValid);

            return iDcsfcLotValidExt;
        }
    }
}

