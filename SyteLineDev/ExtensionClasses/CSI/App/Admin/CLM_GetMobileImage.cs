//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_GetMobileImage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface ICLM_GetMobileImage
    {
        DataTable CLM_GetMobileImageSp(IntType Position,
                                       StringType HomePage);
    }

    public class CLM_GetMobileImage : ICLM_GetMobileImage
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;

        public CLM_GetMobileImage(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_GetMobileImageSp(IntType Position,
                                              StringType HomePage)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_GetMobileImageSp";

                    appDB.AddCommandParameter(cmd, "Position", Position, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "HomePage", HomePage, ParameterDirection.Input);

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
