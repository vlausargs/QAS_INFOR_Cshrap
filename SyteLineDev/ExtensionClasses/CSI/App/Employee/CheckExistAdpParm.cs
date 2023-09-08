//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckExistAdpParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICheckExistAdpParm
    {
        int CheckExistAdpParmSp(TokenType UserID,
                                ref AdpVersionType InterfaceVersion,
                                ref JobLaborAllocType JobLaborAlloc,
                                ref OSLocationType InPath,
                                ref OSLocationType InFile,
                                ref OSLocationType OutPath,
                                ref OSLocationType OutFile,
                                ref AdpFileIdType FileId,
                                ref AdpCompanyCodeType CompanyCode,
                                ref OSLocationType LogDir,
                                ref InfobarType Infobar);
    }

    public class CheckExistAdpParm : ICheckExistAdpParm
    {
        readonly IApplicationDB appDB;

        public CheckExistAdpParm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckExistAdpParmSp(TokenType UserID,
                                       ref AdpVersionType InterfaceVersion,
                                       ref JobLaborAllocType JobLaborAlloc,
                                       ref OSLocationType InPath,
                                       ref OSLocationType InFile,
                                       ref OSLocationType OutPath,
                                       ref OSLocationType OutFile,
                                       ref AdpFileIdType FileId,
                                       ref AdpCompanyCodeType CompanyCode,
                                       ref OSLocationType LogDir,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckExistAdpParmSp";

                appDB.AddCommandParameter(cmd, "UserID", UserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InterfaceVersion", InterfaceVersion, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobLaborAlloc", JobLaborAlloc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InPath", InPath, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InFile", InFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutPath", OutPath, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutFile", OutFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FileId", FileId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CompanyCode", CompanyCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LogDir", LogDir, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
