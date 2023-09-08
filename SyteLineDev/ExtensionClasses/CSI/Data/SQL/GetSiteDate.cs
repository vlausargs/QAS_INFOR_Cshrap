//PROJECT NAME: Data
//CLASS NAME: GetSiteDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class GetSiteDate : IGetSiteDate
    {
        IApplicationDB appDB;


        public GetSiteDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public DateTime? GetSiteDateFn(DateTime? Date)
        {
            CurrentDateType _Date = Date;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetSiteDate](@Date)";

                appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<DateTime?>(cmd);

                return Output;
            }
        }
    }
}
