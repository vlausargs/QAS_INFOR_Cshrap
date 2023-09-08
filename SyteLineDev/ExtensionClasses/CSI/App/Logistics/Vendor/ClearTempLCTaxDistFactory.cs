//PROJECT NAME: Logistics
//CLASS NAME: ClearTempLCTaxDistFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ClearTempLCTaxDistFactory
	{
		public IClearTempLCTaxDist Create(IApplicationDB appDB)
		{
			var _ClearTempLCTaxDist = new Logistics.Vendor.ClearTempLCTaxDist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClearTempLCTaxDistExt = timerfactory.Create<Logistics.Vendor.IClearTempLCTaxDist>(_ClearTempLCTaxDist);
			
			return iClearTempLCTaxDistExt;
		}
	}
}
