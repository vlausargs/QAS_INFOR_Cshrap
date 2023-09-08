//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetDelays.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetDelays
    {
        DataTable CLM_ApsGetDelaysSp(IntType AltNo,
                                     RefType DemandType,
                                     OrderRefStrType DemandRef,
                                     ListYesNoType CriticalPathOnly,
                                     ListYesNoType ShowItemDelays,
                                     ListYesNoType ShowGroupDelays,
                                     ListYesNoType ExcludeInfinite,
                                     LongListType FilterString);
    }

    public class CLM_ApsGetDelays : ICLM_ApsGetDelays
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ApsGetDelays(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ApsGetDelaysSp(IntType AltNo,
                                            RefType DemandType,
                                            OrderRefStrType DemandRef,
                                            ListYesNoType CriticalPathOnly,
                                            ListYesNoType ShowItemDelays,
                                            ListYesNoType ShowGroupDelays,
                                            ListYesNoType ExcludeInfinite,
                                            LongListType FilterString)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ApsGetDelaysSp";

                    appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "DemandType", DemandType, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "DemandRef", DemandRef, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "CriticalPathOnly", CriticalPathOnly, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ShowItemDelays", ShowItemDelays, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ShowGroupDelays", ShowGroupDelays, ParameterDirection.Input);
                    appDB.AddCommandParameter(cmd, "ExcludeInfinite", ExcludeInfinite, ParameterDirection.Input);
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
