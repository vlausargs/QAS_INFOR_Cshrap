//PROJECT NAME: CSIMaterial
//CLASS NAME: ChglstatFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ChglstatFactory
    {
        public IChglstat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Chglstat = new Chglstat(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iChglstatExt = timerfactory.Create<IChglstat>(_Chglstat);

            return iChglstatExt;
        }
    }
}
