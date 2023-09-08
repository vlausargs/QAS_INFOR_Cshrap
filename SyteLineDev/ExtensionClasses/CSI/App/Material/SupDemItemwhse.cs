//PROJECT NAME: CSIMaterial
//CLASS NAME: SupDemItemwhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISupDemItemwhse
    {
        DataTable SupDemItemwhseSp(WhseType Whse,
                                   LongListType Filter);
    }

    public class SupDemItemwhse : ISupDemItemwhse
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SupDemItemwhse(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SupDemItemwhseSp(WhseType Whse,
                                          LongListType Filter)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SupDemItemwhseSp";

                    appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Filter", Filter, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
