//PROJECT NAME: Logistics
//CLASS NAME: AptrxVerifyInvNumCRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;
using System.Linq;

namespace CSI.Logistics.Vendor
{
    public class AptrxVerifyInvNumCRUD : IAptrxVerifyInvNumCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;

        public AptrxVerifyInvNumCRUD(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AptrxVerifyInvNumSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public ICollectionLoadResponse Optional_Module1Select()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AptrxVerifyInvNumSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("AptrxVerifyInvNumSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            return optional_module1LoadResponse;
        }

        public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
        {
            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
        {
            StringType _ALTGEN_SpName = DBNull.Value;

            var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ALTGEN_SpName,"[SpName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
            if (tv_ALTGEN1LoadResponse.Items.Count > 0)
            {
                ALTGEN_SpName = _ALTGEN_SpName;
            }

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
        }

        public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
        {
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                loadForChange: true,
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public ICollectionLoadResponse SitesSelect()
        {
            var SitesLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"site","site"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "site_group",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("site_group = (SELECT site_group FROM apparms WITH (READUNCOMMITTED))"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(SitesLoadRequest);
        }



        //  public void SitesInsert(ICollectionLoadResponse SitesLoadResponse)
        //  {
        //   var SitesInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_Sites",
        //         items: SitesLoadResponse.Items);

        //     this.appDB.Insert(SitesInsertRequest);
        //   }



        public (string SiteRef, int? Voucher, int? rowCount) Aptrxp_AllLoad(string PVendNum, string PInvNum, string SiteRef, int? Voucher, IList<string> SiteGroupVar)
        {
            SiteType _SiteRef = DBNull.Value;
            VoucherType _Voucher = DBNull.Value;
            string SiteGroup = String.Join(", ", SiteGroupVar.Select(t => "'" + t + "'"));

            var aptrxp_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SiteRef,"site_ref"},
                    {_Voucher,"voucher"},

                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "aptrxp_all",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("aptrxp_all.vend_num = {0} AND aptrxp_all.inv_num = {1} AND aptrxp_all.site_ref IN ("+ SiteGroup + ")", PVendNum, PInvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var aptrxp_allLoadResponse = this.appDB.Load(aptrxp_allLoadRequest);
            if (aptrxp_allLoadResponse.Items.Count > 0)
            {
                SiteRef = _SiteRef;
                Voucher = _Voucher;
            }

            int rowCount = aptrxp_allLoadResponse.Items.Count;
            return (SiteRef, Voucher, rowCount);
        }

        public (string SiteRef, int? Voucher, int? rowCount) Aptrx_AllLoad(string PVendNum, string PInvNum, string SiteRef, int? Voucher, IList<string> siteGroupVar)
        {
            SiteType _SiteRef = DBNull.Value;
            VoucherType _Voucher = DBNull.Value;
            string SiteGroup = String.Join(", ", siteGroupVar.Select(t => "'" + t + "'"));

            var aptrx_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SiteRef,"site_ref"},
                    {_Voucher,"voucher"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "aptrx_all",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("aptrx_all.vend_num = {0} AND aptrx_all.inv_num = {1} AND aptrx_all.site_ref IN ("+SiteGroup+")", PVendNum, PInvNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var aptrx_allLoadResponse = this.appDB.Load(aptrx_allLoadRequest);
            if (aptrx_allLoadResponse.Items.Count > 0)
            {
                SiteRef = _SiteRef;
                Voucher = _Voucher;
            }

            int rowCount = aptrx_allLoadResponse.Items.Count;
            return (SiteRef, Voucher, rowCount);
        }

        public (int? ReturnCode,
            string Infobar)
        AltExtGen_AptrxVerifyInvNumSp(
            string AltExtGenSp,
            string PVendNum,
            string PInvNum,
            string Infobar)
        {
            VendNumType _PVendNum = PVendNum;
            VendInvNumType _PInvNum = PInvNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }

    }
}
