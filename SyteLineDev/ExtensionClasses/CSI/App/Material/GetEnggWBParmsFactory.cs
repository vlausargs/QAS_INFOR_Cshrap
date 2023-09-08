//PROJECT NAME: CSIMaterial
//CLASS NAME: GetEnggWBParmsFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GetEnggWBParmsFactory
    {
        public IGetEnggWBParms Create(IApplicationDB appDB)
        {
            var _GetEnggWBParms = new GetEnggWBParms(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetEnggWBParmsExt = timerfactory.Create<IGetEnggWBParms>(_GetEnggWBParms);

            return iGetEnggWBParmsExt;
        }
    }
}
