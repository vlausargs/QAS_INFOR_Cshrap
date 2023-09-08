//PROJECT NAME: Material
//CLASS NAME: MvPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MvPostFactory
	{
		public IMvPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MvPost = new Material.MvPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMvPostExt = timerfactory.Create<Material.IMvPost>(_MvPost);
			
			return iMvPostExt;
		}
	}
}
