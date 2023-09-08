//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadCurrencyName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSLoadCurrencyName
    {
        int CHSLoadCurrencyNameSp(CurrCodeType Code,
                                  ref DescriptionType Description,
                                  ref InfobarType InfoBar);
    }

    public class CHSLoadCurrencyName : ICHSLoadCurrencyName
    {
        readonly IApplicationDB appDB;

        public CHSLoadCurrencyName(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSLoadCurrencyNameSp(CurrCodeType Code,
                                         ref DescriptionType Description,
                                         ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSLoadCurrencyNameSp";

                appDB.AddCommandParameter(cmd, "Code", Code, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

