//PROJECT NAME: CSICustomer
//CLASS NAME: ConInvStdFormPreDisp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IConInvStdFormPreDisp
    {
        int ConInvStdFormPreDispSp(TokenType Userid,
                                   FlagNyType DispMsg,
                                   SiteType Site,
                                   ref ListYesNoType FRCP,
                                   ref FlagNyType IsUserInReprintGroup,
                                   ref IntType Result,
                                   ref FlagNyType PEuroUser,
                                   ref FlagNyType PEuroExists,
                                   ref FlagNyType PBaseEuro,
                                   ref CurrCodeType PEuroCurr,
                                   ref InfobarType InfoBar);
    }

    public class ConInvStdFormPreDisp : IConInvStdFormPreDisp
    {
        readonly IApplicationDB appDB;

        public ConInvStdFormPreDisp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ConInvStdFormPreDispSp(TokenType Userid,
                                          FlagNyType DispMsg,
                                          SiteType Site,
                                          ref ListYesNoType FRCP,
                                          ref FlagNyType IsUserInReprintGroup,
                                          ref IntType Result,
                                          ref FlagNyType PEuroUser,
                                          ref FlagNyType PEuroExists,
                                          ref FlagNyType PBaseEuro,
                                          ref CurrCodeType PEuroCurr,
                                          ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ConInvStdFormPreDispSp";

                appDB.AddCommandParameter(cmd, "Userid", Userid, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DispMsg", DispMsg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FRCP", FRCP, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IsUserInReprintGroup", IsUserInReprintGroup, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Result", Result, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEuroUser", PEuroUser, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEuroExists", PEuroExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PBaseEuro", PBaseEuro, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PEuroCurr", PEuroCurr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
