//PROJECT NAME: CSICustomer
//CLASS NAME: GetArParmInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGetArParmInfo
    {
        int GetArParmInfoSp(ref ListYesNoType AllowApplyToInvNumChanges);
    }

    public class GetArParmInfo : IGetArParmInfo
    {
        readonly IApplicationDB appDB;

        public GetArParmInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetArParmInfoSp(ref ListYesNoType AllowApplyToInvNumChanges)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetArParmInfoSp";

                appDB.AddCommandParameter(cmd, "AllowApplyToInvNumChanges", AllowApplyToInvNumChanges, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
