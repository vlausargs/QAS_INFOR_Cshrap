//PROJECT NAME: CSIMaterial
//CLASS NAME: PrintInvShtsVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PrintInvShtsVerifyCloseFormFactory
	{
		public IPrintInvShtsVerifyCloseForm Create(IApplicationDB appDB)
		{
			var _PrintInvShtsVerifyCloseForm = new Material.PrintInvShtsVerifyCloseForm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrintInvShtsVerifyCloseFormExt = timerfactory.Create<Material.IPrintInvShtsVerifyCloseForm>(_PrintInvShtsVerifyCloseForm);
			
			return iPrintInvShtsVerifyCloseFormExt;
		}
	}
}
