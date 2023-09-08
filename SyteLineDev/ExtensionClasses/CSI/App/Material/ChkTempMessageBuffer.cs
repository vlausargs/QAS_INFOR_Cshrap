//PROJECT NAME: CSIMaterial
//CLASS NAME: ChkTempMessageBuffer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IChkTempMessageBuffer
    {
        int ChkTempMessageBufferSp(RowPointerType PSessionID,
                                   ref IntType Result);
    }

    public class ChkTempMessageBuffer : IChkTempMessageBuffer
    {
        readonly IApplicationDB appDB;

        public ChkTempMessageBuffer(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChkTempMessageBufferSp(RowPointerType PSessionID,
                                          ref IntType Result)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChkTempMessageBufferSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Result", Result, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
