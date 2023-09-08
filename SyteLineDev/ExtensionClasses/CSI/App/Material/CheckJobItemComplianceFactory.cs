//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckJobItemComplianceFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CheckJobItemComplianceFactory
	{
		public ICheckJobItemCompliance Create(IApplicationDB appDB)
		{
			var _CheckJobItemCompliance = new Material.CheckJobItemCompliance(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckJobItemComplianceExt = timerfactory.Create<Material.ICheckJobItemCompliance>(_CheckJobItemCompliance);
			
			return iCheckJobItemComplianceExt;
		}
	}
}
