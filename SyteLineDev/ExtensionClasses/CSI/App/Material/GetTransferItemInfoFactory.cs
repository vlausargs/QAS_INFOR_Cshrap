//PROJECT NAME: Material
//CLASS NAME: GetTransferItemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetTransferItemInfoFactory
	{
		public IGetTransferItemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetTransferItemInfo = new Material.GetTransferItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTransferItemInfoExt = timerfactory.Create<Material.IGetTransferItemInfo>(_GetTransferItemInfo);
			
			return iGetTransferItemInfoExt;
		}
	}
}
