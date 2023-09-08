//PROJECT NAME: Admin
//CLASS NAME: PreSitePurge.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Admin
{
    public class PreSitePurge : IPreSitePurge
    {
        readonly IApplicationDB appDB;

        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;


        public PreSitePurge(IApplicationDB appDB,
        ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
        ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
        ICollectionInsertRequestFactory collectionInsertRequestFactory,
        ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
        ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
        ICollectionLoadRequestFactory collectionLoadRequestFactory,
        ICollectionLoadResponseUtil collectionLoadResponseUtil,
        ISQLExpressionExecutor sQLExpressionExecutor,
        IScalarFunction scalarFunction,
        IExistsChecker existsChecker,
        IVariableUtil variableUtil,
        IStringUtil stringUtil,
        ISQLValueComparerUtil sQLUtil,
        IMsgApp iMsgApp)
        {
            this.appDB = appDB;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
        }

        public (int? ReturnCode,
        string Infobar) PreSitePurgeSp(string DeleteSite,
        int? IsRetry = 0,
        string NotificationEmail = null,
        string Infobar = null)
        {
            int? IsOnCloud = null;
            int? IsForcePurgeOn = null;
            OSLocationType _APPDBName = DBNull.Value;
            string APPDBName = null;
            ESBTenantIDType _TenantID = DBNull.Value;
            string TenantID = null;
            string FeatureID = null;
            int? Severity = null;
            int? SkipValidator = null;
            IsOnCloud = 0;
            IsForcePurgeOn = 0;
            SkipValidator = 0;

            if (DeleteSite == null || DeleteSite == "")
            {  
                var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
                    , BaseMsg: "E=IsRequired"
                    , Parm1: "@site");
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar; 

                return (Severity, Infobar); 
            }

            #region CRUD LoadToVariable
            var SITELoadRequest = collectionLoadRequestFactory.SQLLoad(
                    columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>(){{_APPDBName,$"app_db_name"},{_TenantID,$"TenantID"},},
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "SITE",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("site = {0}", DeleteSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
            var SITELoadResponse = this.appDB.Load(SITELoadRequest);
            if (SITELoadResponse.Items.Count > 0)
            {
                APPDBName = _APPDBName;
                TenantID = _TenantID;
            }
            #endregion  LoadToVariable

            if (IsOnCloud == 1 && TenantID != null && TenantID != "")
            {
                FeatureID = stringUtil.Concat("RS8799_", TenantID);
            }
            else if (IsOnCloud != 0 && APPDBName != null && APPDBName != "")
            {
               FeatureID = stringUtil.Concat("RS8799_", APPDBName);
            } 

            if (existsChecker.Exists(
                    tableName: "AppFeature_mst",  
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("SiteRef = {0} AND Active = 1 AND FeatureId = {1}", DeleteSite, FeatureID)))
            {
                IsForcePurgeOn = 1;
            }

            if ((existsChecker.Exists(
                        tableName: "item_mst",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", DeleteSite)) 
                || existsChecker.Exists(
                        tableName: "customer_mst",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", DeleteSite))
                || existsChecker.Exists(
                        tableName: "chart_mst",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", DeleteSite))
                || existsChecker.Exists(
                        tableName: "vendor_mst",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", DeleteSite))) && sQLUtil.SQLEqual(IsForcePurgeOn, 0) == true && sQLUtil.SQLEqual(SkipValidator, 0) == true)
            {
                #region CRUD ExecuteMethodCall
                var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                                        , BaseMsg: "E=CannotBeAtLeastOneExist"
                                        , Parm1: "@site"
                                        , Parm2: "@deleted"
                                        , Parm3: "@!Transactions"
                                        , Parm4: "@site"
                                        , Parm5: DeleteSite);
                                        Infobar = MsgApp1.Infobar;
                #endregion ExecuteMethodCall
                return (Severity = 16, Infobar);
            }

            if ((existsChecker.Exists(
                        tableName: "site",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("reports_to_site = {0}", DeleteSite)) 
               || existsChecker.Exists(
                        tableName: "site",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("site = {0} AND reports_to_site IS NOT NULL", DeleteSite))) && sQLUtil.SQLEqual(SkipValidator, 0) == true)
            {
                //BEGIN
                #region CRUD ExecuteMethodCall

                var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                    , BaseMsg: "E=CannotExistReportsToSiteOrEntity"
                    , Parm1: DeleteSite);
                    Infobar = MsgApp2.Infobar;

                #endregion ExecuteMethodCall
                return (Severity = 16, Infobar);
                //END
            }

            if (IsRetry == 0)
            {
                //BEGIN
                if (existsChecker.Exists(tableName: "tmp_site_mgmt_data",
                                            fromClause: collectionLoadRequestFactory.Clause(""),
                                            whereClause: collectionLoadRequestFactory.Clause("site = {0} AND action = 'D' AND status = 'I'", DeleteSite))
                                            && SkipValidator == 0)
                {
                    var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                                                        , BaseMsg: "E=NoAddDeletingSiteInProcess"
                                                        , Parm1: DeleteSite);
                    Infobar = MsgApp3.Infobar;
                    return (Severity = 16, Infobar);
                }
                
                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                {   { "site", DeleteSite},
                    { "action", "D"},
                    { "notification_email_addr", NotificationEmail},
                    { "status", "I"},
                });

                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "tmp_site_mgmt_data",
                items: nonTableLoadResponse.Items);

                this.appDB.Insert(nonTableInsertRequest);


                //  Insert into tmp_site_mgmt_table for 
                var tmp_site_mgmt_tableLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"site",$"{variableUtil.GetQuotedValue<string>(DeleteSite)}"},
                        {"table_name","ist.table_name"},
                        {"status","'P'"},
                    },
                    selectStatement: collectionLoadRequestFactory.Clause(@"SELECT Distinct @selectList
                           FROM INFORMATION_SCHEMA.columns isc
                           INNER JOIN INFORMATION_SCHEMA.tables ist
                              ON ist.table_name = isc.table_name
                           WHERE ist.TABLE_TYPE = N'Base Table'
                              AND isc.DOMAIN_NAME LIKE N'SiteType'
                              AND ist.table_name NOT IN ('tmp_site_mgmt_table_data','tmp_site_mgmt_data')"));

                var tmp_site_mgmt_tableLoadResponse = appDB.Load(tmp_site_mgmt_tableLoadRequest); 

                var tmp_site_mgmt_tableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "tmp_site_mgmt_table_data",
                    items: tmp_site_mgmt_tableLoadResponse.Items);

                appDB.Insert(tmp_site_mgmt_tableInsertRequest);
            }
            else
            {
                #region CRUD LoadToRecord
                var tmp_site_mgmt_data1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                {"status","tmp_site_mgmt_data.status"},
                },
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "tmp_site_mgmt_data",
                fromClause: collectionLoadRequestFactory.Clause(""),
                 whereClause: collectionLoadRequestFactory.Clause("site = {0} AND action = 'D' AND status = 'F'", DeleteSite),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var tmp_site_mgmt_data1LoadResponse = this.appDB.Load(tmp_site_mgmt_data1LoadRequest);
                #endregion  LoadToRecord


                #region CRUD UpdateByRecord
                foreach (var tmp_site_mgmt_data1Item in tmp_site_mgmt_data1LoadResponse.Items)
                {
                    tmp_site_mgmt_data1Item.SetValue<string>("status", "I");
                };

                var tmp_site_mgmt_data1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_site_mgmt_data",
                items: tmp_site_mgmt_data1LoadResponse.Items);

                this.appDB.Update(tmp_site_mgmt_data1RequestUpdate);
                #endregion UpdateByRecord
                 
                #region CRUD LoadToRecord
                var tmp_site_mgmt_table_data1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                {"status","tmp_site_mgmt_table_data.status"},
                {"error_msg","tmp_site_mgmt_table_data.error_msg"},
                },
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName: "tmp_site_mgmt_table_data",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("site = {0}", DeleteSite),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var tmp_site_mgmt_table_data1LoadResponse = this.appDB.Load(tmp_site_mgmt_table_data1LoadRequest);
                #endregion  LoadToRecord
                 
                #region CRUD UpdateByRecord
                foreach (var tmp_site_mgmt_table_data1Item in tmp_site_mgmt_table_data1LoadResponse.Items)
                {
                    tmp_site_mgmt_table_data1Item.SetValue<string>("status", "P");
                    tmp_site_mgmt_table_data1Item.SetValue("error_msg", null);
                };

                var tmp_site_mgmt_table_data1RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_site_mgmt_table_data",
                items: tmp_site_mgmt_table_data1LoadResponse.Items);

                this.appDB.Update(tmp_site_mgmt_table_data1RequestUpdate);
                #endregion UpdateByRecord
            }

            return (Severity, Infobar);
        }

    }
}
