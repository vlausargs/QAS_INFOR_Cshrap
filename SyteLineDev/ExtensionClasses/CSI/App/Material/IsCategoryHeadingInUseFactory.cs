//PROJECT NAME: CSIMaterial
//CLASS NAME: IsCategoryHeadingInUseFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class IsCategoryHeadingInUseFactory
	{
		public IIsCategoryHeadingInUse Create(IApplicationDB appDB)
		{
			var _IsCategoryHeadingInUse = new Material.IsCategoryHeadingInUse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCategoryHeadingInUseExt = timerfactory.Create<Material.IIsCategoryHeadingInUse>(_IsCategoryHeadingInUse);
			
			return iIsCategoryHeadingInUseExt;
		}
	}
}
