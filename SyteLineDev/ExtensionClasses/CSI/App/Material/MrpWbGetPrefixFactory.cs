//PROJECT NAME: Material
//CLASS NAME: MrpWbGetPrefixFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGetPrefixFactory
	{
		public IMrpWbGetPrefix Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGetPrefix = new Material.MrpWbGetPrefix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGetPrefixExt = timerfactory.Create<Material.IMrpWbGetPrefix>(_MrpWbGetPrefix);
			
			return iMrpWbGetPrefixExt;
		}
	}
}
