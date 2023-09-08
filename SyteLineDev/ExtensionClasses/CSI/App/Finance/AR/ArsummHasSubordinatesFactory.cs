//PROJECT NAME: CSICustomer
//CLASS NAME: ArsummHasSubordinatesFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArsummHasSubordinatesFactory
    {
        public IArsummHasSubordinates Create(IApplicationDB appDB)
        {
            var _ArsummHasSubordinates = new ArsummHasSubordinates(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArsummHasSubordinatesExt = timerfactory.Create<IArsummHasSubordinates>(_ArsummHasSubordinates);

            return iArsummHasSubordinatesExt;
        }
    }
}
