//PROJECT NAME: CSICustomer
//CLASS NAME: GetReportTemplateParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IGetReportTemplateParm
    {
        int GetReportTemplateParmSp(TableNameType pTable,
                                    LongListType pColumn,
                                    ref ReportTemplateIdType ReportTemplateID);
    }

    public class GetReportTemplateParm : IGetReportTemplateParm
    {
        readonly IApplicationDB appDB;

        public GetReportTemplateParm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetReportTemplateParmSp(TableNameType pTable,
                                           LongListType pColumn,
                                           ref ReportTemplateIdType ReportTemplateID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetReportTemplateParmSp";

                appDB.AddCommandParameter(cmd, "pTable", pTable, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pColumn", pColumn, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReportTemplateID", ReportTemplateID, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
