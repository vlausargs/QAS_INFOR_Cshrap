//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerCheckInformation.cs

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
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_GeneralLedgerCheckInformation : IRpt_GeneralLedgerCheckInformation
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly ITransactionFactory transactionFactory;
		readonly IGetIsolationLevel iGetIsolationLevel;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IApplyDateOffset iApplyDateOffset;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_GeneralLedgerCheckInformationCRUD iRpt_GeneralLedgerCheckInformationCRUD;
        readonly ILowString lowString;
        readonly IHighString highString;

        public Rpt_GeneralLedgerCheckInformation(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			ITransactionFactory transactionFactory,
			IGetIsolationLevel iGetIsolationLevel,
			ISQLCollectionLoad sQLCollectionLoad,
			IApplyDateOffset iApplyDateOffset,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IRpt_GeneralLedgerCheckInformationCRUD iRpt_GeneralLedgerCheckInformationCRUD,
            ILowString lowString,
            IHighString highString)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.transactionFactory = transactionFactory;
			this.iGetIsolationLevel = iGetIsolationLevel;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.iApplyDateOffset = iApplyDateOffset;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iRpt_GeneralLedgerCheckInformationCRUD = iRpt_GeneralLedgerCheckInformationCRUD;
            this.lowString = lowString;
            this.highString = highString;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_GeneralLedgerCheckInformationSp(
			string AccountStarting = null,
			string AccountEnding = null,
			string PrintTrxText = null,
			int? AnalyticalLedger = null,
			string AcctUnit1Starting = null,
			string AcctUnit1Ending = null,
			string AcctUnit2Starting = null,
			string AcctUnit2Ending = null,
			string AcctUnit3Starting = null,
			string AcctUnit3Ending = null,
			string AcctUnit4Starting = null,
			string AcctUnit4Ending = null,
			DateTime? TransDateStarting = null,
			DateTime? TransDateEnding = null,
			string RefStarting = null,
			string RefEnding = null,
			string VendNumStarting = null,
			string VendNumEnding = null,
			string VoucherStarting = null,
			string VoucherEnding = null,
			DateTime? CheckDateStarting = null,
			DateTime? CheckDateEnding = null,
			int? CheckNumStarting = null,
			int? CheckNumEnding = null,
			decimal? TransNumStarting = null,
			decimal? TransNumEnding = null,
			int? TransDateStartingOffset = null,
			int? TransDateEndingOffset = null,
			int? CheckDateStartingOffset = null,
			int? CheckDateEndingOffset = null,
			int? ShowInternal = null,
			int? ShowExternal = null,
			int? DisplayHeader = null,
			string pSite = null)
		{

			ICollectionLoadResponse Data = null;

			int? Severity = 0;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			Guid? RptSessionID = null;
			string SQL = null;
			int? iCheck = null;
			if (this.iRpt_GeneralLedgerCheckInformationCRUD.Optional_ModuleForExists())
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_GeneralLedgerCheckInformationCRUD.Optional_Module1Select();
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_GeneralLedgerCheckInformationSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iRpt_GeneralLedgerCheckInformationCRUD.Optional_Module1Insert(optional_module1LoadResponse);

				while (this.iRpt_GeneralLedgerCheckInformationCRUD.Tv_ALTGENForExists())
				{
					//BEGIN
					ALTGEN_SpName = this.iRpt_GeneralLedgerCheckInformationCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_GeneralLedgerCheckInformationCRUD.AltExtGen_Rpt_GeneralLedgerCheckInformationSp(ALTGEN_SpName,
						AccountStarting,
						AccountEnding,
						PrintTrxText,
						AnalyticalLedger,
						AcctUnit1Starting,
						AcctUnit1Ending,
						AcctUnit2Starting,
						AcctUnit2Ending,
						AcctUnit3Starting,
						AcctUnit3Ending,
						AcctUnit4Starting,
						AcctUnit4Ending,
						TransDateStarting,
						TransDateEnding,
						RefStarting,
						RefEnding,
						VendNumStarting,
						VendNumEnding,
						VoucherStarting,
						VoucherEnding,
						CheckDateStarting,
						CheckDateEnding,
						CheckNumStarting,
						CheckNumEnding,
						TransNumStarting,
						TransNumEnding,
						TransDateStartingOffset,
						TransDateEndingOffset,
						CheckDateStartingOffset,
						CheckDateEndingOffset,
						ShowInternal,
						ShowExternal,
						DisplayHeader,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_GeneralLedgerCheckInformationCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_GeneralLedgerCheckInformationCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END

				}
				//END

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_GeneralLedgerCheckInformationSp") != null)
			{
				var EXTGEN = this.iRpt_GeneralLedgerCheckInformationCRUD.AltExtGen_Rpt_GeneralLedgerCheckInformationSp("dbo.EXTGEN_Rpt_GeneralLedgerCheckInformationSp",
					AccountStarting,
					AccountEnding,
					PrintTrxText,
					AnalyticalLedger,
					AcctUnit1Starting,
					AcctUnit1Ending,
					AcctUnit2Starting,
					AcctUnit2Ending,
					AcctUnit3Starting,
					AcctUnit3Ending,
					AcctUnit4Starting,
					AcctUnit4Ending,
					TransDateStarting,
					TransDateEnding,
					RefStarting,
					RefEnding,
					VendNumStarting,
					VendNumEnding,
					VoucherStarting,
					VoucherEnding,
					CheckDateStarting,
					CheckDateEnding,
					CheckNumStarting,
					CheckNumEnding,
					TransNumStarting,
					TransNumEnding,
					TransDateStartingOffset,
					TransDateEndingOffset,
					CheckDateStartingOffset,
					CheckDateEndingOffset,
					ShowInternal,
					ShowExternal,
					DisplayHeader,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			this.transactionFactory.BeginTransaction("");
			this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
			if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("GeneralLedgerCheckInformationReport"), "COMMITTED") == true)
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

			}
			else
			{
				this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

			}

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_GeneralLedgerCheckInformationSp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;

			#endregion ExecuteMethodCall

			PrintTrxText = stringUtil.IsNull(
				PrintTrxText,
				"N");
			AnalyticalLedger = (int?)(stringUtil.IsNull(
				AnalyticalLedger,
				0));
			if (TransDateStarting != null)
			{

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: TransDateStarting,
					Offset: TransDateStartingOffset,
					IsEndDate: 0);
				TransDateStarting = ApplyDateOffset.Date;

				#endregion ExecuteMethodCall

			}
			if (TransDateEnding != null)
			{

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: TransDateEnding,
					Offset: TransDateEndingOffset,
					IsEndDate: 1);
				TransDateEnding = ApplyDateOffset1.Date;

				#endregion ExecuteMethodCall

			}
			if (VendNumStarting != null)
			{
				VendNumStarting = stringUtil.IsNull(
					this.iExpandKyByType.ExpandKyByTypeFn(
						"VendNumType",
						VendNumStarting),
					this.lowString.LowStringFn("VendNumType"));

			}
			if (VendNumEnding != null)
			{
				VendNumEnding = stringUtil.IsNull(
					this.iExpandKyByType.ExpandKyByTypeFn(
						"VendNumType",
						VendNumEnding),
					this.highString.HighStringFn("VendNumType"));

			}
			if (CheckDateStarting != null)
			{

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: CheckDateStarting,
					Offset: CheckDateStartingOffset,
					IsEndDate: 0);
				CheckDateStarting = ApplyDateOffset2.Date;

				#endregion ExecuteMethodCall

			}
			if (CheckDateEnding != null)
			{

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
				var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(
					Date: CheckDateEnding,
					Offset: CheckDateEndingOffset,
					IsEndDate: 1);
				CheckDateEnding = ApplyDateOffset3.Date;

				#endregion ExecuteMethodCall

			}
			ShowInternal = (int?)(stringUtil.IsNull(
				ShowInternal,
				0));
			ShowExternal = (int?)(stringUtil.IsNull(
				ShowExternal,
				0));
			VoucherStarting = this.iExpandKyByType.ExpandKyByTypeFn(
				"InvNumVoucherType",
				VoucherStarting);
			VoucherEnding = this.iExpandKyByType.ExpandKyByTypeFn(
				"InvNumVoucherType",
				VoucherEnding);
			if (sQLUtil.SQLNotEqual(PrintTrxText, "N") == true && (sQLUtil.SQLEqual(ShowInternal, 1) == true || sQLUtil.SQLEqual(ShowExternal, 1) == true))
			{
				iCheck = 1;

			}
			else
			{
				iCheck = 0;

			}
			SQL = stringUtil.Concat(@"
				   SELECT
				        chart.acct
				      , chart.description
				      , ledger.trans_date
				      , ledger.trans_num
				      , ledger.ref
				      , ledger.ref_type
				      , ledger.from_id
				      , ledger.voucher
				      , ledger.vouch_seq
				      , ledger.check_num
				      , ledger.acct_unit1
				      , ledger.acct_unit2
				      , ledger.acct_unit3
				      , ledger.acct_unit4
				      , ledger.vend_num
				      , ledger.matl_trans_num
				      , ledger.check_date
				
				      , (CASE WHEN ledger.dom_amount > 0 THEN ledger.dom_amount ELSE 0 END) dr_amt
				      , (CASE WHEN ledger.dom_amount < 0 THEN - ledger.dom_amount ELSE 0 END) cr_amt
				
				      , CASE WHEN @iCheckFlag = 1 and ledger.NoteExistsFlag = 1
				         THEN ledger.RowPointer
				         ELSE NULL END  RowPointer
				
				      , Case when @iCheckFlag = 1
				         THEN ledger.NoteExistsFlag
				         ELSE 0 END NoteExists
				      , convert(varchar(12),ledger.trans_date,112) + convert(varchar(50), ledger.trans_num) as OrderByColumn
				
				   FROM chart
				   INNER JOIN ", (sQLUtil.SQLEqual(AnalyticalLedger, 0) == true ? "ledger" : "ana_ledger"), @" AS ledger ON ledger.acct = chart.acct
				      WHERE chart.type <> 'D'");
			if (sQLUtil.SQLEqual(AccountStarting, AccountEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND chart.acct = @AccountStarting");

			}
			else
			{
				if (AccountStarting != null && AccountEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND chart.acct BETWEEN @AccountStarting AND @AccountEnding");

				}
				else
				{
					if (AccountStarting == null && AccountEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND chart.acct <= @AccountEnding");

					}
					else
					{
						if (AccountStarting != null && AccountEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND chart.acct >= @AccountStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(TransNumStarting, TransNumEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.trans_num = @TransNumStarting");

			}
			else
			{
				if (TransNumStarting != null && TransNumEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.trans_num BETWEEN @TransNumStarting AND @TransNumEnding");

				}
				else
				{
					if (TransNumStarting == null && TransNumEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND ledger.trans_num <= @TransNumEnding");

					}
					else
					{
						if (TransNumStarting != null && TransNumEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.trans_num >= @TransNumStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(TransDateStarting, TransDateEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.trans_date = @TransDateStarting");

			}
			else
			{
				if (TransDateStarting != null && TransDateEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.trans_date BETWEEN @TransDateStarting AND @TransDateEnding");

				}
				else
				{
					if (TransDateStarting == null && TransDateEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND ledger.trans_date <= @TransDateEnding");

					}
					else
					{
						if (TransDateStarting != null && TransDateEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.trans_date >= @TransDateStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(CheckDateStarting, CheckDateEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.check_date = @CheckDateStarting");

			}
			else
			{
				if (CheckDateStarting != null && CheckDateEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.check_date BETWEEN @CheckDateStarting AND @CheckDateEnding");

				}
				else
				{
					if (CheckDateStarting == null && CheckDateEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.check_date IS NULL OR ledger.check_date <= @CheckDateEnding)");

					}
					else
					{
						if (CheckDateStarting != null && CheckDateEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.check_date >= @CheckDateStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(VendNumStarting, VendNumEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.vend_num = @VendNumStarting");

			}
			else
			{
				if (VendNumStarting != null && VendNumEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.vend_num BETWEEN @VendNumStarting AND @VendNumEnding");

				}
				else
				{
					if (VendNumStarting == null && VendNumEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.vend_num IS NULL OR ledger.vend_num <= @VendNumEnding)");

					}
					else
					{
						if (VendNumStarting != null && VendNumEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.vend_num >= @VendNumStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(VoucherStarting, VoucherEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.voucher = @VoucherStarting");

			}
			else
			{
				if (VoucherStarting != null && VoucherEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.voucher BETWEEN @VoucherStarting AND @VoucherEnding");

				}
				else
				{
					if (VoucherStarting == null && VoucherEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.voucher IS NULL OR ledger.voucher <= @VoucherEnding)");

					}
					else
					{
						if (VoucherStarting != null && VoucherEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.voucher >= @VoucherStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(RefStarting, RefEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.ref = @RefStarting");

			}
			else
			{
				if (RefStarting != null && RefEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.ref BETWEEN @RefStarting AND @RefEnding");

				}
				else
				{
					if (RefStarting == null && RefEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.ref IS NULL OR ledger.ref <= @RefEnding)");

					}
					else
					{
						if (RefStarting != null && RefEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.ref >= @RefStarting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(AcctUnit1Starting, AcctUnit1Ending) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit1 = @AcctUnit1Starting");

			}
			else
			{
				if (AcctUnit1Starting != null && AcctUnit1Ending != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit1 BETWEEN @AcctUnit1Starting AND @AcctUnit1Ending");

				}
				else
				{
					if (AcctUnit1Starting == null && AcctUnit1Ending != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.acct_unit1 IS NULL OR ledger.acct_unit1 <= @AcctUnit1Ending)");

					}
					else
					{
						if (AcctUnit1Starting != null && AcctUnit1Ending == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit1 >= @AcctUnit1Starting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(AcctUnit2Starting, AcctUnit2Ending) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit2 = @AcctUnit2Starting");

			}
			else
			{
				if (AcctUnit2Starting != null && AcctUnit2Ending != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit2 BETWEEN @AcctUnit2Starting AND @AcctUnit2Ending");

				}
				else
				{
					if (AcctUnit2Starting == null && AcctUnit2Ending != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.acct_unit2 IS NULL OR ledger.acct_unit2 <= @AcctUnit2Ending)");

					}
					else
					{
						if (AcctUnit2Starting != null && AcctUnit2Ending == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit2 >= @AcctUnit2Starting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(AcctUnit3Starting, AcctUnit3Ending) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit3 = @AcctUnit3Starting");

			}
			else
			{
				if (AcctUnit3Starting != null && AcctUnit3Ending != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit3 BETWEEN @AcctUnit3Starting AND @AcctUnit3Ending");

				}
				else
				{
					if (AcctUnit3Starting == null && AcctUnit3Ending != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.acct_unit3 IS NULL OR ledger.acct_unit3 <= @AcctUnit3Ending)");

					}
					else
					{
						if (AcctUnit3Starting != null && AcctUnit3Ending == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit3 >= @AcctUnit3Starting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(AcctUnit4Starting, AcctUnit4Ending) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit4 = @AcctUnit4Starting");

			}
			else
			{
				if (AcctUnit4Starting != null && AcctUnit4Ending != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit4 BETWEEN @AcctUnit4Starting AND @AcctUnit4Ending");

				}
				else
				{
					if (AcctUnit4Starting == null && AcctUnit4Ending != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.acct_unit4 IS NULL OR ledger.acct_unit4 <= @AcctUnit4Ending)");

					}
					else
					{
						if (AcctUnit4Starting != null && AcctUnit4Ending == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.acct_unit4 >= @AcctUnit4Starting");

						}

					}

				}

			}
			if (sQLUtil.SQLEqual(CheckNumStarting, CheckNumEnding) == true)
			{
				SQL = stringUtil.Concat(SQL, " AND ledger.check_num = @CheckNumStarting");

			}
			else
			{
				if (CheckNumStarting != null && CheckNumEnding != null)
				{
					SQL = stringUtil.Concat(SQL, " AND ledger.check_num BETWEEN @CheckNumStarting AND @CheckNumEnding");

				}
				else
				{
					if (CheckNumStarting == null && CheckNumEnding != null)
					{
						SQL = stringUtil.Concat(SQL, " AND (ledger.check_num IS NULL OR ledger.check_num <= @CheckNumEnding)");

					}
					else
					{
						if (CheckNumStarting != null && CheckNumEnding == null)
						{
							SQL = stringUtil.Concat(SQL, " AND ledger.check_num >= @CheckNumStarting");

						}

					}

				}

			}
			SQL = stringUtil.Concat(SQL, @"
				ORDER BY chart.acct, OrderByColumn");

			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQL
			, "  @AccountStarting AcctType, @AccountEnding AcctType, @TransNumStarting MatlTransNumType, @TransNumEnding MatlTransNumType, @TransDateStarting DateType, @TransDateEnding DateType, @CheckDateStarting DateType, @CheckDateEnding DateType, @VendNumStarting VendNumType, @VendNumEnding VendNumType, @VoucherStarting InvNumVoucherType, @VoucherEnding InvNumVoucherType, @RefStarting ReferenceType, @RefEnding ReferenceType, @AcctUnit1Starting UnitCode1Type, @AcctUnit1Ending UnitCode1Type, @AcctUnit2Starting UnitCode2Type, @AcctUnit2Ending UnitCode2Type, @AcctUnit3Starting UnitCode3Type, @AcctUnit3Ending UnitCode3Type, @AcctUnit4Starting UnitCode4Type, @AcctUnit4Ending UnitCode4Type, @CheckNumStarting GlCheckNumType, @CheckNumEnding GlCheckNumType, @iCheckFlag BIT"
			, AccountStarting
			, AccountEnding
			, TransNumStarting
			, TransNumEnding
			, TransDateStarting
			, TransDateEnding
			, CheckDateStarting
			, CheckDateEnding
			, VendNumStarting
			, VendNumEnding
			, VoucherStarting
			, VoucherEnding
			, RefStarting
			, RefEnding
			, AcctUnit1Starting
			, AcctUnit1Ending
			, AcctUnit2Starting
			, AcctUnit2Ending
			, AcctUnit3Starting
			, AcctUnit3Ending
			, AcctUnit4Starting
			, AcctUnit4Ending
			, CheckNumStarting
			, CheckNumEnding
			, iCheck);
			/* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
			Data = execResult.Data;

			this.transactionFactory.CommitTransaction("");

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);

			#endregion ExecuteMethodCall

			return (Data, Severity);
		}

	}
}
