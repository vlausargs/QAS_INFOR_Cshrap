//PROJECT NAME: Data
//CLASS NAME: DisplayAddressForReportFooter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class DisplayAddressForReportFooter : IDisplayAddressForReportFooter
    {
        readonly IApplicationDB appDB;

        public DisplayAddressForReportFooter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string DisplayAddressForReportFooterFn()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[DisplayAddressForReportFooter]()";

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
