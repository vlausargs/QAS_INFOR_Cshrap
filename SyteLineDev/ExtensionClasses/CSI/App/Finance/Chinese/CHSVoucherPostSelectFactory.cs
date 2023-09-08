//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSVoucherPostSelectFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSVoucherPostSelectFactory
    {
        public ICHSVoucherPostSelect Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CHSVoucherPostSelect = new CHSVoucherPostSelect(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSVoucherPostSelectExt = timerfactory.Create<ICHSVoucherPostSelect>(_CHSVoucherPostSelect);

            return iCHSVoucherPostSelectExt;
        }
    }
}
