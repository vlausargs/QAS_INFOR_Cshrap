//PROJECT NAME: Logistics
//CLASS NAME: CLM_VendorBalance.cs

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
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
	public class CLM_VendorBalance : ICLM_VendorBalance
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IDefaultToLocalSite iDefaultToLocalSite;
		readonly ITransactionFactory transactionFactory;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IScalarFunction scalarFunction;
		readonly IInterpretText iInterpretText;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IVariableUtil variableUtil;
		readonly IDoubleQuote iDoubleQuote;
		readonly IStringUtil stringUtil;
		readonly IDoAPAging iDoAPAging;
		readonly ISQLValueComparerUtil sQLUtil;

		public CLM_VendorBalance(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IDefaultToLocalSite iDefaultToLocalSite,
			ITransactionFactory transactionFactory,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IScalarFunction scalarFunction,
			IInterpretText iInterpretText,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IVariableUtil variableUtil,
			IDoubleQuote iDoubleQuote,
			IStringUtil stringUtil,
			IDoAPAging iDoAPAging,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iDefaultToLocalSite = iDefaultToLocalSite;
			this.transactionFactory = transactionFactory;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.scalarFunction = scalarFunction;
			this.iInterpretText = iInterpretText;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.variableUtil = variableUtil;
			this.iDoubleQuote = iDoubleQuote;
			this.stringUtil = stringUtil;
			this.iDoAPAging = iDoAPAging;
			this.sQLUtil = sQLUtil;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_VendorBalanceSp(
			string FilterString = null,
			string SiteRef = null)
		{

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{

				ICollectionLoadResponse Data = null;

				StringType _ALTGEN_SpName = DBNull.Value;
				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? Severity = null;
				string Infobar = null;
				string VendNumCur = null;
				string CurrCode = null;
				int? TransDom = null;
				string TranslatedText = null;
				decimal? DomAgeBal1 = null;
				decimal? DomAgeBal2 = null;
				decimal? DomAgeBal3 = null;
				decimal? DomAgeBal4 = null;
				decimal? DomAgeBal5 = null;
				decimal? DomAgeBalNet = null;
				string ConvDomVendAgeBalNet = null;
				string Site = null;
				AgeDaysType _AgeDays1 = DBNull.Value;
				int? AgeDays1 = null;
				AgeDaysType _AgeDays2 = DBNull.Value;
				int? AgeDays2 = null;
				AgeDaysType _AgeDays3 = DBNull.Value;
				int? AgeDays3 = null;
				AgeDaysType _AgeDays4 = DBNull.Value;
				int? AgeDays4 = null;
				AgeDaysType _AgeDays5 = DBNull.Value;
				int? AgeDays5 = null;
				string AmountOverdueFlag = null;
				ICollectionLoadRequest vendCrsLoadRequestForCursor = null;
				ICollectionLoadResponse vendCrsLoadResponseForCursor = null;
				int vendCrs_CursorFetch_Status = -1;
				int vendCrs_CursorCounter = -1;
				string SelectionClause = null;
				string FromClause = null;
				string WhereClause = null;
				string AdditionalClause = null;
				if (existsChecker.Exists(tableName: "optional_module",
					fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_VendorBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
				)
				{
					//BEGIN
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");

					#region CRUD LoadToRecord
					var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"SpName","CAST (NULL AS NVARCHAR)"},
							{"u0","[om].[ModuleName]"},
						},
						loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "optional_module",
						fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
						whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_VendorBalanceSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
					#endregion  LoadToRecord

					#region CRUD InsertByRecords
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_VendorBalanceSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
					};

					var optional_module1RequiredColumns = new List<string>() { "SpName" };

					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

					var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
						items: optional_module1LoadResponse.Items);

					this.appDB.Insert(optional_module1InsertRequest);
					#endregion InsertByRecords

					while (existsChecker.Exists(tableName: "#tv_ALTGEN",
						fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause(""))
					)
					{
						//BEGIN

						#region CRUD LoadToVariable
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
						#endregion  LoadToVariable

						var ALTGEN = AltExtGen_CLM_VendorBalanceSp(ALTGEN_SpName,
							FilterString,
							SiteRef);
						ALTGEN_Severity = ALTGEN.ReturnCode;

						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);

						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						#region CRUD LoadToRecord
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
						var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
						#endregion  LoadToRecord

						#region CRUD DeleteByRecord
						var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
							items: tv_ALTGEN2LoadResponse.Items);
						this.appDB.Delete(tv_ALTGEN2DeleteRequest);
						#endregion DeleteByRecord

						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
						//END

					}
					//END

				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_VendorBalanceSp") != null)
				{
					var EXTGEN = AltExtGen_CLM_VendorBalanceSp("dbo.EXTGEN_CLM_VendorBalanceSp",
						FilterString,
						SiteRef);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
				if (this.scalarFunction.Execute<int?>(
					"OBJECT_ID",
					"tempdb..#VendBal") == null)
				{

					this.sQLExpressionExecutor.Execute(@"Declare
						@VendNum VendNumType
						,@VendName NameType
						,@CurrCode CurrCodeType
						,@DomAgeBal1 AmtTotType
						,@DomAgeBal2 AmtTotType
						,@DomAgeBal3 AmtTotType
						,@DomAgeBal4 AmtTotType
						,@DomAgeBal5 AmtTotType
						,@DomAgeBalNetShort DECIMAL (22,1)
						,@AmountOverdueFlag NCHAR (1)
						SELECT @VendNum AS VendNum,
						       @VendName AS VendName,
						       @CurrCode AS VendCurrCode,
						       @DomAgeBal1 AS DomVendAgeBal1,
						       @DomAgeBal2 AS DomVendAgeBal2,
						       @DomAgeBal3 AS DomVendAgeBal3,
						       @DomAgeBal4 AS DomVendAgeBal4,
						       @DomAgeBal5 AS DomVendAgeBal5,
						       @DomAgeBalNetShort AS DomAgeBalNetShort,
						       @AmountOverdueFlag AS AmountOverdueFlag
						INTO   #VendBal
						WHERE  1 = 2");

				}
				this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX VendBalVendNum
					    ON #VendBal(VendNum)");
				Severity = 0;
				TransDom = 1;
				AmountOverdueFlag = null;
				if (SiteRef == null)
				{
					Site = this.iDefaultToLocalSite.DefaultToLocalSiteFn(Site);

				}
				else
				{
					Site = this.iDoubleQuote.DoubleQuoteFn(SiteRef);

				}
				TranslatedText = "";

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: InterpretTextSp
				var InterpretText = this.iInterpretText.InterpretTextSp(
					Text: "FORMAT(sUndefined)",
					InterpretedText: TranslatedText,
					Infobar: Infobar);
				Severity = InterpretText.ReturnCode;
				TranslatedText = InterpretText.InterpretedText;
				Infobar = InterpretText.Infobar;

				#endregion ExecuteMethodCall

				TranslatedText = stringUtil.Concat("<", TranslatedText, ">");

				#region CRUD LoadToVariable
				var dbo_apparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_AgeDays1,"age_days##1"},
						{_AgeDays2,"age_days##2"},
						{_AgeDays3,"age_days##3"},
						{_AgeDays4,"age_days##4"},
						{_AgeDays5,"age_days##5"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "dbo.apparms_all",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", Site),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var dbo_apparms_allLoadResponse = this.appDB.Load(dbo_apparms_allLoadRequest);
				if (dbo_apparms_allLoadResponse.Items.Count > 0)
				{
					AgeDays1 = _AgeDays1;
					AgeDays2 = _AgeDays2;
					AgeDays3 = _AgeDays3;
					AgeDays4 = _AgeDays4;
					AgeDays5 = _AgeDays5;
				}
				#endregion  LoadToVariable

				#region CRUD LoadToRecord
				var vendor_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"VendNum","vendor.vend_num"},
						{"VendName","CAST (NULL AS NVARCHAR)"},
						{"VendCurrCode","vendor.curr_code"},
						{"DomVendAgeBal1","CAST (NULL AS INT)"},
						{"DomVendAgeBal2","CAST (NULL AS INT)"},
						{"DomVendAgeBal3","CAST (NULL AS INT)"},
						{"DomVendAgeBal4","CAST (NULL AS INT)"},
						{"DomVendAgeBal5","CAST (NULL AS INT)"},
						{"DomAgeBalNetShort","CAST (NULL AS INT)"},
						{"AmountOverdueFlag","CAST (NULL AS NVARCHAR)"},
						{"u0","vendaddr.name"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "vendor_all",
					fromClause: collectionLoadRequestFactory.Clause(" AS vendor INNER JOIN vendaddr ON vendaddr.vend_num = vendor.vend_num"),
					whereClause: collectionLoadRequestFactory.Clause("vendor.show_in_drop_down_list = 1 AND vendor.site_ref = {0}", Site),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var vendor_allLoadResponse = this.appDB.Load(vendor_allLoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var vendor_allItem in vendor_allLoadResponse.Items)
				{
					vendor_allItem.SetValue<string>("VendNum", vendor_allItem.GetValue<string>("VendNum"));
					vendor_allItem.SetValue<string>("VendName", stringUtil.IsNull(
						vendor_allItem.GetValue<string>("u0"),
						TranslatedText));
					vendor_allItem.SetValue<string>("VendCurrCode", vendor_allItem.GetValue<string>("VendCurrCode"));
					vendor_allItem.SetValue<int?>("DomVendAgeBal1", 0);
					vendor_allItem.SetValue<int?>("DomVendAgeBal2", 0);
					vendor_allItem.SetValue<int?>("DomVendAgeBal3", 0);
					vendor_allItem.SetValue<int?>("DomVendAgeBal4", 0);
					vendor_allItem.SetValue<int?>("DomVendAgeBal5", 0);
					vendor_allItem.SetValue<int?>("DomAgeBalNetShort", 0);
					vendor_allItem.SetValue<string>("AmountOverdueFlag", "");
				};

				var vendor_allRequiredColumns = new List<string>() { "VendNum", "VendName", "VendCurrCode", "DomVendAgeBal1", "DomVendAgeBal2", "DomVendAgeBal3", "DomVendAgeBal4", "DomVendAgeBal5", "DomAgeBalNetShort", "AmountOverdueFlag" };

				vendor_allLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(vendor_allLoadResponse, vendor_allRequiredColumns);

				var vendor_allInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#VendBal",
					items: vendor_allLoadResponse.Items);

				this.appDB.Insert(vendor_allInsertRequest);
				#endregion InsertByRecords

				#region Cursor Statement

				#region CRUD LoadToRecord
				vendCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"VendNum","VendNum"},
						{"VendCurrCode","VendCurrCode"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "#VendBal",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				#endregion  LoadToRecord

				#endregion Cursor Statement
				vendCrsLoadResponseForCursor = this.appDB.Load(vendCrsLoadRequestForCursor);
				vendCrs_CursorFetch_Status = vendCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				vendCrs_CursorCounter = -1;

				while (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					//BEGIN
					vendCrs_CursorCounter++;
					if (vendCrsLoadResponseForCursor.Items.Count > vendCrs_CursorCounter)
					{
						VendNumCur = vendCrsLoadResponseForCursor.Items[vendCrs_CursorCounter].GetValue<string>(0);
						CurrCode = vendCrsLoadResponseForCursor.Items[vendCrs_CursorCounter].GetValue<string>(1);
					}
					vendCrs_CursorFetch_Status = (vendCrs_CursorCounter == vendCrsLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLNotEqual(vendCrs_CursorFetch_Status, 0) == true)
					{

						break;

					}
					DomAgeBal1 = 0;
					DomAgeBal2 = 0;
					DomAgeBal3 = 0;
					DomAgeBal4 = 0;
					DomAgeBal5 = 0;
					DomAgeBalNet = 0;

					#region CRUD ExecuteMethodCall

					//Please Generate the bounce for this stored procedure: DoAPAgingSp
					var DoAPAging = this.iDoAPAging.DoAPAgingSp(
						PVendNum: VendNumCur,
						PCurrCode: CurrCode,
						PTransDom: TransDom,
						PSite: Site,
						PAgeDesc1: null,
						PAgeDesc2: null,
						PAgeDesc3: null,
						PAgeDesc4: null,
						PAgeDesc5: null,
						PAgeBal1: DomAgeBal1,
						PAgeBal2: DomAgeBal2,
						PAgeBal3: DomAgeBal3,
						PAgeBal4: DomAgeBal4,
						PAgeBal5: DomAgeBal5,
						PAgeBal6: DomAgeBalNet,
						Infobar: Infobar);
					Severity = DoAPAging.ReturnCode;
					DomAgeBal1 = DoAPAging.PAgeBal1;
					DomAgeBal2 = DoAPAging.PAgeBal2;
					DomAgeBal3 = DoAPAging.PAgeBal3;
					DomAgeBal4 = DoAPAging.PAgeBal4;
					DomAgeBal5 = DoAPAging.PAgeBal5;
					DomAgeBalNet = DoAPAging.PAgeBal6;
					Infobar = DoAPAging.Infobar;

					#endregion ExecuteMethodCall

					if (((sQLUtil.SQLGreaterThan(AgeDays1, 0) == true && sQLUtil.SQLGreaterThan(DomAgeBal1, 0.00M) == true) || (sQLUtil.SQLGreaterThan(AgeDays2, 0) == true && sQLUtil.SQLGreaterThan(DomAgeBal2, 0.00M) == true) || (sQLUtil.SQLGreaterThan(AgeDays3, 0) == true && sQLUtil.SQLGreaterThan(DomAgeBal3, 0.00M) == true) || (sQLUtil.SQLGreaterThan(AgeDays4, 0) == true && sQLUtil.SQLGreaterThan(DomAgeBal4, 0.00M) == true) || (sQLUtil.SQLGreaterThan(AgeDays5, 0) == true && sQLUtil.SQLGreaterThan(DomAgeBal5, 0.00M) == true)))
					{
						AmountOverdueFlag = "*";

					}
					ConvDomVendAgeBalNet = Convert.ToString(convertToUtil.ToDecimal(DomAgeBalNet / 1000M));
					this.sQLExpressionExecutor.Execute("ALTER TABLE #VendBal ADD tempTableId INT IDENTITY");

					#region CRUD LoadToRecord
					var VendBal2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"DomVendAgeBal1","#VendBal.DomVendAgeBal1"},
							{"DomVendAgeBal2","#VendBal.DomVendAgeBal2"},
							{"DomVendAgeBal3","#VendBal.DomVendAgeBal3"},
							{"DomVendAgeBal4","#VendBal.DomVendAgeBal4"},
							{"DomVendAgeBal5","#VendBal.DomVendAgeBal5"},
							{"DomAgeBalNetShort","#VendBal.DomAgeBalNetShort"},
							{"AmountOverdueFlag","#VendBal.AmountOverdueFlag"},
						},
						tableName: "#VendBal", 
                        loadForChange: true, 
                        lockingType: LockingType.UPDLock,
                        fromClause: collectionLoadRequestFactory.Clause(""),
						whereClause: collectionLoadRequestFactory.Clause("VendNum = {0}", VendNumCur),
						orderByClause: collectionLoadRequestFactory.Clause(""));
					var VendBal2LoadResponse = this.appDB.Load(VendBal2LoadRequest);
					#endregion  LoadToRecord

					#region CRUD UpdateByRecord
					foreach (var VendBal2Item in VendBal2LoadResponse.Items)
					{
						VendBal2Item.SetValue<decimal?>("DomVendAgeBal1", DomAgeBal1);
						VendBal2Item.SetValue<decimal?>("DomVendAgeBal2", DomAgeBal2);
						VendBal2Item.SetValue<decimal?>("DomVendAgeBal3", DomAgeBal3);
						VendBal2Item.SetValue<decimal?>("DomVendAgeBal4", DomAgeBal4);
						VendBal2Item.SetValue<decimal?>("DomVendAgeBal5", DomAgeBal5);
						VendBal2Item.SetValue<decimal?>("DomAgeBalNetShort", convertToUtil.ToDecimal(DomAgeBalNet / 1000M));
						VendBal2Item.SetValue<string>("AmountOverdueFlag", stringUtil.IsNull(
							AmountOverdueFlag,
							""));
					};

					var VendBal2RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#VendBal",
						items: VendBal2LoadResponse.Items);

					this.appDB.Update(VendBal2RequestUpdate);
					#endregion UpdateByRecord

					this.sQLExpressionExecutor.Execute("ALTER TABLE #VendBal DROP COLUMN tempTableId");
					AmountOverdueFlag = null;
					//END

				}
				//Deallocate Cursor vendCrs
				SelectionClause = "";
				FromClause = "";
				WhereClause = "";
				AdditionalClause = "";
				SelectionClause = "SELECT *  ";
				FromClause = " FROM #VendBal";
				WhereClause = " WHERE 1 = 1";
				AdditionalClause = " ORDER BY DomAgeBalNetShort DESC";

				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@FilterString LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       N'VendNum' AS KeyColumns,
					       @FilterString AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");

				#region CRUD LoadArbitrary
				var DynamicParametersLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
					{
						{"SelectionClause",$"{variableUtil.GetQuotedValue<string>(SelectionClause)}"},
						{"FromClause",$"{variableUtil.GetQuotedValue<string>(FromClause)}"},
						{"WhereClause",$"{variableUtil.GetQuotedValue<string>(WhereClause)}"},
						{"AdditionalClause",$"{variableUtil.GetQuotedValue<string>(AdditionalClause)}"},
						{"KeyColumns","N'VendNum'"},
						{"FilterString",$"{variableUtil.GetQuotedValue<string>(FilterString)}"},
					},
					selectStatement: collectionLoadRequestFactory.Clause("SELECT @selectList"));

				var DynamicParametersLoadResponse = this.appDB.Load(DynamicParametersLoadRequest);
				Data = DynamicParametersLoadResponse;
				#endregion  LoadArbitrary

				#region CRUD InsertByRecords
				var DynamicParametersInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#DynamicParameters",
					items: DynamicParametersLoadResponse.Items);

				this.appDB.Insert(DynamicParametersInsertRequest);
				#endregion InsertByRecords

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 1,
					Infobar: Infobar);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;
				Infobar = ExecuteDynamicSQL.Infobar;

				#endregion ExecuteMethodCall

				return (Data, Severity);

			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_VendorBalanceSp(
			string AltExtGenSp,
			string FilterString = null,
			string SiteRef = null)
		{
			LongListType _FilterString = FilterString;
			SiteType _SiteRef = SiteRef;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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
