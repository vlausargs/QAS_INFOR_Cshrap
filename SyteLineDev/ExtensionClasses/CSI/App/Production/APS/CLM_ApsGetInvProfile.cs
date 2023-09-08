//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetInvProfile.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetInvProfile
    {
        DataTable CLM_ApsGetInvProfileSp(ApsAltNoType PAltNo,
                                         ApsMaterialType PItem,
                                         DateType PStartDate,
                                         DateType PEndDate,
                                         ListYesNoType PFcstAsRqmtFg,
                                         LongListType FilterString);
    }

    public class CLM_ApsGetInvProfile : ICLM_ApsGetInvProfile
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ApsGetInvProfile(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ApsGetInvProfileSp(ApsAltNoType PAltNo,
                                                ApsMaterialType PItem,
                                                DateType PStartDate,
                                                DateType PEndDate,
                                                ListYesNoType PFcstAsRqmtFg,
                                                LongListType FilterString)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ApsGetInvProfileSp";

                    appDB.AddCommandParameter(cmd, "PAltNo", PAltNo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PStartDate", PStartDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PEndDate", PEndDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "PFcstAsRqmtFg", PFcstAsRqmtFg, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "FilterString", FilterString, ParameterDirection.Input);

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
