//PROJECT NAME: Material
//CLASS NAME: DistAcctExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class DistAcctExistsFactory
	{
		public IDistAcctExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DistAcctExists = new Material.DistAcctExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDistAcctExistsExt = timerfactory.Create<Material.IDistAcctExists>(_DistAcctExists);
			
			return iDistAcctExistsExt;
		}
	}
}
