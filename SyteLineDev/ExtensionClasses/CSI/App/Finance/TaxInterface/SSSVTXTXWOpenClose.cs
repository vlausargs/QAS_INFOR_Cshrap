//PROJECT NAME: CSITaxInterface
//CLASS NAME: SSSVTXTXWOpenClose.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.TaxInterface
{
    public interface ISSSVTXTXWOpenClose
    {
        int SSSVTXTXWOpenCloseSp(FlagIeType ProcessFlag,
                                 ref InfobarType InfoBar);
    }

    public class SSSVTXTXWOpenClose : ISSSVTXTXWOpenClose
    {
        readonly IApplicationDB appDB;

        public SSSVTXTXWOpenClose(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSVTXTXWOpenCloseSp(FlagIeType ProcessFlag,
                                        ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSVTXTXWOpenCloseSp";

                appDB.AddCommandParameter(cmd, "ProcessFlag", ProcessFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}