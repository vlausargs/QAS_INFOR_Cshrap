//PROJECT NAME: Material
//CLASS NAME: UpdateItemLocAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class UpdateItemLocAcctFactory
	{
		public IUpdateItemLocAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateItemLocAcct = new Material.UpdateItemLocAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateItemLocAcctExt = timerfactory.Create<Material.IUpdateItemLocAcct>(_UpdateItemLocAcct);
			
			return iUpdateItemLocAcctExt;
		}
	}
}
