//PROJECT NAME: CSIProduct
//CLASS NAME: GenPsValidateDateFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GenPsValidateDateFactory
    {
        public IGenPsValidateDate Create(IApplicationDB appDB)
        {
            var _GenPsValidateDate = new GenPsValidateDate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenPsValidateDateExt = timerfactory.Create<IGenPsValidateDate>(_GenPsValidateDate);

            return iGenPsValidateDateExt;
        }
    }
}
