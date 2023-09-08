//PROJECT NAME: Material
//CLASS NAME: CreateTrnPickHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CreateTrnPickHeaderFactory
	{
		public ICreateTrnPickHeader Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateTrnPickHeader = new Material.CreateTrnPickHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateTrnPickHeaderExt = timerfactory.Create<Material.ICreateTrnPickHeader>(_CreateTrnPickHeader);
			
			return iCreateTrnPickHeaderExt;
		}
	}
}
