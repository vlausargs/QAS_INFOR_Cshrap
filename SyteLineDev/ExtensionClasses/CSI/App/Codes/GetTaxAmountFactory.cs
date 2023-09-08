//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxAmountFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetTaxAmountFactory
    {
        public IGetTaxAmount Create(IApplicationDB appDB)
        {
            var _GetTaxAmount = new Codes.GetTaxAmount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTaxAmountExt = timerfactory.Create<Codes.IGetTaxAmount>(_GetTaxAmount);

            return iGetTaxAmountExt;
        }
    }
}
