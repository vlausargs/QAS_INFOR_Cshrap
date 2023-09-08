//PROJECT NAME: CSIProduct
//CLASS NAME: SetIssueParentFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class SetIssueParentFactory
    {
        public ISetIssueParent Create(IApplicationDB appDB)
        {
            var _SetIssueParent = new Production.SetIssueParent(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetIssueParentExt = timerfactory.Create<Production.ISetIssueParent>(_SetIssueParent);

            return iSetIssueParentExt;
        }
    }
}
