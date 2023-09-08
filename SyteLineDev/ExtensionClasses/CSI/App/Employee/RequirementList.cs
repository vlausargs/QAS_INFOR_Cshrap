//PROJECT NAME: CSIEmployee
//CLASS NAME: RequirementList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IRequirementList
    {
        DataTable RequirementListSp(PosReqTypeType ReqType);
    }

    public class RequirementList : IRequirementList
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public RequirementList(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable RequirementListSp(PosReqTypeType ReqType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RequirementListSp";

                appDB.AddCommandParameter(cmd, "ReqType", ReqType, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
