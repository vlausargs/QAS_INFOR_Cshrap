using CSI.Serializer;

namespace CSI.Finance.MTD
{
    public class MTDAPIFailedMessageFactory
    {
        public IMTDAPIFailedMessage Create()
        {
            var serializer = new SerializerFactory().Create(SerializerType.NewtonConvert);
            var mtdAPIFailedMessage = new MTDAPIFailedMessage(serializer);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IMTDAPIFailedMessage>(mtdAPIFailedMessage);
        }
    }
}