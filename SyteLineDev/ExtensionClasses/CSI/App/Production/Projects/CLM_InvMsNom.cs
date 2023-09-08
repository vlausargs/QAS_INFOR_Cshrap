//PROJECT NAME: Production
//CLASS NAME: CLM_InvMsNom.cs

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
	public class CLM_InvMsNom : ICLM_InvMsNom
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IExecuteDynamicSQL iExecuteDynamicSQL;
		readonly IProjInvMsLoadTot iProjInvMsLoadTot;
		readonly IProjGetMsPeriod iProjGetMsPeriod;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly IRaiseError raiseError;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_InvMsNomCRUD iCLM_InvMsNomCRUD;

		public CLM_InvMsNom(IBunchedLoadCollection bunchedLoadCollection,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IExecuteDynamicSQL iExecuteDynamicSQL,
			IProjInvMsLoadTot iProjInvMsLoadTot,
			IProjGetMsPeriod iProjGetMsPeriod,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			IRaiseError raiseError,
			ISQLValueComparerUtil sQLUtil,
			ICLM_InvMsNomCRUD iCLM_InvMsNomCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iExecuteDynamicSQL = iExecuteDynamicSQL;
			this.iProjInvMsLoadTot = iProjInvMsLoadTot;
			this.iProjGetMsPeriod = iProjGetMsPeriod;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.raiseError = raiseError;
			this.sQLUtil = sQLUtil;
			this.iCLM_InvMsNomCRUD = iCLM_InvMsNomCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_InvMsNomSp(
			DateTime? PActDate,
			DateTime? PPlanDate,
			string Filter)
		{

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{

				ICollectionLoadResponse Data = null;

				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? Severity = null;
				string Infobar = null;
				int? Month = null;
				int? Year = null;
				int? LastMonth = null;
				int? LastYear = null;
				DateTime? UseDate = null;
				string ProjNum = null;
				string InvMsNum = null;
				decimal? ActInvAmt = null;
				int? Nominated = null;
				DateTime? PlanDate = null;
				DateTime? ActDate = null;
				int? DerCurrentPeriod = null;
				DateTime? DerCurrentPeriodStart = null;
				DateTime? DerCurrentPeriodEnd = null;
				decimal? DerTotPerPlanInvAmt = null;
				decimal? DerTotPerNomPlanInvAmt = null;
				decimal? DerTotYrPlanInvAmt = null;
				decimal? DerTotYrNomPlanInvAmt = null;
				decimal? DerTotPerActInvAmt = null;
				decimal? DerTotPerNomActInvAmt = null;
				decimal? DerTotYrActInvAmt = null;
				decimal? DerTotYrNomActInvAmt = null;
				int? DerNominated = null;
				decimal? DerActInvAmt = null;
				DateTime? DerActDate = null;

				string SelectionClause = null;
				string FromClause = null;
				string WhereStr = null;
				ICollectionLoadResponse InvMsNomCrsLoadResponseForCursor = null;
				int InvMsNomCrs_CursorFetch_Status = -1;
				int InvMsNomCrs_CursorCounter = -1;
				if (this.iCLM_InvMsNomCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
					var optional_module1LoadResponse = this.iCLM_InvMsNomCRUD.Optional_Module1Select();
					foreach (var optional_module1Item in optional_module1LoadResponse.Items)
					{
						optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_InvMsNomSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
					};

					var optional_module1RequiredColumns = new List<string>() { "SpName" };

					optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

					this.iCLM_InvMsNomCRUD.Optional_Module1Insert(optional_module1LoadResponse);

					while (this.iCLM_InvMsNomCRUD.Tv_ALTGENForExists())
					{
						ALTGEN_SpName = this.iCLM_InvMsNomCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
						var ALTGEN = this.iCLM_InvMsNomCRUD.AltExtGen_CLM_InvMsNomSp(ALTGEN_SpName,
							PActDate,
							PPlanDate,
							Filter);
						ALTGEN_Severity = ALTGEN.ReturnCode;

						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);

						}
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
						/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
						var tv_ALTGEN2LoadResponse = this.iCLM_InvMsNomCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
						this.iCLM_InvMsNomCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

					}

				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_InvMsNomSp") != null)
				{
					var EXTGEN = this.iCLM_InvMsNomCRUD.AltExtGen_CLM_InvMsNomSp("dbo.EXTGEN_CLM_InvMsNomSp",
						PActDate,
						PPlanDate,
						Filter);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				if (this.scalarFunction.Execute<int?>(
					"OBJECT_ID",
					"tempdb..#InvMsNom") == null)
				{

					this.sQLExpressionExecutor.Execute(@"Declare
						@ProjNum ProjNumType
						,@InvMsNum ProjMsNumType
						,@Description DescriptionType
						,@PlanInvAmt AmtTotType
						,@ActInvAmt AmtTotType
						,@Nominated ListYesNoType
						,@PlanDate DateType
						,@ActDate DateType
						,@TaxCode1 TaxCodeType
						,@TaxCode2 TaxCodeType
						,@TaxCodeDescription1 DescriptionType
						,@TaxCodeDescription2 DescriptionType
						,@TaxableAmt AmtTotType
						,@CreateInvoiceForAdvPmt ListYesNoType
						,@AdvPmtDeductionAmt AmountType
						,@InWorkFlow FlagNyType
						,@NoteExistsFlag FlagNyType
						,@DerCurrentPeriod FinPeriodType
						,@DerCurrentPeriodStart DateType
						,@DerCurrentPeriodEnd DateType
						,@DerTotPerPlanInvAmt AmtTotType
						,@DerTotPerNomPlanInvAmt AmtTotType
						,@DerTotYrPlanInvAmt AmtTotType
						,@DerTotYrNomPlanInvAmt AmtTotType
						,@DerTotPerActInvAmt AmtTotType
						,@DerTotYrNomActInvAmt AmtTotType
						,@DerNominated ListYesNoType
						,@DerActInvAmt AmtTotType
						,@DerActDate DateType
						,@ProjFixedRate ListYesNoType
						,@ProjExchRate ExchRateType
						,@Cad0CurrCode CurrCodeType
						,@CurrAmtFormat InputMaskType
						,@CurrAmtTotFormat InputMaskType
						,@PlanFreight AmountType
						,@ActFreight AmountType
						,@PlanMiscCharges AmountType
						,@ActMiscCharges AmountType
						,@DerActInvTotal AmtTotType
						,@DerPlanInvTotal AmtTotType
						,@RowPointer RowPointerType
						SELECT @ProjNum AS proj_num,
						       @InvMsNum AS inv_ms_num,
						       @Description AS description,
						       @PlanInvAmt AS plan_inv_amt,
						       @ActInvAmt AS act_inv_amt,
						       @Nominated AS nominated,
						       @PlanDate AS plan_date,
						       @ActDate AS act_date,
						       @TaxCode1 AS tax_code1,
						       @TaxCode2 AS tax_code2,
						       @TaxCodeDescription1 AS tax_code_description1,
						       @TaxCodeDescription2 AS tax_code_description2,
						       @TaxableAmt AS taxable_amt,
						       @CreateInvoiceForAdvPmt AS create_invoice_for_adv_pmt,
						       @AdvPmtDeductionAmt AS adv_pmt_deduction_amt,
						       @InWorkFlow AS InWorkFlow,
						       @NoteExistsFlag AS NoteExistsFlag,
						       @DerCurrentPeriod AS DerCurrentPeriod,
						       @DerCurrentPeriodStart AS DerCurrentPeriodStart,
						       @DerCurrentPeriodEnd AS DerCurrentPeriodEnd,
						       @DerTotPerPlanInvAmt AS DerTotPerPlanInvAmt,
						       @DerTotPerNomPlanInvAmt AS DerTotPerNomPlanInvAmt,
						       @DerTotYrPlanInvAmt AS DerTotYrPlanInvAmt,
						       @DerTotYrNomPlanInvAmt AS DerTotYrNomPlanInvAmt,
						       @DerTotPerActInvAmt AS DerTotPerActInvAmt,
						       @DerTotYrNomPlanInvAmt AS DerTotPerNomActInvAmt,
						       @DerTotPerActInvAmt AS DerTotYrActInvAmt,
						       @DerTotYrNomActInvAmt AS DerTotYrNomActInvAmt,
						       @DerNominated AS DerNominated,
						       @DerActInvAmt AS DerActInvAmt,
						       @DerActDate AS DerActDate,
						       @ProjFixedRate AS ProjFixedRate,
						       @ProjExchRate AS ProjExchRate,
						       @Cad0CurrCode AS Cad0CurrCode,
						       @CurrAmtFormat AS CurrAmtFormat,
						       @CurrAmtTotFormat AS CurrAmtTotFormat,
						       @PlanFreight AS plan_freight,
						       @ActFreight AS act_freight,
						       @PlanMiscCharges AS plan_misc_charges,
						       @ActMiscCharges AS act_misc_charges,
						       @DerActInvTotal AS DerActInvTotal,
						       @DerPlanInvTotal AS DerPlanInvTotal,
						       @RowPointer AS RowPointer
						INTO   #InvMsNom
						WHERE  1 = 2");

				}
				this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX InvMsNomProj
					    ON #InvMsNom(proj_num, inv_ms_num)");
				if (Filter != null)
				{
					Filter = stringUtil.Replace(
						Filter,
						"ProjNum",
						"inv_ms.proj_num");
					Filter = stringUtil.Replace(
						Filter,
						"InvMsNum",
						"inv_ms_num");
					Filter = stringUtil.Replace(
						Filter,
						"CreateInvoiceForAdvPmt",
						"create_invoice_for_adv_pmt");
					Filter = stringUtil.Replace(
						Filter,
						"PlanInvAmt",
						"plan_inv_amt");
					Filter = stringUtil.Replace(
						Filter,
						"ActInvAmt",
						"act_inv_amt");
					Filter = stringUtil.Replace(
						Filter,
						"PlanDate",
						"plan_date");
					Filter = stringUtil.Replace(
						Filter,
						"ActDate",
						"act_date");
					Filter = stringUtil.Replace(
						Filter,
						"TaxCode1",
						"inv_ms.tax_code1");
					Filter = stringUtil.Replace(
						Filter,
						"TaxCode2",
						"inv_ms.tax_code2");
					Filter = stringUtil.Replace(
						Filter,
						"TaxCodeDescription1",
						"tc1.description");
					Filter = stringUtil.Replace(
						Filter,
						"TaxCodeDescription2",
						"tc2.description");
					Filter = stringUtil.Replace(
						Filter,
						"TaxableAmt",
						"taxable_amt");
					Filter = stringUtil.Replace(
						Filter,
						"PlanFreight",
						"inv_ms.plan_freight");
					Filter = stringUtil.Replace(
						Filter,
						"ActFreight",
						"inv_ms.act_freight");
					Filter = stringUtil.Replace(
						Filter,
						"PlanMiscCharges",
						"inv_ms.plan_misc_charges");
					Filter = stringUtil.Replace(
						Filter,
						"ActMiscCharges",
						"inv_ms.act_misc_charges");
					Filter = stringUtil.Replace(
						Filter,
						"ProjFixedRate",
						"proj.fixed_rate");
					Filter = stringUtil.Replace(
						Filter,
						"ProjExchRate",
						"proj.exch_rate");
					Filter = stringUtil.Replace(
						Filter,
						"Cad0CurrCode",
						"proj.curr_code");
					Filter = stringUtil.Replace(
						Filter,
						"CustaddrName",
						"custaddr.name");
					Filter = stringUtil.Replace(
						Filter,
						"Description",
						"inv_ms.description");
					Filter = stringUtil.Replace(
						Filter,
						"Nominated",
						"inv_ms.nominated");
					Filter = stringUtil.Replace(
						Filter,
						"NoRetention",
						"inv_ms.no_retention");
					Filter = stringUtil.Replace(
						Filter,
						"Posted",
						"inv_ms.posted");
					Filter = stringUtil.Replace(
						Filter,
						"ProjCustNum",
						"proj.cust_num");
					Filter = stringUtil.Replace(
						Filter,
						"ProjCustSeq",
						"proj.cust_seq");
					Filter = stringUtil.Replace(
						Filter,
						"ProjExpDate",
						"proj.exp_date");
					Filter = stringUtil.Replace(
						Filter,
						"ProjProjDesc",
						"proj.proj_desc");
					Filter = stringUtil.Replace(
						Filter,
						"ProjProjType",
						"proj.type");
					Filter = stringUtil.Replace(
						Filter,
						"ProjStat",
						"proj.stat");

				}
				SelectionClause = @"
					               SELECT
					                 inv_ms.proj_num
					               , inv_ms_num
					               , inv_ms.description
					               , plan_inv_amt
					               , act_inv_amt
					               , nominated
					               , plan_date
					               , act_date
					               , inv_ms.tax_code1
					               , inv_ms.tax_code2
					               , ISNULL(tc1.description, '')
					               , ISNULL(tc2.description, '')
					               , taxable_amt
					               , create_invoice_for_adv_pmt
					               , adv_pmt_deduction_amt
					               , inv_ms.InWorkflow
					               , inv_ms.NoteExistsFlag
					               , 0
					               , NULL
					               , NULL
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , 0
					               , NULL
					               , proj.fixed_rate
					               , proj.exch_rate
					               , proj.curr_code
					               , currency.amt_format
					               , currency.amt_tot_format
					               , inv_ms.plan_freight
					               , inv_ms.act_freight
					               , inv_ms.plan_misc_charges
					               , inv_ms.act_misc_charges
					               , ISNULL(inv_ms.act_inv_amt, 0)  + ISNULL(inv_ms.act_freight, 0)  + ISNULL(inv_ms.act_misc_charges, 0)
					               , ISNULL(inv_ms.plan_inv_amt, 0) + ISNULL(inv_ms.plan_freight, 0) + ISNULL(inv_ms.plan_misc_charges, 0)
					               , inv_ms.RowPointer
					               ";
				FromClause = @"
					               FROM inv_ms JOIN proj ON proj.proj_num = inv_ms.proj_num
					               LEFT OUTER JOIN taxcode AS tc1 ON tc1.tax_code = ISNULL(inv_ms.tax_code1, N'')
					                           AND tc1.tax_system = 1 AND tc1.tax_code_type IN (N'R', N'E')
					               LEFT OUTER JOIN taxcode AS tc2 ON tc2.tax_code = ISNULL(inv_ms.tax_code2, '')
					                           AND tc2.tax_system = 2 AND tc2.tax_code_type IN (N'R', N'E')
					               LEFT OUTER JOIN custaddr ON custaddr.cust_num = proj.cust_num
					                           AND custaddr.cust_seq = 0
					               LEFT OUTER JOIN currency ON currency.curr_code = proj.curr_code
					               ";
				WhereStr = "WHERE inv_ms.posted = 0 AND proj.type = N'P'";

				this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause LongListType
					,@FromClause LongListType
					,@WhereStr LongListType
					,@Filter LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereStr AS WhereClause,
					       N'ORDER BY proj_num, inv_ms_num' AS AdditionalClause,
					       N'proj_num, inv_ms_num' AS KeyColumns,
					       @Filter AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");
				var DynamicParametersLoadResponse = this.iCLM_InvMsNomCRUD.DynamicparametersSelect(SelectionClause, FromClause, WhereStr, Filter);

				this.iCLM_InvMsNomCRUD.DynamicparametersInsert(DynamicParametersLoadResponse);
				//Please Generate the bounce for this stored procedure:ExecuteDynamicSQLSp
				var InvMsNom1ExecResult = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
					NeedGetMoreRows: 0,
					Infobar: Infobar);
				this.iCLM_InvMsNomCRUD.Invmsnom1Insert(InvMsNom1ExecResult.Data);
				Infobar = InvMsNom1ExecResult.Infobar;
				Severity = 0;
				LastMonth = null;
				LastYear = null;
				#region Cursor Statement
				InvMsNomCrsLoadResponseForCursor = this.iCLM_InvMsNomCRUD.Invmsnom2Select();
				#endregion Cursor Statement
				InvMsNomCrs_CursorFetch_Status = InvMsNomCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
				InvMsNomCrs_CursorCounter = -1;

				while (sQLUtil.SQLEqual(Severity, 0) == true)
				{
					InvMsNomCrs_CursorCounter++;
					if (InvMsNomCrsLoadResponseForCursor.Items.Count > InvMsNomCrs_CursorCounter)
					{
						ProjNum = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<string>(0);
						InvMsNum = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<string>(1);
						ActInvAmt = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<decimal?>(2);
						Nominated = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<int?>(3);
						PlanDate = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<DateTime?>(4);
						ActDate = InvMsNomCrsLoadResponseForCursor.Items[InvMsNomCrs_CursorCounter].GetValue<DateTime?>(5);
					}
					InvMsNomCrs_CursorFetch_Status = (InvMsNomCrs_CursorCounter == InvMsNomCrsLoadResponseForCursor.Items.Count ? -1 : 0);

					if (sQLUtil.SQLNotEqual(InvMsNomCrs_CursorFetch_Status, 0) == true)
					{

						break;

					}
					if (ActDate == null)
					{
						UseDate = convertToUtil.ToDateTime(PlanDate);

					}
					else
					{
						UseDate = convertToUtil.ToDateTime(ActDate);

					}
					Month = (int?)(dateTimeUtil.Month<int?>(UseDate));
					Year = (int?)(dateTimeUtil.Year<int?>(UseDate));
					if (LastMonth == null || LastYear == null || sQLUtil.SQLNotEqual(LastMonth, Month) == true || sQLUtil.SQLNotEqual(LastYear, Year) == true)
					{
						LastMonth = Month;
						LastYear = Year;

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: ProjGetMsPeriodSp
						var ProjGetMsPeriod = this.iProjGetMsPeriod.ProjGetMsPeriodSp(
							MsPlanDate: PlanDate,
							MsActDate: ActDate,
							CurrentPeriod: DerCurrentPeriod,
							CurrentPeriodStart: DerCurrentPeriodStart,
							CurrentPeriodEnd: DerCurrentPeriodEnd,
							Infobar: Infobar);
						Severity = ProjGetMsPeriod.ReturnCode;
						DerCurrentPeriod = ProjGetMsPeriod.CurrentPeriod;
						DerCurrentPeriodStart = ProjGetMsPeriod.CurrentPeriodStart;
						DerCurrentPeriodEnd = ProjGetMsPeriod.CurrentPeriodEnd;
						Infobar = ProjGetMsPeriod.Infobar;

						#endregion ExecuteMethodCall

						if (sQLUtil.SQLEqual(Severity, 0) == true)
						{

							#region CRUD ExecuteMethodCall

							//Please Generate the bounce for this stored procedure: ProjInvMsLoadTotSp
							var ProjInvMsLoadTot = this.iProjInvMsLoadTot.ProjInvMsLoadTotSp(
								PCurrentPeriodStart: DerCurrentPeriodStart,
								PCurrentPeriodEnd: DerCurrentPeriodEnd,
								PTotPerPlanInvAmt: DerTotPerPlanInvAmt,
								PTotPerActInvAmt: DerTotPerActInvAmt,
								PTotPerNomPlanInvAmt: DerTotPerNomPlanInvAmt,
								PTotPerNomActInvAmt: DerTotPerNomActInvAmt,
								PTotYrPlanInvAmt: DerTotYrPlanInvAmt,
								PTotYrActInvAmt: DerTotYrActInvAmt,
								PTotYrNomPlanInvAmt: DerTotYrNomPlanInvAmt,
								PTotYrNomActInvAmt: DerTotYrNomActInvAmt);
							Severity = ProjInvMsLoadTot.ReturnCode;
							DerTotPerPlanInvAmt = ProjInvMsLoadTot.PTotPerPlanInvAmt;
							DerTotPerActInvAmt = ProjInvMsLoadTot.PTotPerActInvAmt;
							DerTotPerNomPlanInvAmt = ProjInvMsLoadTot.PTotPerNomPlanInvAmt;
							DerTotPerNomActInvAmt = ProjInvMsLoadTot.PTotPerNomActInvAmt;
							DerTotYrPlanInvAmt = ProjInvMsLoadTot.PTotYrPlanInvAmt;
							DerTotYrActInvAmt = ProjInvMsLoadTot.PTotYrActInvAmt;
							DerTotYrNomPlanInvAmt = ProjInvMsLoadTot.PTotYrNomPlanInvAmt;
							DerTotYrNomActInvAmt = ProjInvMsLoadTot.PTotYrNomActInvAmt;

							#endregion ExecuteMethodCall

						}

					}
					if (sQLUtil.SQLEqual(Severity, 0) == true)
					{
						DerNominated = Nominated;
						DerActInvAmt = ActInvAmt;
						DerActDate = convertToUtil.ToDateTime(ActDate);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #InvMsNom ADD tempTableId INT IDENTITY");
						var InvMsNom3LoadResponse = this.iCLM_InvMsNomCRUD.Invmsnom3Select(ProjNum, InvMsNum);
						this.iCLM_InvMsNomCRUD.Invmsnom3Update(DerCurrentPeriod, DerCurrentPeriodStart, DerCurrentPeriodEnd, DerTotPerPlanInvAmt, DerTotPerNomPlanInvAmt, DerTotYrPlanInvAmt, DerTotYrNomPlanInvAmt, DerTotPerActInvAmt, DerTotPerNomActInvAmt, DerTotYrActInvAmt, DerTotYrNomActInvAmt, DerNominated, DerActInvAmt, DerActDate, InvMsNom3LoadResponse);
						this.sQLExpressionExecutor.Execute("ALTER TABLE #InvMsNom DROP COLUMN tempTableId");

					}

				}
				//Deallocate Cursor InvMsNomCrs
				this.sQLExpressionExecutor.Execute("ALTER TABLE #DynamicParameters ADD tempTableId INT IDENTITY");
				/*Needs to load at least one column from the table: #DynamicParameters for delete, Loads the record based on its where and from clause, then deletes it by record.*/
				var DynamicParameters1LoadResponse = this.iCLM_InvMsNomCRUD.Dynamicparameters1Select();
				this.iCLM_InvMsNomCRUD.Dynamicparameters1Delete(DynamicParameters1LoadResponse);
				this.sQLExpressionExecutor.Execute("ALTER TABLE #DynamicParameters DROP COLUMN tempTableId");
				var nonTableLoadResponse = this.iCLM_InvMsNomCRUD.NontableSelect();
				Data = nonTableLoadResponse;
				this.iCLM_InvMsNomCRUD.NontableInsert(nonTableLoadResponse);

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
				var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(NeedGetMoreRows: 1);
				Severity = ExecuteDynamicSQL.ReturnCode;
				Data = ExecuteDynamicSQL.Data;

			#endregion ExecuteMethodCall

				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					raiseError.RaiseErrorSp(
						Infobar,
						Severity,
						1);

				}
				return (Data, Severity);

			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}

	}
}
