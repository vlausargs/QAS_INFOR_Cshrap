//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSValidateVchTypeCodeFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSValidateVchTypeCodeFactory
    {
        public ICHSValidateVchTypeCode Create(IApplicationDB appDB)
        {
            var _CHSValidateVchTypeCode = new CHSValidateVchTypeCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSValidateVchTypeCodeExt = timerfactory.Create<ICHSValidateVchTypeCode>(_CHSValidateVchTypeCode);

            return iCHSValidateVchTypeCodeExt;
        }
    }
}

