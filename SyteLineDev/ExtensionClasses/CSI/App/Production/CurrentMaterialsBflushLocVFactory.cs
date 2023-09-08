//PROJECT NAME: CSIProduct
//CLASS NAME: CurrentMaterialsBflushLocVFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CurrentMaterialsBflushLocVFactory
    {
        public ICurrentMaterialsBflushLocV Create(IApplicationDB appDB)
        {
            var _CurrentMaterialsBflushLocV = new Production.CurrentMaterialsBflushLocV(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrentMaterialsBflushLocVExt = timerfactory.Create<Production.ICurrentMaterialsBflushLocV>(_CurrentMaterialsBflushLocV);

            return iCurrentMaterialsBflushLocVExt;
        }
    }
}
