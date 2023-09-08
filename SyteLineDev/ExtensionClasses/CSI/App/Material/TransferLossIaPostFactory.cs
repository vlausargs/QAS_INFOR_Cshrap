//PROJECT NAME: Material
//CLASS NAME: TransferLossIaPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class TransferLossIaPostFactory
	{
		public ITransferLossIaPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TransferLossIaPost = new Material.TransferLossIaPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferLossIaPostExt = timerfactory.Create<Material.ITransferLossIaPost>(_TransferLossIaPost);
			
			return iTransferLossIaPostExt;
		}
	}
}
