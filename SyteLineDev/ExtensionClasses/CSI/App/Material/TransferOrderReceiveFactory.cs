//PROJECT NAME: Material
//CLASS NAME: TransferOrderReceiveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TransferOrderReceiveFactory
	{
		public ITransferOrderReceive Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransferOrderReceive = new Material.TransferOrderReceive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferOrderReceiveExt = timerfactory.Create<Material.ITransferOrderReceive>(_TransferOrderReceive);
			
			return iTransferOrderReceiveExt;
		}
	}
}
