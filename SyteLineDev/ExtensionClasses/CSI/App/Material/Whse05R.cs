//PROJECT NAME: CSIMaterial
//CLASS NAME: Whse05R.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IWhse05R
    {
        DataTable Whse05RSp(WhseType FromWhse,
                            LocType DcLoc1,
                            WhseType ToWhse,
                            LocType ToLoc);
    }

    public class Whse05R : IWhse05R
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Whse05R(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Whse05RSp(WhseType FromWhse,
                                   LocType DcLoc1,
                                   WhseType ToWhse,
                                   LocType ToLoc)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Whse05RSp";

                appDB.AddCommandParameter(cmd, "FromWhse", FromWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DcLoc1", DcLoc1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWhse", ToWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToLoc", ToLoc, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
