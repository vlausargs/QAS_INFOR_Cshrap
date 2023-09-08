//PROJECT NAME: CSIVendor
//CLASS NAME: CARaSCommodityCodeExtractionFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CARaSCommodityCodeExtractionFactory
	{
		public ICARaSCommodityCodeExtraction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CARaSCommodityCodeExtraction = new Vendor.CARaSCommodityCodeExtraction(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCARaSCommodityCodeExtractionExt = timerfactory.Create<Vendor.ICARaSCommodityCodeExtraction>(_CARaSCommodityCodeExtraction);
			
			return iCARaSCommodityCodeExtractionExt;
		}
	}
}
