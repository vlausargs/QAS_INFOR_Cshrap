//PROJECT NAME: Production
//CLASS NAME: CLM_InvMsNomCRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class CLM_InvMsNomCRUD : ICLM_InvMsNomCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;

		public CLM_InvMsNomCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
		}


		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_InvMsNomSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_InvMsNomSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
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

		public string Tv_ALTGEN1Load(string ALTGEN_SpName)
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

			return ALTGEN_SpName;
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

		public ICollectionLoadResponse DynamicparametersSelect(string SelectionClause, string FromClause, string WhereStr, string Filter)
		{
			var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
					{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
					{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereStr)}"},
					{"AdditionalClause","N'ORDER BY proj_num, inv_ms_num'"},
					{"KeyColumns","N'proj_num, inv_ms_num'"},
					{"FilterString",$"{variableUtil.GetQuotedValue<string>(Filter)}"},
				},
				selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

			return this.appDB.Load(DynamicParametersLoadRequest);
		}

		public void DynamicparametersInsert(ICollectionLoadResponse DynamicParametersLoadResponse)
		{
			var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
				items: DynamicParametersLoadResponse.Items);

			this.appDB.Insert(DynamicParametersInsertRequest);
		}

		public void Invmsnom1Insert(ICollectionLoadResponse InvMsNom1ExecResultLoadResponse)
		{
			var InvMsNom1LoadResponse = collectionLoadResponseUtil.CloneCollectionRenameColumns(InvMsNom1ExecResultLoadResponse,
				new List<string>() { "proj_num",
						"inv_ms_num",
						"description",
						"plan_inv_amt",
						"act_inv_amt",
						"nominated",
						"plan_date",
						"act_date",
						"tax_code1",
						"tax_code2",
						"tax_code_description1",
						"tax_code_description2",
						"taxable_amt",
						"create_invoice_for_adv_pmt",
						"adv_pmt_deduction_amt",
						"InWorkFlow",
						"NoteExistsFlag",
						"DerCurrentPeriod",
						"DerCurrentPeriodStart",
						"DerCurrentPeriodEnd",
						"DerTotPerPlanInvAmt",
						"DerTotPerNomPlanInvAmt",
						"DerTotYrPlanInvAmt",
						"DerTotYrNomPlanInvAmt",
						"DerTotPerActInvAmt",
						"DerTotPerNomActInvAmt",
						"DerTotYrActInvAmt",
						"DerTotYrNomActInvAmt",
						"DerNominated",
						"DerActInvAmt",
						"DerActDate",
						"ProjFixedRate",
						"ProjExchRate",
						"Cad0CurrCode",
						"CurrAmtFormat",
						"CurrAmtTotFormat",
						"plan_freight",
						"act_freight",
						"plan_misc_charges",
						"act_misc_charges",
						"DerActInvTotal",
						"DerPlanInvTotal",
						"RowPointer" });
			var InvMsNom1InsertRequest = this.collectionInsertRequestFactory.SQLInsert(tableName: "#InvMsNom",
				items: InvMsNom1LoadResponse.Items);

			this.appDB.Insert(InvMsNom1InsertRequest);
		}

		public ICollectionLoadResponse Invmsnom2Select()
		{
			var InvMsNomCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"proj_num","proj_num"},
					{"inv_ms_num","inv_ms_num"},
					{"act_inv_amt","act_inv_amt"},
					{"nominated","nominated"},
					{"plan_date","plan_date"},
					{"act_date","act_date"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "#InvMsNom",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" proj_num, inv_ms_num"));

			return this.appDB.Load(InvMsNomCrsLoadRequestForCursor);
		}
		public ICollectionLoadResponse Invmsnom3Select(string ProjNum, string InvMsNum)
		{
			var InvMsNom3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"DerCurrentPeriod","#InvMsNom.DerCurrentPeriod"},
					{"DerCurrentPeriodStart","#InvMsNom.DerCurrentPeriodStart"},
					{"DerCurrentPeriodEnd","#InvMsNom.DerCurrentPeriodEnd"},
					{"DerTotPerPlanInvAmt","#InvMsNom.DerTotPerPlanInvAmt"},
					{"DerTotPerNomPlanInvAmt","#InvMsNom.DerTotPerNomPlanInvAmt"},
					{"DerTotYrPlanInvAmt","#InvMsNom.DerTotYrPlanInvAmt"},
					{"DerTotYrNomPlanInvAmt","#InvMsNom.DerTotYrNomPlanInvAmt"},
					{"DerTotPerActInvAmt","#InvMsNom.DerTotPerActInvAmt"},
					{"DerTotPerNomActInvAmt","#InvMsNom.DerTotPerNomActInvAmt"},
					{"DerTotYrActInvAmt","#InvMsNom.DerTotYrActInvAmt"},
					{"DerTotYrNomActInvAmt","#InvMsNom.DerTotYrNomActInvAmt"},
					{"DerNominated","#InvMsNom.DerNominated"},
					{"DerActInvAmt","#InvMsNom.DerActInvAmt"},
					{"DerActDate","#InvMsNom.DerActDate"},
				},
				tableName: "#InvMsNom", 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("proj_num = {1} AND inv_ms_num = {0}", InvMsNum, ProjNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(InvMsNom3LoadRequest);
		}

		public void Invmsnom3Update(int? DerCurrentPeriod, DateTime? DerCurrentPeriodStart, DateTime? DerCurrentPeriodEnd, decimal? DerTotPerPlanInvAmt, decimal? DerTotPerNomPlanInvAmt, decimal? DerTotYrPlanInvAmt, decimal? DerTotYrNomPlanInvAmt, decimal? DerTotPerActInvAmt, decimal? DerTotPerNomActInvAmt, decimal? DerTotYrActInvAmt, decimal? DerTotYrNomActInvAmt, int? DerNominated, decimal? DerActInvAmt, DateTime? DerActDate, ICollectionLoadResponse InvMsNom3LoadResponse)
		{
			foreach (var InvMsNom3Item in InvMsNom3LoadResponse.Items)
			{
				InvMsNom3Item.SetValue<int?>("DerCurrentPeriod", DerCurrentPeriod);
				InvMsNom3Item.SetValue<DateTime?>("DerCurrentPeriodStart", DerCurrentPeriodStart);
				InvMsNom3Item.SetValue<DateTime?>("DerCurrentPeriodEnd", DerCurrentPeriodEnd);
				InvMsNom3Item.SetValue<decimal?>("DerTotPerPlanInvAmt", DerTotPerPlanInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotPerNomPlanInvAmt", DerTotPerNomPlanInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotYrPlanInvAmt", DerTotYrPlanInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotYrNomPlanInvAmt", DerTotYrNomPlanInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotPerActInvAmt", DerTotPerActInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotPerNomActInvAmt", DerTotPerNomActInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotYrActInvAmt", DerTotYrActInvAmt);
				InvMsNom3Item.SetValue<decimal?>("DerTotYrNomActInvAmt", DerTotYrNomActInvAmt);
				InvMsNom3Item.SetValue<int?>("DerNominated", DerNominated);
				InvMsNom3Item.SetValue<decimal?>("DerActInvAmt", DerActInvAmt);
				InvMsNom3Item.SetValue<DateTime?>("DerActDate", DerActDate);
			};

			var InvMsNom3RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#InvMsNom",
				items: InvMsNom3LoadResponse.Items);

			this.appDB.Update(InvMsNom3RequestUpdate);
		}

		public ICollectionLoadResponse Dynamicparameters1Select()
		{
			var DynamicParameters1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SelectionClause","SelectionClause"},
				},
				tableName: "#DynamicParameters", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(DynamicParameters1LoadRequest);
		}

		public void Dynamicparameters1Delete(ICollectionLoadResponse DynamicParameters1LoadResponse)
		{
			var DynamicParameters1DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#DynamicParameters",
				items: DynamicParameters1LoadResponse.Items);
			this.appDB.Delete(DynamicParameters1DeleteRequest);
		}

		public ICollectionLoadResponse NontableSelect()
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "SelectionClause", " SELECT * "},
					{ "FromClause", "FROM #InvMsNom"},
					{ "WhereClause", null},
					{ "AdditionalClause", "ORDER BY proj_num, inv_ms_num"},
					{ "KeyColumns", "proj_num, inv_ms_num"},
					{ "FilterString", null},
			});

			return this.appDB.Load(nonTableLoadRequest);
		}
		public void NontableInsert(ICollectionLoadResponse nonTableLoadResponse)
		{
			var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
				items: nonTableLoadResponse.Items);

			this.appDB.Insert(nonTableInsertRequest);
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_InvMsNomSp(
			string AltExtGenSp,
			DateTime? PActDate,
			DateTime? PPlanDate,
			string Filter)
		{
			DateType _PActDate = PActDate;
			DateType _PPlanDate = PPlanDate;
			LongListType _Filter = Filter;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "PActDate", _PActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlanDate", _PPlanDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);

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
