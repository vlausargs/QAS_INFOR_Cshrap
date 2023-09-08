//PROJECT NAME: Logistics
//CLASS NAME: UomConvAmtQtyInvAdjsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UomConvAmtQtyInvAdjsFactory
	{
		public IUomConvAmtQtyInvAdjs Create(IApplicationDB appDB)
		{
			var _UomConvAmtQtyInvAdjs = new Logistics.Customer.UomConvAmtQtyInvAdjs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUomConvAmtQtyInvAdjsExt = timerfactory.Create<Logistics.Customer.IUomConvAmtQtyInvAdjs>(_UomConvAmtQtyInvAdjs);
			
			return iUomConvAmtQtyInvAdjsExt;
		}
	}
}
