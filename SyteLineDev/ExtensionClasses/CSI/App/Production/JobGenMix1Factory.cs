//PROJECT NAME: CSIProduct
//CLASS NAME: JobGenMix1Factory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobGenMix1Factory
    {
        public IJobGenMix1 Create(IApplicationDB appDB)
        {
            var _JobGenMix1 = new JobGenMix1(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobGenMix1Ext = timerfactory.Create<IJobGenMix1>(_JobGenMix1);

            return iJobGenMix1Ext;
        }
    }
}
