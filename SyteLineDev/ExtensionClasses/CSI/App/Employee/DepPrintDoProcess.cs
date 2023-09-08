//PROJECT NAME: CSIEmployee
//CLASS NAME: DepPrintDoProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IDepPrintDoProcess
    {
        DataTable DepPrintDoProcessSp(DateType pBegTransDate,
                                      DateType pEndTransDate,
                                      AchIdType pAchCoId1,
                                      AchIdType pAchCoId5,
                                      AchNameType pAchOname,
                                      WideTextType pFileName,
                                      FlagNyType pDuplicateTape,
                                      DateType pCreateDate,
                                      DepDtlCreateSeqType pCreateSeq,
                                      ref InfobarType Infobar);
    }

    public class DepPrintDoProcess : IDepPrintDoProcess
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public DepPrintDoProcess(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable DepPrintDoProcessSp(DateType pBegTransDate,
                                             DateType pEndTransDate,
                                             AchIdType pAchCoId1,
                                             AchIdType pAchCoId5,
                                             AchNameType pAchOname,
                                             WideTextType pFileName,
                                             FlagNyType pDuplicateTape,
                                             DateType pCreateDate,
                                             DepDtlCreateSeqType pCreateSeq,
                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DepPrintDoProcessSp";

                appDB.AddCommandParameter(cmd, "pBegTransDate", pBegTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndTransDate", pEndTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pAchCoId1", pAchCoId1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pAchCoId5", pAchCoId5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pAchOname", pAchOname, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pFileName", pFileName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pDuplicateTape", pDuplicateTape, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCreateDate", pCreateDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCreateSeq", pCreateSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
