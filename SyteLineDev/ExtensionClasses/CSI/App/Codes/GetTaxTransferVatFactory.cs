//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxTransferVatFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class GetTaxTransferVatFactory
    {
        public IGetTaxTransferVat Create(IApplicationDB appDB)
        {
            var _GetTaxTransferVat = new Codes.GetTaxTransferVat(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetTaxTransferVatExt = timerfactory.Create<Codes.IGetTaxTransferVat>(_GetTaxTransferVat);

            return iGetTaxTransferVatExt;
        }
    }
}
