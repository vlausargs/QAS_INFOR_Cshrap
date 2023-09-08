//PROJECT NAME: Material
//CLASS NAME: MrpWbGetTransferInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGetTransferInfoFactory
	{
		public IMrpWbGetTransferInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGetTransferInfo = new Material.MrpWbGetTransferInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGetTransferInfoExt = timerfactory.Create<Material.IMrpWbGetTransferInfo>(_MrpWbGetTransferInfo);
			
			return iMrpWbGetTransferInfoExt;
		}
	}
}
