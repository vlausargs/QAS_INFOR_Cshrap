//PROJECT NAME: CSIMaterial
//CLASS NAME: Whse05RFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class Whse05RFactory
    {
        public IWhse05R Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Whse05R = new Whse05R(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iWhse05RExt = timerfactory.Create<IWhse05R>(_Whse05R);

            return iWhse05RExt;
        }
    }
}
