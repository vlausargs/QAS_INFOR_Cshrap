//PROJECT NAME: CSIDataCollection
//CLASS NAME: SecondsPastMidnightFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class SecondsPastMidnightFactory
    {
        public ISecondsPastMidnight Create(IApplicationDB appDB)
        {
            var _SecondsPastMidnight = new SecondsPastMidnight(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSecondsPastMidnightExt = timerfactory.Create<ISecondsPastMidnight>(_SecondsPastMidnight);

            return iSecondsPastMidnightExt;
        }
    }
}
