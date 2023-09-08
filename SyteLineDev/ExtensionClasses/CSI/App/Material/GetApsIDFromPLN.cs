//PROJECT NAME: CSIMaterial
//CLASS NAME: GetApsIDFromPLN.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetApsIDFromPLN
    {
        int GetApsIDFromPLNSp(RowPointerType PApsPlanRowPtr,
                              ref ApsOrderType PApsOrderID);

        string GetApsIDFromPLNFn(
            Guid? pApsPlanRowPtr);
    }

    public class GetApsIDFromPLN : IGetApsIDFromPLN
    {
        readonly IApplicationDB appDB;

        public GetApsIDFromPLN(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetApsIDFromPLNSp(RowPointerType PApsPlanRowPtr,
                                     ref ApsOrderType PApsOrderID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetApsIDFromPLNSp";

                appDB.AddCommandParameter(cmd, "PApsPlanRowPtr", PApsPlanRowPtr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderID", PApsOrderID, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
        public string GetApsIDFromPLNFn(
            Guid? pApsPlanRowPtr)
        {
            RowPointerType _pApsPlanRowPtr = pApsPlanRowPtr;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetApsIDFromPLN](@pApsPlanRowPtr)";

                appDB.AddCommandParameter(cmd, "pApsPlanRowPtr", _pApsPlanRowPtr, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }

    }
}
