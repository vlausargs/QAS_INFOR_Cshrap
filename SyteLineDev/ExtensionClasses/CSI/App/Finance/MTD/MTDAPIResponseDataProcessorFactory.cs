using CSI.Data.CRUD;
using CSI.MG;

namespace CSI.Finance.MTD
{
    public class MTDAPIResponseDataProcessorFactory
    {
        public IMTDAPIResponseDataProcessor Create(IMTDBusinessHandlerCRUD mtdBusinessHandlerCRUD)
        {
            var mtdAPIResponseDataProcessor = new MTDAPIResponseDataProcessor(mtdBusinessHandlerCRUD);

            var timerFactory = new CSI.Data.Metric.TimerFactory();
            return timerFactory.Create<IMTDAPIResponseDataProcessor>(mtdAPIResponseDataProcessor);
        }
    }
}