//PROJECT NAME: CSICodes
//CLASS NAME: GetCurrAcctsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetCurrAcctsFactory
    {
        public IGetCurrAccts Create(IApplicationDB appDB)
        {
            var _GetCurrAccts = new GetCurrAccts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCurrAcctsExt = timerfactory.Create<IGetCurrAccts>(_GetCurrAccts);

            return iGetCurrAcctsExt;
        }
    }
}
