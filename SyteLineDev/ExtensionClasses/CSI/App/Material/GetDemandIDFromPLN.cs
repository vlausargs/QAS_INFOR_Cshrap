//PROJECT NAME: CSIMaterial
//CLASS NAME: GetDemandIDFromPLN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetDemandIDFromPLN
    {
        int GetDemandIDFromPLNSp(RowPointerType PApsPlanRowPtr,
                                 ref RefType PDemandType,
                                 ref OrderRefStrType PDemandRef);
    }

    public class GetDemandIDFromPLN : IGetDemandIDFromPLN
    {
        readonly IApplicationDB appDB;

        public GetDemandIDFromPLN(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetDemandIDFromPLNSp(RowPointerType PApsPlanRowPtr,
                                        ref RefType PDemandType,
                                        ref OrderRefStrType PDemandRef)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetDemandIDFromPLNSp";

                appDB.AddCommandParameter(cmd, "PApsPlanRowPtr", PApsPlanRowPtr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDemandType", PDemandType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDemandRef", PDemandRef, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
