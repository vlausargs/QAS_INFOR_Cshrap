//PROJECT NAME: CSIFinance
//CLASS NAME: CopyTemplateToGLVoucherFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class CopyTemplateToGLVoucherFactory
    {
        public ICopyTemplateToGLVoucher Create(IApplicationDB appDB)
        {
            var _CopyTemplateToGLVoucher = new CopyTemplateToGLVoucher(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLGLVoucherTemplatesExt = timerfactory.Create<ICopyTemplateToGLVoucher>(_CopyTemplateToGLVoucher);

            return iSLGLVoucherTemplatesExt;
        }
    }
}
