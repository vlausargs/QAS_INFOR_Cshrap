//PROJECT NAME: Logistics
//CLASS NAME: UomConvAmtFactory.cs

using CSI.MG;
using CSI.Data.Utilities;

namespace CSI.Logistics.Customer
{
	public class UomConvAmtFactory
	{
		public IUomConvAmt Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
            var appDB = cSIExtensionClassBase.AppDB;
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var _UomConvAmt = new Logistics.Customer.UomConvAmt(appDB, mathUtil, sQLUtil);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUomConvAmtExt = timerfactory.Create<Logistics.Customer.IUomConvAmt>(_UomConvAmt);
			
			return iUomConvAmtExt;
		}
	}
}
