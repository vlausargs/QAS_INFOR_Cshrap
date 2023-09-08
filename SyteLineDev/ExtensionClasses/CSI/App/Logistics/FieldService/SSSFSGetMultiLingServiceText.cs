//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSGetMultiLingServiceText.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSGetMultiLingServiceText
    {
        int SSSFSGetMultiLingServiceTextSp(ref ReportTxtType IncText1,
                                           ref ReportTxtType IncText2,
                                           ref ReportTxtType IncText3,
                                           ref Infobar Infobar);
    }

    public class SSSFSGetMultiLingServiceText : ISSSFSGetMultiLingServiceText
    {
        readonly IApplicationDB appDB;

        public SSSFSGetMultiLingServiceText(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSGetMultiLingServiceTextSp(ref ReportTxtType IncText1,
                                                  ref ReportTxtType IncText2,
                                                  ref ReportTxtType IncText3,
                                                  ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSGetMultiLingServiceTextSp";

                appDB.AddCommandParameter(cmd, "IncText1", IncText1, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IncText2", IncText2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "IncText3", IncText3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
