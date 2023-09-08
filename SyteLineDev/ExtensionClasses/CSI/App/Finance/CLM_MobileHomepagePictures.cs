//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_MobileHomepagePictures.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface ICLM_MobileHomepagePictures
    {
        DataTable CLM_MobileHomepagePicturesSp(IntType Position,
                                               FormNameType MobileHomepage);
    }

    public class CLM_MobileHomepagePictures : ICLM_MobileHomepagePictures
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_MobileHomepagePictures(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_MobileHomepagePicturesSp(IntType Position,
                                                      FormNameType MobileHomepage)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_MobileHomepagePicturesSp";

                    appDB.AddCommandParameter(cmd, "Position", Position, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "MobileHomepage", MobileHomepage, ParameterDirection.Input);

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
