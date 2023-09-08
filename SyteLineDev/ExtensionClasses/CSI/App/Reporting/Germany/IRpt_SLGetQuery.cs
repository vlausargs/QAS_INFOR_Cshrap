//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLGetQuery.cs

using CSI.Data.CRUD;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLGetQuery
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string SqlQuery) Rpt_SLGetQuerySp(string IDOName, string SqlQuery);
    }
}