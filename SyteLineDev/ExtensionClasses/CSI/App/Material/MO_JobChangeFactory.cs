//PROJECT NAME: CSIMaterial
//CLASS NAME: MO_JobChangeFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class MO_JobChangeFactory
    {
        public IMO_JobChange Create(IApplicationDB appDB)
        {
            var _MO_JobChange = new MO_JobChange(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMO_JobChangeExt = timerfactory.Create<IMO_JobChange>(_MO_JobChange);

            return iMO_JobChangeExt;
        }
    }
}
