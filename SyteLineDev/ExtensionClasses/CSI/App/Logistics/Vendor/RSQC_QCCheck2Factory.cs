//PROJECT NAME: Logistics
//CLASS NAME: RSQC_QCCheck2Factory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class RSQC_QCCheck2Factory
	{
		public IRSQC_QCCheck2 Create(IApplicationDB appDB)
		{
			var _RSQC_QCCheck2 = new Logistics.Vendor.RSQC_QCCheck2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_QCCheck2Ext = timerfactory.Create<Logistics.Vendor.IRSQC_QCCheck2>(_RSQC_QCCheck2);
			
			return iRSQC_QCCheck2Ext;
		}
	}
}
