//PROJECT NAME: CSICodes
//CLASS NAME: GetWcompIndustryClassification.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetWcompIndustryClassification
    {
        int GetWcompIndustryClassificationSp(ref WorkersCompensationIndustryClassificationType WcompIndustryClassification,
                                             ref InfobarType Infobar);
    }

    public class GetWcompIndustryClassification : IGetWcompIndustryClassification
    {
        readonly IApplicationDB appDB;

        public GetWcompIndustryClassification(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetWcompIndustryClassificationSp(ref WorkersCompensationIndustryClassificationType WcompIndustryClassification,
                                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetWcompIndustryClassificationSp";

                appDB.AddCommandParameter(cmd, "WcompIndustryClassification", WcompIndustryClassification, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
