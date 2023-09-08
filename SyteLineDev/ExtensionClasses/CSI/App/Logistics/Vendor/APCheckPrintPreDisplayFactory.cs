//PROJECT NAME: CSIVendor
//CLASS NAME: APCheckPrintPreDisplayFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public class APCheckPrintPreDisplayFactory
    {
        public IAPCheckPrintPreDisplay Create(IApplicationDB appDB)
        {
            var _APCheckPrintPreDisplay = new Logistics.Vendor.APCheckPrintPreDisplay(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPCheckPrintPreDisplayExt = timerfactory.Create<Logistics.Vendor.IAPCheckPrintPreDisplay>(_APCheckPrintPreDisplay);

            return iAPCheckPrintPreDisplayExt;
        }
    }
}
