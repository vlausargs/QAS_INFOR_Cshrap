//PROJECT NAME: CSIMaterial
//CLASS NAME: SchRcvDateValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SchRcvDateValidFactory
    {
        public ISchRcvDateValid Create(IApplicationDB appDB)
        {
            var _SchRcvDateValid = new SchRcvDateValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSchRcvDateValidExt = timerfactory.Create<ISchRcvDateValid>(_SchRcvDateValid);

            return iSchRcvDateValidExt;
        }
    }
}
