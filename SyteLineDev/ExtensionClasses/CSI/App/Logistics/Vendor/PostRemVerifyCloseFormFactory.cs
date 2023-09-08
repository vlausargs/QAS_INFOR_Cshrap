//PROJECT NAME: Logistics
//CLASS NAME: PostRemVerifyCloseFormFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PostRemVerifyCloseFormFactory
	{
		public IPostRemVerifyCloseForm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostRemVerifyCloseForm = new Logistics.Vendor.PostRemVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostRemVerifyCloseFormExt = timerfactory.Create<Logistics.Vendor.IPostRemVerifyCloseForm>(_PostRemVerifyCloseForm);
			
			return iPostRemVerifyCloseFormExt;
		}
	}
}
