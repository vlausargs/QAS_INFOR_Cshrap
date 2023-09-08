//PROJECT NAME: CSIAdmin
//CLASS NAME: GetAdpParmInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IGetAdpParmInfo
    {
        int GetAdpParmInfoSp(TokenType UserId,
                             ref OSLocationType OutFile,
                             ref OSLocationType OutProg,
                             ref AdpCompanyCodeType CompanyCode,
                             ref OSLocationType InPath,
                             ref OSLocationType InFile,
                             ref OSLocationType LogDir,
                             ref AdpVersionType InterfaceVersion,
                             ref ListYesNoType AppendSiteOntoInFile,
                             ref OSLocationType ErrorLogFile,
                             ref AcctType BalanceAcct,
                             ref UnitCode1Type BalanceAcctUnit1,
                             ref UnitCode2Type BalanceAcctUnit2,
                             ref UnitCode3Type BalanceAcctUnit3,
                             ref UnitCode4Type BalanceAcctUnit4,
                             ref DescriptionType InterfaceVersionDesc,
                             ref DescriptionType BalanceAcctDesc,
                             ref SiteType Site,
                             ref FinPeriodType CurPer);
    }

    public class GetAdpParmInfo : IGetAdpParmInfo
    {
        IApplicationDB appDB;

        public GetAdpParmInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetAdpParmInfoSp(TokenType UserId,
                                    ref OSLocationType OutFile,
                                    ref OSLocationType OutProg,
                                    ref AdpCompanyCodeType CompanyCode,
                                    ref OSLocationType InPath,
                                    ref OSLocationType InFile,
                                    ref OSLocationType LogDir,
                                    ref AdpVersionType InterfaceVersion,
                                    ref ListYesNoType AppendSiteOntoInFile,
                                    ref OSLocationType ErrorLogFile,
                                    ref AcctType BalanceAcct,
                                    ref UnitCode1Type BalanceAcctUnit1,
                                    ref UnitCode2Type BalanceAcctUnit2,
                                    ref UnitCode3Type BalanceAcctUnit3,
                                    ref UnitCode4Type BalanceAcctUnit4,
                                    ref DescriptionType InterfaceVersionDesc,
                                    ref DescriptionType BalanceAcctDesc,
                                    ref SiteType Site,
                                    ref FinPeriodType CurPer)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAdpParmInfoSp";

                appDB.AddCommandParameter(cmd, "UserId", UserId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutFile", OutFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutProg", OutProg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CompanyCode", CompanyCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InPath", InPath, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InFile", InFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LogDir", LogDir, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InterfaceVersion", InterfaceVersion, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AppendSiteOntoInFile", AppendSiteOntoInFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ErrorLogFile", ErrorLogFile, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcct", BalanceAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcctUnit1", BalanceAcctUnit1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcctUnit2", BalanceAcctUnit2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcctUnit3", BalanceAcctUnit3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcctUnit4", BalanceAcctUnit4, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InterfaceVersionDesc", InterfaceVersionDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalanceAcctDesc", BalanceAcctDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurPer", CurPer, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
