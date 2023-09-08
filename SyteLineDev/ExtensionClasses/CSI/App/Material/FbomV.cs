//PROJECT NAME: CSIMaterial
//CLASS NAME: FbomV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IFbomV
    {
        DataTable FbomVSp(ItemType FromItem,
                          ItemType ToItem,
                          ref InfobarType Infobar);
    }

    public class FbomV : IFbomV
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public FbomV(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable FbomVSp(ItemType FromItem,
                                 ItemType ToItem,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "FbomVSp";

                appDB.AddCommandParameter(cmd, "FromItem", FromItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToItem", ToItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
