//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_MobileSalesperson.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface ICLM_MobileSalesperson
    {
        DataTable CLM_MobileSalespersonSp(IntType Position);
    }

    public class CLM_MobileSalesperson : ICLM_MobileSalesperson
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;

        public CLM_MobileSalesperson(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_MobileSalespersonSp(IntType Position)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_MobileSalespersonSp";

                    appDB.AddCommandParameter(cmd, "Position", Position, ParameterDirection.Input);

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
