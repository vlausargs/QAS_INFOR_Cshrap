//PROJECT NAME: CSICustomer
//CLASS NAME: CARaSSetCustExtractDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CARaSSetCustExtractDateFactory
	{
		public ICARaSSetCustExtractDate Create(IApplicationDB appDB)
		{
			var _CARaSSetCustExtractDate = new Logistics.Customer.CARaSSetCustExtractDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSSetCustExtractDateExt = timerfactory.Create<Logistics.Customer.ICARaSSetCustExtractDate>(_CARaSSetCustExtractDate);
			
			return iCARaSSetCustExtractDateExt;
		}
	}
}
