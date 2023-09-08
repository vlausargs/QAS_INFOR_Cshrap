//PROJECT NAME: CSIEmployee
//CLASS NAME: DepPrintInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IDepPrintInit
    {
        int DepPrintInitSp(ref DateType pBegTransDate,
                           ref DateType pEndTransDate,
                           ref AchIdType pAchCoId1,
                           ref AchIdType pAchCoId5,
                           ref AchNameType pAchOname,
                           ref WideTextType pFileName,
                           ref FlagNyType pDuplicateTape,
                           ref DateType pCreateDate,
                           ref DepDtlCreateSeqType pCreateSeq,
                           ref InfobarType Infobar);
    }

    public class DepPrintInit : IDepPrintInit
    {
        readonly IApplicationDB appDB;

        public DepPrintInit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DepPrintInitSp(ref DateType pBegTransDate,
                                  ref DateType pEndTransDate,
                                  ref AchIdType pAchCoId1,
                                  ref AchIdType pAchCoId5,
                                  ref AchNameType pAchOname,
                                  ref WideTextType pFileName,
                                  ref FlagNyType pDuplicateTape,
                                  ref DateType pCreateDate,
                                  ref DepDtlCreateSeqType pCreateSeq,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DepPrintInitSp";

                appDB.AddCommandParameter(cmd, "pBegTransDate", pBegTransDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pEndTransDate", pEndTransDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAchCoId1", pAchCoId1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAchCoId5", pAchCoId5, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pAchOname", pAchOname, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pFileName", pFileName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDuplicateTape", pDuplicateTape, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pCreateDate", pCreateDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pCreateSeq", pCreateSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
