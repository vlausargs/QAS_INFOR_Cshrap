//PROJECT NAME: CSIProduct
//CLASS NAME: GenPSValidItemFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class GenPSValidItemFactory
    {
        public IGenPSValidItem Create(IApplicationDB appDB)
        {
            var _GenPSValidItem = new GenPSValidItem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGenPSValidItemExt = timerfactory.Create<IGenPSValidItem>(_GenPSValidItem);

            return iGenPSValidItemExt;
        }
    }
}
