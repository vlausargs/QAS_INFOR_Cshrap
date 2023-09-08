//PROJECT NAME: CSIMaterial
//CLASS NAME: AddReplaceSheetFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class AddReplaceSheetFactory
    {
        public IAddReplaceSheet Create(IApplicationDB appDB)
        {
            var _AddReplaceSheet = new AddReplaceSheet(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAddReplaceSheetExt = timerfactory.Create<IAddReplaceSheet>(_AddReplaceSheet);

            return iAddReplaceSheetExt;
        }
    }
}
