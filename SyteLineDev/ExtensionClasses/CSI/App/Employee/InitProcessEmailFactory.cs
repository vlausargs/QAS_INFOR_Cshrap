//PROJECT NAME: CSIEmployee
//CLASS NAME: InitProcessEmailFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class InitProcessEmailFactory
    {
        public IInitProcessEmail Create(IApplicationDB appDB)
        {
            var _InitProcessEmail = new InitProcessEmail(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInitProcessEmailExt = timerfactory.Create<IInitProcessEmail>(_InitProcessEmail);

            return iInitProcessEmailExt;
        }
    }
}
