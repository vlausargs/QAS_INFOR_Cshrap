//PROJECT NAME: Material
//CLASS NAME: MrpWbGetPoInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGetPoInfoFactory
	{
		public IMrpWbGetPoInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGetPoInfo = new Material.MrpWbGetPoInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGetPoInfoExt = timerfactory.Create<Material.IMrpWbGetPoInfo>(_MrpWbGetPoInfo);
			
			return iMrpWbGetPoInfoExt;
		}
	}
}
