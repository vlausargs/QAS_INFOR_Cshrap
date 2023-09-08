//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemValMix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public interface IRpt_ItemValMix
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemValMixSp(string PProdMix = null,
        int? PPrintOperText = 1,
        int? PPageBtwOper = 0,
        int? PPrintMatlText = 1,
        int? PDisRefFields = 0,
        int? PDisEffDate = 0,
        DateTime? PEffectDate = null,
        int? ShowInternal = 0,
        int? ShowExternal = 0,
        int? DisplayHeader = 0,
        string Infobar = null,
        string BGSessionId = null,
        string pSite = null,
        string BGUser = null);
    }

    public class Rpt_ItemValMix : IRpt_ItemValMix
    {
        IApplicationDB appDB;
        IBunchedLoadCollection bunchedLoadCollection;
        IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public Rpt_ItemValMix(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemValMixSp(string PProdMix = null,
        int? PPrintOperText = 1,
        int? PPageBtwOper = 0,
        int? PPrintMatlText = 1,
        int? PDisRefFields = 0,
        int? PDisEffDate = 0,
        DateTime? PEffectDate = null,
        int? ShowInternal = 0,
        int? ShowExternal = 0,
        int? DisplayHeader = 0,
        string Infobar = null,
        string BGSessionId = null,
        string pSite = null,
        string BGUser = null)
        {
            ProdMixType _PProdMix = PProdMix;
            ListYesNoType _PPrintOperText = PPrintOperText;
            ListYesNoType _PPageBtwOper = PPageBtwOper;
            ListYesNoType _PPrintMatlText = PPrintMatlText;
            ListYesNoType _PDisRefFields = PDisRefFields;
            ListYesNoType _PDisEffDate = PDisEffDate;
            DateType _PEffectDate = PEffectDate;
            FlagNyType _ShowInternal = ShowInternal;
            FlagNyType _ShowExternal = ShowExternal;
            FlagNyType _DisplayHeader = DisplayHeader;
            Infobar _Infobar = Infobar;
            StringType _BGSessionId = BGSessionId;
            SiteType _pSite = pSite;
            UsernameType _BGUser = BGUser;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_ItemValMixSp";

                appDB.AddCommandParameter(cmd, "PProdMix", _PProdMix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrintOperText", _PPrintOperText, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPageBtwOper", _PPageBtwOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrintMatlText", _PPrintMatlText, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDisRefFields", _PDisRefFields, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDisEffDate", _PDisEffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEffectDate", _PEffectDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
