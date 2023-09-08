//PROJECT NAME: Material
//CLASS NAME: PostFirmPlnCleanupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class PostFirmPlnCleanupFactory
	{
		public IPostFirmPlnCleanup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PostFirmPlnCleanup = new Material.PostFirmPlnCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostFirmPlnCleanupExt = timerfactory.Create<Material.IPostFirmPlnCleanup>(_PostFirmPlnCleanup);
			
			return iPostFirmPlnCleanupExt;
		}
	}
}
