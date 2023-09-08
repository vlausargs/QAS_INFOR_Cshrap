//PROJECT NAME: CSIProduct
//CLASS NAME: CheckSerialFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CheckSerialFactory
    {
        public ICheckSerial Create(IApplicationDB appDB)
        {
            var _CheckSerial = new CheckSerial(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckSerialExt = timerfactory.Create<ICheckSerial>(_CheckSerial);

            return iCheckSerialExt;
        }
    }
}
