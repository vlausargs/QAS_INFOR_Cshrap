//PROJECT NAME: CSIMaterial
//CLASS NAME: tmp_phyinvVerifyPrintFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class tmp_phyinvVerifyPrintFactory
	{
		public Itmp_phyinvVerifyPrint Create(IApplicationDB appDB)
		{
			var _tmp_phyinvVerifyPrint = new Material.tmp_phyinvVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var itmp_phyinvVerifyPrintExt = timerfactory.Create<Material.Itmp_phyinvVerifyPrint>(_tmp_phyinvVerifyPrint);
			
			return itmp_phyinvVerifyPrintExt;
		}
	}
}
