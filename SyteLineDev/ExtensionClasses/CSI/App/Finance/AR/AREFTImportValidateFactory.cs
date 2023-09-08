//PROJECT NAME: CSICustomer
//CLASS NAME: AREFTImportValidateFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class AREFTImportValidateFactory
    {
        public IAREFTImportValidate Create(IApplicationDB appDB)
        {
            var _AREFTImportValidate = new AREFTImportValidate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAREFTImportValidateExt = timerfactory.Create<IAREFTImportValidate>(_AREFTImportValidate);

            return iAREFTImportValidateExt;
        }
    }
}
