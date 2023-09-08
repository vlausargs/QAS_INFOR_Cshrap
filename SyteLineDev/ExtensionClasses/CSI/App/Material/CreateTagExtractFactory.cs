//PROJECT NAME: Material
//CLASS NAME: CreateTagExtractFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CreateTagExtractFactory
	{
		public ICreateTagExtract Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateTagExtract = new Material.CreateTagExtract(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateTagExtractExt = timerfactory.Create<Material.ICreateTagExtract>(_CreateTagExtract);
			
			return iCreateTagExtractExt;
		}
	}
}
