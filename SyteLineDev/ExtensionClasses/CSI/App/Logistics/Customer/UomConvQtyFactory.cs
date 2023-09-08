//PROJECT NAME: Logistics
//CLASS NAME: UomConvQtyFactory.cs

using CSI.MG;
using CSI.Data.Utilities;

namespace CSI.Logistics.Customer
{
	public class UomConvQtyFactory
	{
        public IUomConvQty Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var _UomConvQty = new UomConvQty(appDB, mathUtil, sQLUtil);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iUomConvQtyExt = timerfactory.Create<IUomConvQty>(_UomConvQty);

            return iUomConvQtyExt;
        }
    }
}
