//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSRecurrVoucherPreviewToGenFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSRecurrVoucherPreviewToGenFactory
    {
        public ICHSRecurrVoucherPreviewToGen Create(IApplicationDB appDB)
        {
            var _CHSRecurrVoucherPreviewToGen = new CHSRecurrVoucherPreviewToGen(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSRecurrVoucherPreviewToGenExt = timerfactory.Create<ICHSRecurrVoucherPreviewToGen>(_CHSRecurrVoucherPreviewToGen);

            return iCHSRecurrVoucherPreviewToGenExt;
        }
    }
}

