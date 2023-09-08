//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryAging.cs

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

namespace CSI.Reporting
{
	public class Rpt_InventoryAging : IRpt_InventoryAging
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMaxQty iMaxQty;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        public Rpt_InventoryAging(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMaxQty iMaxQty,
            ILowString lowString,
            IHighString highString,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMaxQty = iMaxQty;
            this.lowString = lowString;
            this.highString = highString;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_InventoryAgingSp(
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string WhseStarting = null,
			string WhseEnding = null,
			string LocStarting = null,
			string LocEnding = null,
			string AgingBasis = null,
			int? DisplayHeader = null,
			int? AgeDays1 = null,
			int? AgeDays2 = null,
			int? AgeDays3 = null,
			int? AgeDays4 = null,
			int? AgeDays5 = null,
			string AgeDesc1 = null,
			string AgeDesc2 = null,
			string AgeDesc3 = null,
			string AgeDesc4 = null,
			string AgeDesc5 = null,
			string pSite = null,
			string DocumentNumStarting = null,
			string DocumentNumEnding = null)
		{

			int? Severity = 0;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			string LowCharVal = null;
			string HighCharVal = null;
			DateTime? currentDate = null;
			string ExecStr = null;
			int? LargestDays = null;
			DateTime? LowDate = null;
			string SQLTypeCaseWhenClause = null;
			string SqlParams = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryAgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_InventoryAgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_InventoryAgingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_Rpt_InventoryAgingSp(ALTGEN_SpName,
						ItemStarting,
						ItemEnding,
						ProductCodeStarting,
						ProductCodeEnding,
						WhseStarting,
						WhseEnding,
						LocStarting,
						LocEnding,
						AgingBasis,
						DisplayHeader,
						AgeDays1,
						AgeDays2,
						AgeDays3,
						AgeDays4,
						AgeDays5,
						AgeDesc1,
						AgeDesc2,
						AgeDesc3,
						AgeDesc4,
						AgeDesc5,
						pSite,
						DocumentNumStarting,
						DocumentNumEnding);
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
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_InventoryAgingSp") != null)
			{
				var EXTGEN = AltExtGen_Rpt_InventoryAgingSp("dbo.EXTGEN_Rpt_InventoryAgingSp",
					ItemStarting,
					ItemEnding,
					ProductCodeStarting,
					ProductCodeEnding,
					WhseStarting,
					WhseEnding,
					LocStarting,
					LocEnding,
					AgingBasis,
					DisplayHeader,
					AgeDays1,
					AgeDays2,
					AgeDays3,
					AgeDays4,
					AgeDays5,
					AgeDesc1,
					AgeDesc2,
					AgeDesc3,
					AgeDesc4,
					AgeDesc5,
					pSite,
					DocumentNumStarting,
					DocumentNumEnding);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("InventoryAgingReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

			}
			SqlParams = stringUtil.Concat("@LowDate DateType, @currentDate CurrentDateType, @AgeDays1 AgeDaysType, @AgeDays2 AgeDaysType, @AgeDays3 AgeDaysType, @AgeDays4 AgeDaysType, @AgeDays5 AgeDaysType,", "@ItemStarting ItemType, @ItemEnding ItemType, @WhseStarting WhseType, @WhseEnding WhseType, @LocStarting LocType, @LocEnding LocType,", "@DocumentNumStarting DocumentNumType,  @DocumentNumEnding DocumentNumType, @ProductCodeStarting ProductCodeType, @ProductCodeEnding ProductCodeType, @LargestDays AgeDaysType");
			LowCharVal = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
			HighCharVal = convertToUtil.ToString(this.highCharacter.HighCharacterFn());

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_InventoryAgingSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			WhseStarting = stringUtil.IsNull(
				WhseStarting,
				LowCharVal);
			WhseEnding = stringUtil.IsNull(
				WhseEnding,
				HighCharVal);
			LocStarting = stringUtil.IsNull(
				LocStarting,
				LowCharVal);
			LocEnding = stringUtil.IsNull(
				LocEnding,
				HighCharVal);
			DocumentNumStarting = stringUtil.IsNull(
				DocumentNumStarting,
				this.lowString.LowStringFn("DocumentNumType"));
			DocumentNumEnding = stringUtil.IsNull(
				DocumentNumEnding,
				this.highString.HighStringFn("DocumentNumType"));
			ProductCodeStarting = stringUtil.IsNull(
				ProductCodeStarting,
				LowCharVal);
			ProductCodeEnding = stringUtil.IsNull(
				ProductCodeEnding,
				HighCharVal);
			ItemStarting = stringUtil.IsNull(
				ItemStarting,
				LowCharVal);
			ItemEnding = stringUtil.IsNull(
				ItemEnding,
				HighCharVal);
			AgingBasis = stringUtil.IsNull(
				AgingBasis,
				"W");
			AgeDays1 = (int?)(stringUtil.IsNull(
				AgeDays1,
				0));
			AgeDays2 = (int?)(stringUtil.IsNull(
				AgeDays2,
				0));
			AgeDays3 = (int?)(stringUtil.IsNull(
				AgeDays3,
				0));
			AgeDays4 = (int?)(stringUtil.IsNull(
				AgeDays4,
				0));
			AgeDays5 = (int?)(stringUtil.IsNull(
				AgeDays5,
				0));
			DisplayHeader = (int?)(stringUtil.IsNull(
				DisplayHeader,
				1));
			currentDate = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
			LargestDays = (int?)(this.iMaxQty.MaxQtyFn(
				this.iMaxQty.MaxQtyFn(
					this.iMaxQty.MaxQtyFn(
						this.iMaxQty.MaxQtyFn(
							convertToUtil.ToDecimal(AgeDays1),
							convertToUtil.ToDecimal(AgeDays2)),
						convertToUtil.ToDecimal(AgeDays3)),
					convertToUtil.ToDecimal(AgeDays4)),
				convertToUtil.ToDecimal(AgeDays5)));
			LowDate = convertToUtil.ToDateTime(dateTimeUtil.DateAdd("Day", -LargestDays, currentDate));
			SQLTypeCaseWhenClause = @"DATEDIFF(DAY,MAX(case when
				    (MT.trans_type = 'R' AND MT.ref_type = 'P') OR
				    (MT.trans_type = 'H' AND MT.ref_type = 'I') OR
				    (MT.trans_type = 'F' AND MT.ref_type = 'J') OR
				    (MT.trans_type = 'W' AND MT.ref_type = 'J') OR
				    (MT.trans_type = 'S' AND MT.ref_type = 'O' AND MT.QTY > 0) OR
				    (MT.trans_type = 'W' AND MT.ref_type = 'O' AND MT.QTY > 0) OR
				    (MT.trans_type = 'G' AND MT.ref_type = 'F') OR
				    (MT.trans_type = 'H' AND MT.ref_type = 'F')
				   then MT.trans_date
				   else ";
			ExecStr = @"SELECT
				 MT.item          Item
				,IM.description   Description
				,MT.whse          Whse
				,WH.name          WhseDesc";
			if (sQLUtil.SQLEqual(AgingBasis, "W") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					,''               Loc
					,''               Lot");

			}
			else
			{
				if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						,MT.loc           Loc
						,''               Lot");

				}
				else
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						,MT.loc           Loc
						,MT.lot           Lot");

				}

			}
			if (sQLUtil.SQLEqual(AgingBasis, "W") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					, ISNULL((CASE WHEN IM.lot_tracked = 1
					    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND qty_on_hand <> 0)
					    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND qty_on_hand <> 0)
					  END), 0) Qty");

			}
			else
			{
				if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						, ISNULL((CASE WHEN IM.lot_tracked = 1
						    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc AND qty_on_hand <> 0)
						    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc)
						  END), 0) Qty");

				}
				else
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						, ISNULL((CASE WHEN IM.lot_tracked = 1
						    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc AND Lot = MT.lot AND qty_on_hand <> 0)
						    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc)
						  END), 0) Qty");

				}

			}
			ExecStr = stringUtil.Concat(ExecStr, @"
				, ISNULL((CASE WHEN ", SQLTypeCaseWhenClause, @" convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) < = @AgeDays1 THEN 1
				    WHEN ", SQLTypeCaseWhenClause, @" convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) < = @AgeDays2 THEN 2
				    WHEN ", SQLTypeCaseWhenClause, @" convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) < = @AgeDays3 THEN 3
				    WHEN ", SQLTypeCaseWhenClause, @" convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) < = @AgeDays4 THEN 4
				    WHEN ", SQLTypeCaseWhenClause, @" convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) < = @AgeDays5 THEN 5
				    END),0) Bucket
				, DATEDIFF(DAY,MAX(MT.trans_date), convert(nvarchar, @currentDate, 112)) AgeDays
				FROM matltran MT
				   INNER JOIN item IM ON MT.item = IM.item
				   RIGHT OUTER JOIN whse WH ON MT.whse = WH.whse");
			if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					   INNER JOIN itemloc IL ON MT.loc = IL.loc AND MT.item = IL.item AND MT.whse = IL.whse");

			}
			ExecStr = stringUtil.Concat(ExecStr, @"
				WHERE MT.item BETWEEN @ItemStarting AND @ItemEnding");
			ExecStr = stringUtil.Concat(ExecStr, " AND (ISNULL(MT.whse,'') BETWEEN @WhseStarting AND @WhseEnding)");
			ExecStr = stringUtil.Concat(ExecStr, " AND (ISNULL(MT.loc,'') BETWEEN @LocStarting AND @LocEnding)");
			ExecStr = stringUtil.Concat(ExecStr, " AND (ISNULL(MT.document_num,'') BETWEEN @DocumentNumStarting AND @DocumentNumEnding)");
			ExecStr = stringUtil.Concat(ExecStr, " AND (ISNULL(IM.product_code,'') BETWEEN @ProductCodeStarting AND @ProductCodeEnding)");
			if (sQLUtil.SQLEqual(AgingBasis, "B") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					AND 1 = (CASE WHEN IM.lot_tracked = 1 THEN 1 WHEN IM.lot_tracked = 0 AND MT.lot IS NULL THEN 1 ELSE 0 END)");

			}
			if (sQLUtil.SQLEqual(AgingBasis, "W") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					GROUP BY MT.item, IM.description, MT.whse, WH.name, IM.lot_tracked");

			}
			else
			{
				if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						GROUP BY MT.item, IM.description, MT.whse, WH.name, MT.loc,IM.lot_tracked");

				}
				else
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						GROUP BY MT.item, IM.description, MT.whse, WH.name, MT.loc, MT.lot,IM.lot_tracked");

				}

			}
			ExecStr = stringUtil.Concat(ExecStr, @"
				HAVING (", SQLTypeCaseWhenClause, "convert(nvarchar, @LowDate, 112) end), convert(nvarchar, @currentDate, 112)) <= @LargestDays)");
			if (sQLUtil.SQLEqual(AgingBasis, "W") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					  AND ISNULL((CASE WHEN IM.lot_tracked = 1
					    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND qty_on_hand <> 0)
					    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND qty_on_hand <> 0)
					  END), 0) != 0");

			}
			else
			{
				if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						  AND ISNULL((CASE WHEN IM.lot_tracked = 1
						    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc AND qty_on_hand <> 0)
						    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc)
						  END), 0) != 0");

				}
				else
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						  AND ISNULL((CASE WHEN IM.lot_tracked = 1
						    THEN (SELECT SUM(qty_on_hand) FROM lot_loc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc AND Lot = MT.lot AND qty_on_hand <> 0)
						    ELSE (SELECT SUM(qty_on_hand) FROM itemloc WHERE item = MT.item AND whse = MT.whse AND Loc = MT.Loc)
						  END), 0) != 0");

				}

			}
			if (sQLUtil.SQLEqual(AgingBasis, "W") == true)
			{
				ExecStr = stringUtil.Concat(ExecStr, @"
					ORDER BY MT.whse, MT.item");

			}
			else
			{
				if (sQLUtil.SQLEqual(AgingBasis, "L") == true)
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						ORDER BY MT.whse, MT.item,  MT.loc");

				}
				else
				{
					ExecStr = stringUtil.Concat(ExecStr, @"
						ORDER BY MT.whse, MT.item, MT.lot, MT.loc");

				}

			}

			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(ExecStr
			, SqlParams
			, LowDate
			, currentDate
			, AgeDays1
			, AgeDays2
			, AgeDays3
			, AgeDays4
			, AgeDays5
			, ItemStarting
			, ItemEnding
			, WhseStarting
			, WhseEnding
			, LocStarting
			, LocEnding
			, DocumentNumStarting
			, DocumentNumEnding
			, ProductCodeStarting
			, ProductCodeEnding
			, LargestDays);

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (execResult.Data, Severity);
		}
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_Rpt_InventoryAgingSp(
			string AltExtGenSp,
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string WhseStarting = null,
			string WhseEnding = null,
			string LocStarting = null,
			string LocEnding = null,
			string AgingBasis = null,
			int? DisplayHeader = null,
			int? AgeDays1 = null,
			int? AgeDays2 = null,
			int? AgeDays3 = null,
			int? AgeDays4 = null,
			int? AgeDays5 = null,
			string AgeDesc1 = null,
			string AgeDesc2 = null,
			string AgeDesc3 = null,
			string AgeDesc4 = null,
			string AgeDesc5 = null,
			string pSite = null,
			string DocumentNumStarting = null,
			string DocumentNumEnding = null)
		{
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			ProductCodeType _ProductCodeStarting = ProductCodeStarting;
			ProductCodeType _ProductCodeEnding = ProductCodeEnding;
			WhseType _WhseStarting = WhseStarting;
			WhseType _WhseEnding = WhseEnding;
			LocType _LocStarting = LocStarting;
			LocType _LocEnding = LocEnding;
			InfobarType _AgingBasis = AgingBasis;
			ListYesNoType _DisplayHeader = DisplayHeader;
			AgeDaysType _AgeDays1 = AgeDays1;
			AgeDaysType _AgeDays2 = AgeDays2;
			AgeDaysType _AgeDays3 = AgeDays3;
			AgeDaysType _AgeDays4 = AgeDays4;
			AgeDaysType _AgeDays5 = AgeDays5;
			AgeDescType _AgeDesc1 = AgeDesc1;
			AgeDescType _AgeDesc2 = AgeDesc2;
			AgeDescType _AgeDesc3 = AgeDesc3;
			AgeDescType _AgeDesc4 = AgeDesc4;
			AgeDescType _AgeDesc5 = AgeDesc5;
			SiteType _pSite = pSite;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeStarting", _ProductCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCodeEnding", _ProductCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocStarting", _LocStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocEnding", _LocEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingBasis", _AgingBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays1", _AgeDays1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays2", _AgeDays2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays3", _AgeDays3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays4", _AgeDays4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDays5", _AgeDays5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc1", _AgeDesc1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc2", _AgeDesc2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc3", _AgeDesc3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc4", _AgeDesc4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeDesc5", _AgeDesc5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);

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
