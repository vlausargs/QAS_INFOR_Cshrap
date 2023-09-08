//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateCoReservationFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class ValidateCoReservationFactory
    {
        public IValidateCoReservation Create(IApplicationDB appDB)
        {
            var _ValidateCoReservation = new ValidateCoReservation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateCoReservationExt = timerfactory.Create<IValidateCoReservation>(_ValidateCoReservation);

            return iValidateCoReservationExt;
        }
    }
}
