//PROJECT NAME: CSICustomer
//CLASS NAME: CARaSSetItemExtractDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CARaSSetItemExtractDateFactory
	{
		public ICARaSSetItemExtractDate Create(IApplicationDB appDB)
		{
			var _CARaSSetItemExtractDate = new Logistics.Customer.CARaSSetItemExtractDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSSetItemExtractDateExt = timerfactory.Create<Logistics.Customer.ICARaSSetItemExtractDate>(_CARaSSetItemExtractDate);
			
			return iCARaSSetItemExtractDateExt;
		}
	}
}
