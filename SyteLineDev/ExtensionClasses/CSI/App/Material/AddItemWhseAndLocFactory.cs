//PROJECT NAME: CSIMaterial
//CLASS NAME: AddItemWhseAndLocFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AddItemWhseAndLocFactory
    {
        public IAddItemWhseAndLoc Create(IApplicationDB appDB)
        {
            var _AddItemWhseAndLoc = new AddItemWhseAndLoc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAddItemWhseAndLocExt = timerfactory.Create<IAddItemWhseAndLoc>(_AddItemWhseAndLoc);

            return iAddItemWhseAndLocExt;
        }
    }
}
