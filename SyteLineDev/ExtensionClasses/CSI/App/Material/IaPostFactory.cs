//PROJECT NAME: Material
//CLASS NAME: IaPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class IaPostFactory
	{
		public IIaPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IaPost = new Material.IaPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIaPostExt = timerfactory.Create<Material.IIaPost>(_IaPost);
			
			return iIaPostExt;
		}
	}
}
