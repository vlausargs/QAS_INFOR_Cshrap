//PROJECT NAME: Data
//CLASS NAME: RefFmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{

    public class RefFmt : IRefFmt
    {
        readonly IApplicationDB appDB;


        public RefFmt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string RefFmtSp(string RefType,
        string RefNum,
        int? RefLine,
        int? RefRel)
        {
            UnknownRefTypeType _RefType = RefType;
            EmpJobCoPoRmaProjPsTrnNumType _RefNum = RefNum;
            CoLineType _RefLine = RefLine;
            CoLineType _RefRel = RefRel;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[RefFmtSp](@RefType, @RefNum, @RefLine, @RefRel)";

                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRel", _RefRel, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
