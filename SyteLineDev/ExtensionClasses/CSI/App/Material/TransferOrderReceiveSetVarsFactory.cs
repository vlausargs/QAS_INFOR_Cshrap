//PROJECT NAME: Material
//CLASS NAME: TransferOrderReceiveSetVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TransferOrderReceiveSetVarsFactory
	{
		public ITransferOrderReceiveSetVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransferOrderReceiveSetVars = new Material.TransferOrderReceiveSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferOrderReceiveSetVarsExt = timerfactory.Create<Material.ITransferOrderReceiveSetVars>(_TransferOrderReceiveSetVars);
			
			return iTransferOrderReceiveSetVarsExt;
		}
	}
}
