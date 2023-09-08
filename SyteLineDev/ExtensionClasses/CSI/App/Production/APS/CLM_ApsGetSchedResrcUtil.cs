//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetSchedResrcUtil.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetSchedResrcUtil
    {
        DataTable CLM_ApsGetSchedResrcUtilSp(ApsAltNoType AltNum,
                                             DateType StartDate,
                                             IntType IntervalCount,
                                             IntType IntervalType,
                                             DecimalType Threshold,
                                             ApsResourceType ResrcID,
                                             ListYesNoType ExcludeInfinite,
                                             StringType WildCardChar,
                                             LongListType FilterString);
    }

    public class CLM_ApsGetSchedResrcUtil : ICLM_ApsGetSchedResrcUtil
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ApsGetSchedResrcUtil(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ApsGetSchedResrcUtilSp(ApsAltNoType AltNum,
                                                    DateType StartDate,
                                                    IntType IntervalCount,
                                                    IntType IntervalType,
                                                    DecimalType Threshold,
                                                    ApsResourceType ResrcID,
                                                    ListYesNoType ExcludeInfinite,
                                                    StringType WildCardChar,
                                                    LongListType FilterString)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ApsGetSchedResrcUtilSp";

                    appDB.AddCommandParameter(cmd, "AltNum", AltNum, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "StartDate", StartDate, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "IntervalCount", IntervalCount, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "IntervalType", IntervalType, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "Threshold", Threshold, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ResrcID", ResrcID, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExcludeInfinite", ExcludeInfinite, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "WildCardChar", WildCardChar, ParameterDirection.Input);
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
