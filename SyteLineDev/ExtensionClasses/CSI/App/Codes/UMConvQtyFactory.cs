//PROJECT NAME: Codes
//CLASS NAME: UMConvQtyFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class UMConvQtyFactory
	{
		public IUMConvQty Create(IApplicationDB appDB)
		{
			var _UMConvQty = new Codes.UMConvQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUMConvQtyExt = timerfactory.Create<Codes.IUMConvQty>(_UMConvQty);
			
			return iUMConvQtyExt;
		}
	}
}
