//PROJECT NAME: CSIMaterial
//CLASS NAME: SupDemItemwhseFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SupDemItemwhseFactory
    {
        public ISupDemItemwhse Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SupDemItemwhse = new SupDemItemwhse(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSupDemItemwhseExt = timerfactory.Create<ISupDemItemwhse>(_SupDemItemwhse);

            return iSupDemItemwhseExt;
        }
    }
}
