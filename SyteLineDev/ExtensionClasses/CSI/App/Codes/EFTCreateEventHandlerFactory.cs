//PROJECT NAME: CSICodes
//CLASS NAME: EFTCreateEventHandlerFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class EFTCreateEventHandlerFactory
    {
        public IEFTCreateEventHandler Create(IApplicationDB appDB)
        {
            var _EFTCreateEventHandler = new EFTCreateEventHandler(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEFTCreateEventHandlerExt = timerfactory.Create<IEFTCreateEventHandler>(_EFTCreateEventHandler);

            return iEFTCreateEventHandlerExt;
        }
    }
}
