//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcCycleAddLocPostFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcCycleAddLocPostFactory
    {
        public IDcCycleAddLocPost Create(IApplicationDB appDB)
        {
            var _DcCycleAddLocPost = new DcCycleAddLocPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcCycleAddLocPostExt = timerfactory.Create<IDcCycleAddLocPost>(_DcCycleAddLocPost);

            return iDcCycleAddLocPostExt;
        }
    }
}
