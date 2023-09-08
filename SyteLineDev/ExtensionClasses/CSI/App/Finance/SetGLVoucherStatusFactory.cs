//PROJECT NAME: Finance
//CLASS NAME: SetGLVoucherStatusFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class SetGLVoucherStatusFactory
	{
		public ISetGLVoucherStatus Create(IApplicationDB appDB)
		{
			var _SetGLVoucherStatus = new Finance.SetGLVoucherStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetGLVoucherStatusExt = timerfactory.Create<Finance.ISetGLVoucherStatus>(_SetGLVoucherStatus);
			
			return iSetGLVoucherStatusExt;
		}
	}
}
