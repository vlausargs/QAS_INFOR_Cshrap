//PROJECT NAME: CSIMaterial
//CLASS NAME: PrintInvShtsDeleteTTFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PrintInvShtsDeleteTTFactory
	{
		public IPrintInvShtsDeleteTT Create(IApplicationDB appDB)
		{
			var _PrintInvShtsDeleteTT = new Material.PrintInvShtsDeleteTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrintInvShtsDeleteTTExt = timerfactory.Create<Material.IPrintInvShtsDeleteTT>(_PrintInvShtsDeleteTT);
			
			return iPrintInvShtsDeleteTTExt;
		}
	}
}
