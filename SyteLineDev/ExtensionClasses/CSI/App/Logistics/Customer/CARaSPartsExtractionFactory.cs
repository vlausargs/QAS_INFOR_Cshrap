//PROJECT NAME: CSICustomer
//CLASS NAME: CARaSPartsExtractionFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CARaSPartsExtractionFactory
	{
		public ICARaSPartsExtraction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CARaSPartsExtraction = new Customer.CARaSPartsExtraction(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSPartsExtractionExt = timerfactory.Create<Customer.ICARaSPartsExtraction>(_CARaSPartsExtraction);
			
			return iCARaSPartsExtractionExt;
		}
	}
}
