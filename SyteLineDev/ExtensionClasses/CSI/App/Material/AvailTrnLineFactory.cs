//PROJECT NAME: Material
//CLASS NAME: AvailTrnLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class AvailTrnLineFactory
	{
		public IAvailTrnLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AvailTrnLine = new Material.AvailTrnLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAvailTrnLineExt = timerfactory.Create<Material.IAvailTrnLine>(_AvailTrnLine);
			
			return iAvailTrnLineExt;
		}
	}
}
