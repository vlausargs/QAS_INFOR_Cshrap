//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpUomConvQtyFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpUomConvQtyFactory
    {
        public IApsCtpUomConvQty Create(IApplicationDB appDB)
        {
            var _ApsCtpUomConvQty = new ApsCtpUomConvQty(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpUomConvQtyExt = timerfactory.Create<IApsCtpUomConvQty>(_ApsCtpUomConvQty);

            return iApsCtpUomConvQtyExt;
        }
    }
}
