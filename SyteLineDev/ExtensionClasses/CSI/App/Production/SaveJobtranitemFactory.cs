//PROJECT NAME: CSIProduct
//CLASS NAME: SaveJobtranitemFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SaveJobtranitemFactory
    {
        public ISaveJobtranitem Create(IApplicationDB appDB)
        {
            var _SaveJobtranitem = new Production.SaveJobtranitem(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSaveJobtranitemExt = timerfactory.Create<Production.ISaveJobtranitem>(_SaveJobtranitem);

            return iSaveJobtranitemExt;
        }
    }
}
