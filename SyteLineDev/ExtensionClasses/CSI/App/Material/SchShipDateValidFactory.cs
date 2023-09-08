//PROJECT NAME: CSIMaterial
//CLASS NAME: SchShipDateValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class SchShipDateValidFactory
    {
        public ISchShipDateValid Create(IApplicationDB appDB)
        {
            var _SchShipDateValid = new SchShipDateValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSchShipDateValidExt = timerfactory.Create<ISchShipDateValid>(_SchShipDateValid);

            return iSchShipDateValidExt;
        }
    }
}
