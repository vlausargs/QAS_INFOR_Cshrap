//PROJECT NAME: Material
//CLASS NAME: MrpWbGetDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGetDateFactory
	{
		public IMrpWbGetDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGetDate = new Material.MrpWbGetDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGetDateExt = timerfactory.Create<Material.IMrpWbGetDate>(_MrpWbGetDate);
			
			return iMrpWbGetDateExt;
		}
	}
}
