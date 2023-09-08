//PROJECT NAME: Material
//CLASS NAME: TransferPriceCodeValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TransferPriceCodeValidFactory
	{
		public ITransferPriceCodeValid Create(IApplicationDB appDB)
		{
			var _TransferPriceCodeValid = new Material.TransferPriceCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferPriceCodeValidExt = timerfactory.Create<Material.ITransferPriceCodeValid>(_TransferPriceCodeValid);
			
			return iTransferPriceCodeValidExt;
		}
	}
}
