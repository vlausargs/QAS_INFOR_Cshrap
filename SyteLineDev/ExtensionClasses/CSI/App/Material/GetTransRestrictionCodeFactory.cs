//PROJECT NAME: CSIMaterial
//CLASS NAME: GetTransRestrictionCodeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetTransRestrictionCodeFactory
	{
		public IGetTransRestrictionCode Create(IApplicationDB appDB)
		{
			var _GetTransRestrictionCode = new Material.GetTransRestrictionCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTransRestrictionCodeExt = timerfactory.Create<Material.IGetTransRestrictionCode>(_GetTransRestrictionCode);
			
			return iGetTransRestrictionCodeExt;
		}
	}
}
