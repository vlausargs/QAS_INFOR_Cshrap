//PROJECT NAME: Material
//CLASS NAME: McalDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class McalDateFactory
	{
		public IMcalDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _McalDate = new Material.McalDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMcalDateExt = timerfactory.Create<Material.IMcalDate>(_McalDate);
			
			return iMcalDateExt;
		}
	}
}
