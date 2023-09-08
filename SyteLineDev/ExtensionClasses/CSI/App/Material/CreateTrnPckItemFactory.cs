//PROJECT NAME: Material
//CLASS NAME: CreateTrnPckItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CreateTrnPckItemFactory
	{
		public ICreateTrnPckItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateTrnPckItem = new Material.CreateTrnPckItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateTrnPckItemExt = timerfactory.Create<Material.ICreateTrnPckItem>(_CreateTrnPckItem);
			
			return iCreateTrnPckItemExt;
		}
	}
}
