//PROJECT NAME: Material
//CLASS NAME: TransferLossIaPostSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TransferLossIaPostSetVarsFactory
	{
		public ITransferLossIaPostSetVars Create(IApplicationDB appDB)
		{
			var _TransferLossIaPostSetVars = new Material.TransferLossIaPostSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferLossIaPostSetVarsExt = timerfactory.Create<Material.ITransferLossIaPostSetVars>(_TransferLossIaPostSetVars);
			
			return iTransferLossIaPostSetVarsExt;
		}
	}
}
