//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessFmCRUD.cs

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

namespace CSI.Production.ProcessManufacturing
{
    public class PmfRptSelectSessFmCRUD : IPmfRptSelectSessFmCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;

        public PmfRptSelectSessFmCRUD(IApplicationDB appDB,
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfRptSelectSessFmSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfRptSelectSessFmSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PmfRptSelectSessFmSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
                tableName: "#tv_ALTGEN",
                loadForChange: true,
                lockingType: LockingType.None,
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

        public ICollectionLoadResponse Pmf_FormulaSelect(Guid? SessionID, int? Seq)
        {
            var pmf_formulaLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"fm.formula_id","fm.formula_id"},
                    {"fm.formula_version","fm.formula_version"},
                    {"fm.revision_num","fm.revision_num"},
                    {"fm.whse","fm.whse"},
                    {"fm.formula_type","fm.formula_type"},
                    {"fm.description","fm.description"},
                    {"cl.mfg_class","cl.mfg_class"},
                    {"scl.mfg_sub_class","scl.mfg_sub_class"},
                    {"fm.route_item","fm.route_item"},
                    {"fm.wip_item","fm.wip_item"},
                    {"fm.total_gross_weight","fm.total_gross_weight"},
                    {"fm.total_gross_volume","fm.total_gross_volume"},
                    {"fm.final_weight","fm.final_weight"},
                    {"fm.final_volume","fm.final_volume"},
                    {"fm.loss_pct","fm.loss_pct"},
                    {"fm.loss_constant","fm.loss_constant"},
                    {"fm.final_density","fm.final_density"},
                    {"fm.RowPointer","fm.RowPointer"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "pmf_formula",
                fromClause: collectionLoadRequestFactory.Clause(" AS fm INNER JOIN pmf_tmp_rpt_formula AS rpt WITH (NOLOCK) ON rpt.pmf_formula_RowPointer = fm.RowPointer INNER JOIN pmf_mfg_class AS cl WITH (NOLOCK) ON cl.RowPointer = fm.pmf_mfg_class_RowPointer LEFT OUTER JOIN pmf_mfg_sub_class AS scl WITH (NOLOCK) ON scl.RowPointer = fm.pmf_mfg_sub_class_RowPointer"),
                whereClause: collectionLoadRequestFactory.Clause("rpt.SessionId = {0} AND rpt.sequence = {1}", SessionID, Seq),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(pmf_formulaLoadRequest);
        }

        public ICollectionLoadResponse Pmf_Tmp_Rpt_FormulaSelect(Guid? SessionID, int? Seq)
        {
            var pmf_tmp_rpt_formulaLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SessionId","SessionId"},
                    {"sequence","sequence"},
                },
                tableName: "pmf_tmp_rpt_formula",
                loadForChange: true,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionId = {0} AND sequence = {1}", SessionID, Seq),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(pmf_tmp_rpt_formulaLoadRequest);
        }

        public void Pmf_Tmp_Rpt_FormulaDelete(ICollectionLoadResponse pmf_tmp_rpt_formulaLoadResponse)
        {
            var pmf_tmp_rpt_formulaDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "pmf_tmp_rpt_formula",
                items: pmf_tmp_rpt_formulaLoadResponse.Items);
            this.appDB.Delete(pmf_tmp_rpt_formulaDeleteRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_PmfRptSelectSessFmSp(
            string AltExtGenSp,
            Guid? SessionID,
            int? Seq,
            int? ClearSession = 0)
        {
            RowPointerType _SessionID = SessionID;
            IntType _Seq = Seq;
            IntType _ClearSession = ClearSession;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ClearSession", _ClearSession, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }

    }
}
