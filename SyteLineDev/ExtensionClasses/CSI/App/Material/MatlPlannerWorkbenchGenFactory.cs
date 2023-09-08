//PROJECT NAME: CSIMaterial
//CLASS NAME: MatlPlannerWorkbenchGenFactory.cs

using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
    public class MatlPlannerWorkbenchGenFactory
    {
        public IMatlPlannerWorkbenchGen Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _MatlPlannerWorkbenchGen = new Material.MatlPlannerWorkbenchGen(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMatlPlannerWorkbenchGenExt = timerfactory.Create<Material.IMatlPlannerWorkbenchGen>(_MatlPlannerWorkbenchGen);

            return iMatlPlannerWorkbenchGenExt;
        }
    }
}
