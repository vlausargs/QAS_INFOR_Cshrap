//PROJECT NAME: Material
//CLASS NAME: GetCurrentDateFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetCurrentDateFactory
	{
		public IGetCurrentDate Create(IApplicationDB appDB)
		{
			var _GetCurrentDate = new Material.GetCurrentDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurrentDateExt = timerfactory.Create<Material.IGetCurrentDate>(_GetCurrentDate);
			
			return iGetCurrentDateExt;
		}
	}
}
