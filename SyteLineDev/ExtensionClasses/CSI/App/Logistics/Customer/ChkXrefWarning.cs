//PROJECT NAME: CSICustomer
//CLASS NAME: ChkXrefWarning.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IChkXrefWarning
    {
        int ChkXrefWarningSp(CoNumType CoNum,
                             CoLineType CoLine,
                             CoLineType CoRelease,
                             UnknownRefTypeType NewRefType,
                             AnyRefNumType NewRefNum,
                             CoLineType NewRefLineSuf,
                             CoLineType NewRefRel,
                             ref Infobar WarningMsg);
    }

    public class ChkXrefWarning : IChkXrefWarning
    {
        readonly IApplicationDB appDB;

        public ChkXrefWarning(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChkXrefWarningSp(CoNumType CoNum,
                                    CoLineType CoLine,
                                    CoLineType CoRelease,
                                    UnknownRefTypeType NewRefType,
                                    AnyRefNumType NewRefNum,
                                    CoLineType NewRefLineSuf,
                                    CoLineType NewRefRel,
                                    ref Infobar WarningMsg)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChkXrefWarningSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewRefType", NewRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewRefNum", NewRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewRefLineSuf", NewRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewRefRel", NewRefRel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WarningMsg", WarningMsg, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
