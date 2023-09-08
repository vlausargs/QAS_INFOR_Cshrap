//PROJECT NAME: CSIMaterial
//CLASS NAME: PostAdjTransWrapperFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PostAdjTransWrapperFactory
	{
		public IPostAdjTransWrapper Create(IApplicationDB appDB)
		{
			var _PostAdjTransWrapper = new Material.PostAdjTransWrapper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostAdjTransWrapperExt = timerfactory.Create<Material.IPostAdjTransWrapper>(_PostAdjTransWrapper);
			
			return iPostAdjTransWrapperExt;
		}
	}
}
