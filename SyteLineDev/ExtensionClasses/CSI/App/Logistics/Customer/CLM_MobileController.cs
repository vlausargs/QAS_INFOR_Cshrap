//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_MobileController.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_MobileController
    {
        DataTable CLM_MobileControllerSp(int? Position);
    }

    public class CLM_MobileController : ICLM_MobileController
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_MobileController(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_MobileControllerSp(int? Position)
        {
            IntType _Position = Position;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLM_MobileControllerSp";

                appDB.AddCommandParameter(cmd, "Position", _Position, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
