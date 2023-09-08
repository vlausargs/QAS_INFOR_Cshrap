//PROJECT NAME: Finance
//CLASS NAME: Home_MetricPaymentComparison.cs

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

namespace CSI.Finance
{
	public class Home_MetricPaymentComparison : IHome_MetricPaymentComparison
	{
		
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IPeriodsGetDates iPeriodsGetDates;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ICurrCnvt iCurrCnvt;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPerGet iPerGet;
		readonly IHome_MetricPaymentComparisonCRUD iHome_MetricPaymentComparisonCRUD;
		
		public Home_MetricPaymentComparison(
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IPeriodsGetDates iPeriodsGetDates,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ICurrCnvt iCurrCnvt,
			ISQLValueComparerUtil sQLUtil,
			IPerGet iPerGet,
			IHome_MetricPaymentComparisonCRUD iHome_MetricPaymentComparisonCRUD)
		{
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.iPeriodsGetDates = iPeriodsGetDates;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.iCurrCnvt = iCurrCnvt;
			this.sQLUtil = sQLUtil;
			this.iPerGet = iPerGet;
			this.iHome_MetricPaymentComparisonCRUD = iHome_MetricPaymentComparisonCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Home_MetricPaymentComparisonSp (
			string SiteGroup = null)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			string Infobar = null;
			DateTime? Today = null;
			DateTime? PeriodStart1 = null;
			DateTime? PeriodStart2 = null;
			DateTime? PeriodStart3 = null;
			DateTime? PeriodStart4 = null;
			DateTime? PeriodStart5 = null;
			DateTime? PeriodStart6 = null;
			DateTime? PeriodStart7 = null;
			DateTime? PeriodStart8 = null;
			DateTime? PeriodStart9 = null;
			DateTime? PeriodStart10 = null;
			DateTime? PeriodEnd1 = null;
			DateTime? PeriodEnd2 = null;
			DateTime? PeriodEnd3 = null;
			DateTime? PeriodEnd4 = null;
			DateTime? PeriodEnd5 = null;
			DateTime? PeriodEnd6 = null;
			DateTime? PeriodEnd7 = null;
			DateTime? PeriodEnd8 = null;
			DateTime? PeriodEnd9 = null;
			DateTime? PeriodEnd10 = null;
			DateTime? PerStart = null;
			DateTime? PerEnd = null;
			int? i = null;
			int? FirstFlag = null;
			decimal? PeriodPaymentIn1 = null;
			decimal? PeriodPaymentIn2 = null;
			decimal? PeriodPaymentIn3 = null;
			decimal? PeriodPaymentIn4 = null;
			decimal? PeriodPaymentIn5 = null;
			decimal? PeriodPaymentIn6 = null;
			decimal? PeriodPaymentOut1 = null;
			decimal? PeriodPaymentOut2 = null;
			decimal? PeriodPaymentOut3 = null;
			decimal? PeriodPaymentOut4 = null;
			decimal? PeriodPaymentOut5 = null;
			decimal? PeriodPaymentOut6 = null;
			string Site = null;
			string SiteList = null;
			string DomCurrCode = null;
			decimal? Amount = null;
			string SiteRef = null;
			string ArtranCurrCode = null;
			string VendorCurrCode = null;
			decimal? TRate = null;
			int? Seq = null;
			int? CurrentPeriod = null;
			int? PeriodsFiscalYear = null;
			ICollectionLoadResponse site_group_crsLoadResponseForCursor = null;
			int site_group_crs_CursorFetch_Status = -1;
			int site_group_crs_CursorCounter = -1;
			ICollectionLoadResponse currCrsLoadResponseForCursor = null;
			int currCrs_CursorFetch_Status = -1;
			int currCrs_CursorCounter = -1;
			ICollectionLoadResponse curr2CrsLoadResponseForCursor = null;
			int curr2Crs_CursorFetch_Status = -1;
			int curr2Crs_CursorCounter = -1;
			if (this.iHome_MetricPaymentComparisonCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");

                this.iHome_MetricPaymentComparisonCRUD.Optional_ModuleInsertSelect();

				while (this.iHome_MetricPaymentComparisonCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_MetricPaymentComparisonCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_MetricPaymentComparisonCRUD.AltExtGen_Home_MetricPaymentComparisonSp (ALTGEN_SpName,
						SiteGroup);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}

                    this.iHome_MetricPaymentComparisonCRUD.Tv_ALTGEN2Delete(ALTGEN_SpName);

                }

            }
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricPaymentComparisonSp") != null)
			{
				var EXTGEN = this.iHome_MetricPaymentComparisonCRUD.AltExtGen_Home_MetricPaymentComparisonSp("dbo.EXTGEN_Home_MetricPaymentComparisonSp",
					SiteGroup);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			if (this.scalarFunction.Execute<int?>(
				"OBJECT_ID",
				"tempdb..#Artran")== null)
			{
				
				this.sQLExpressionExecutor.Execute(@"Declare
					@SiteRef SiteType
					,@CustNum CustNumType
					,@DueDate DateType
					,@InvNum InvNumType
					,@InvSeq ArInvSeqType
					,@CheckSeq ArCheckNumType
					,@Amount AmountType
					,@ArtranCurrCode CurrCodeType
					SELECT @SiteRef AS SiteRef,
					       @CustNum AS CustNum,
					       @DueDate AS DueDate,
					       @InvNum AS InvNum,
					       @InvSeq AS InvSeq,
					       @CheckSeq AS CheckSeq,
					       @Amount AS Amount,
					       @ArtranCurrCode AS CustaddrCurrCode
					INTO   #Artran
					WHERE  1 = 2");
				this.sQLExpressionExecutor.Execute(@"ALTER TABLE #Artran
					    ADD seq INT IDENTITY");
				this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX ArtranSeq
					    ON #Artran(seq)");
				
			}
			if (this.scalarFunction.Execute<int?>(
				"OBJECT_ID",
				"tempdb..#Aptrxp")== null)
			{
				
				this.sQLExpressionExecutor.Execute(@"Declare
					@SiteRef SiteType
					,@VendNum VendNumType
					,@DistDate DateType
					,@Voucher VoucherType
					,@VouchSeq VouchSeqType
					,@Amount AmountType
					,@VendorCurrCode CurrCodeType
					SELECT @SiteRef AS SiteRef,
					       @VendNum AS VendNum,
					       @DistDate AS DistDate,
					       @Voucher AS Voucher,
					       @VouchSeq AS VouchSeq,
					       @Amount AS Amount,
					       @VendorCurrCode AS VendorCurrCode
					INTO   #Aptrxp
					WHERE  1 = 2");
				
			}
			this.sQLExpressionExecutor.Execute(@"ALTER TABLE #Aptrxp
				    ADD seq INT IDENTITY");
			this.sQLExpressionExecutor.Execute(@"CREATE UNIQUE INDEX AptrxpSeq
				    ON #Aptrxp(seq)");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @results TABLE (
				    PaymentIn  AmtTotType   ,
				    PaymentOut AmtTotType   ,
				    PeriodEnd  NVARCHAR (10));
				SELECT * into #tv_results from @results");
			Severity = 0;
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			SiteList = null;
			#region Cursor Statement
			site_group_crsLoadResponseForCursor = this.iHome_MetricPaymentComparisonCRUD.Site_GroupSelect(SiteGroup);
			site_group_crs_CursorFetch_Status = site_group_crsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			site_group_crs_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				site_group_crs_CursorCounter++;
				if(site_group_crsLoadResponseForCursor.Items.Count > site_group_crs_CursorCounter)
				{
					Site = site_group_crsLoadResponseForCursor.Items[site_group_crs_CursorCounter].GetValue<string>(0);
				}
				site_group_crs_CursorFetch_Status = (site_group_crs_CursorCounter == site_group_crsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(site_group_crs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				SiteList = stringUtil.Concat(stringUtil.IsNull(
					SiteList,
					""), Site, ",");
				(DomCurrCode, rowCount) = this.iHome_MetricPaymentComparisonCRUD.Currparms_AllLoad(Site, DomCurrCode);
				
			}
			//Deallocate Cursor site_group_crs
			(Site, rowCount) = this.iHome_MetricPaymentComparisonCRUD.ParmsLoad(Site);
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: PerGetSp
			var PerGet = this.iPerGet.PerGetSp(
				Date: Today,
				CurrentPeriod: CurrentPeriod,
				Infobar: Infobar,
				Site: Site,
				PeriodsFiscalYear: PeriodsFiscalYear);
			Severity = PerGet.ReturnCode;
			CurrentPeriod = PerGet.CurrentPeriod;
			Infobar = PerGet.Infobar;
			PeriodsFiscalYear = PerGet.PeriodsFiscalYear;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLGreaterThan(Severity, 0) == true)
			{
				goto EOF;
				
			}
			FirstFlag = 0;
			i = 6;
			while (sQLUtil.SQLGreaterThan(i, 0) == true)
			{
				PerStart = null;
				if (sQLUtil.SQLEqual(CurrentPeriod, 0) == true)
				{
					if (sQLUtil.SQLEqual(FirstFlag, 1) == true)
					{
						
						break;
						
					}
					CurrentPeriod = 13;
					PeriodsFiscalYear = (int?)(PeriodsFiscalYear - 1);
					FirstFlag = 1;
					
				}
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: PeriodsGetDatesSp
				var PeriodsGetDates = this.iPeriodsGetDates.PeriodsGetDatesSp(
					FiscalYear: PeriodsFiscalYear,
					Period: CurrentPeriod,
					Site: Site,
					PerStart: PerStart,
					PerEnd: PerEnd,
					Infobar: Infobar);
				Severity = PeriodsGetDates.ReturnCode;
				PerStart = PeriodsGetDates.PerStart;
				PerEnd = PeriodsGetDates.PerEnd;
				Infobar = PeriodsGetDates.Infobar;
				
				#endregion ExecuteMethodCall
				
				if (PerStart!= null)
				{
					PerStart = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(PerStart));
					PerEnd = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(PerEnd));
					if (sQLUtil.SQLEqual(i, 6) == true)
					{
						PeriodStart6 = convertToUtil.ToDateTime(PerStart);
						PeriodEnd6 = convertToUtil.ToDateTime(PerEnd);
						
					}
					else
					{
						if (sQLUtil.SQLEqual(i, 5) == true)
						{
							PeriodStart5 = convertToUtil.ToDateTime(PerStart);
							PeriodEnd5 = convertToUtil.ToDateTime(PerEnd);
							
						}
						else
						{
							if (sQLUtil.SQLEqual(i, 4) == true)
							{
								PeriodStart4 = convertToUtil.ToDateTime(PerStart);
								PeriodEnd4 = convertToUtil.ToDateTime(PerEnd);
								
							}
							else
							{
								if (sQLUtil.SQLEqual(i, 3) == true)
								{
									PeriodStart3 = convertToUtil.ToDateTime(PerStart);
									PeriodEnd3 = convertToUtil.ToDateTime(PerEnd);
									
								}
								else
								{
									if (sQLUtil.SQLEqual(i, 2) == true)
									{
										PeriodStart2 = convertToUtil.ToDateTime(PerStart);
										PeriodEnd2 = convertToUtil.ToDateTime(PerEnd);
										
									}
									else
									{
										if (sQLUtil.SQLEqual(i, 1) == true)
										{
											PeriodStart1 = convertToUtil.ToDateTime(PerStart);
											PeriodEnd1 = convertToUtil.ToDateTime(PerEnd);
											
										}
										
									}
									
								}
								
							}
							
						}
						
					}
					i = (int?)(i - 1);
					FirstFlag = 0;
					
				}
				CurrentPeriod = (int?)(CurrentPeriod - 1);
				
			}
			PerStart = convertToUtil.ToDateTime(stringUtil.IsNull(
				stringUtil.IsNull(
					stringUtil.IsNull(
						stringUtil.IsNull(
							stringUtil.IsNull(
								stringUtil.IsNull(
									stringUtil.IsNull(
										stringUtil.IsNull(
											stringUtil.IsNull(
												PeriodStart1,
												PeriodStart2),
											PeriodStart3),
										PeriodStart4),
									PeriodStart5),
								PeriodStart6),
							PeriodStart7),
						PeriodStart8),
					PeriodStart9),
				PeriodStart10));
			PerEnd = convertToUtil.ToDateTime(stringUtil.IsNull(
				stringUtil.IsNull(
					stringUtil.IsNull(
						stringUtil.IsNull(
							stringUtil.IsNull(
								stringUtil.IsNull(
									stringUtil.IsNull(
										stringUtil.IsNull(
											stringUtil.IsNull(
												PeriodEnd10,
												PeriodEnd9),
											PeriodEnd8),
										PeriodEnd7),
									PeriodEnd6),
								PeriodEnd5),
							PeriodEnd4),
						PeriodEnd3),
					PeriodEnd2),
				PeriodEnd1));
			if (PerStart== null)
			{
				goto EOF;
				
			}
			this.iHome_MetricPaymentComparisonCRUD.Artran1Insert(PerStart, PerEnd, SiteList);
			#region Cursor Statement
			currCrsLoadResponseForCursor = this.iHome_MetricPaymentComparisonCRUD.Artran2Select(DomCurrCode);
			currCrs_CursorFetch_Status = currCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			currCrs_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				currCrs_CursorCounter++;
				if(currCrsLoadResponseForCursor.Items.Count > currCrs_CursorCounter)
				{
					ArtranCurrCode = currCrsLoadResponseForCursor.Items[currCrs_CursorCounter].GetValue<string>(0);
					Amount = currCrsLoadResponseForCursor.Items[currCrs_CursorCounter].GetValue<decimal?>(1);
					Seq = currCrsLoadResponseForCursor.Items[currCrs_CursorCounter].GetValue<int?>(2);
					SiteRef = currCrsLoadResponseForCursor.Items[currCrs_CursorCounter].GetValue<string>(3);
				}
				currCrs_CursorFetch_Status = (currCrs_CursorCounter == currCrsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(currCrs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				TRate = null;
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: CurrCnvtSp
				var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
					CurrCode: ArtranCurrCode,
					FromDomestic: 0,
					UseBuyRate: 0,
					RoundResult: 1,
					Date: null,
					RoundPlaces: null,
					UseCustomsAndExciseRates: null,
					ForceRate: null,
					FindTTFixed: null,
					TRate: TRate,
					Infobar: Infobar,
					Amount1: Amount,
					Result1: Amount,
					Site: SiteRef,
					DomCurrCode: DomCurrCode);
				Severity = CurrCnvt.ReturnCode;
				TRate = CurrCnvt.TRate;
				Infobar = CurrCnvt.Infobar;
				Amount = CurrCnvt.Result1;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					
					break;
					
				}
				this.iHome_MetricPaymentComparisonCRUD.Artran3Update(Seq, Amount);
				
			}
			//Deallocate Cursor currCrs
			this.iHome_MetricPaymentComparisonCRUD.Aptrxp1Insert(PerStart, PerEnd, SiteList);
			#region Cursor Statement
			curr2CrsLoadResponseForCursor = this.iHome_MetricPaymentComparisonCRUD.Aptrxp2Select(DomCurrCode);
			curr2Crs_CursorFetch_Status = curr2CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			curr2Crs_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLEqual(1, 1) == true)
			{
				curr2Crs_CursorCounter++;
				if(curr2CrsLoadResponseForCursor.Items.Count > curr2Crs_CursorCounter)
				{
					VendorCurrCode = curr2CrsLoadResponseForCursor.Items[curr2Crs_CursorCounter].GetValue<string>(0);
					Amount = curr2CrsLoadResponseForCursor.Items[curr2Crs_CursorCounter].GetValue<decimal?>(1);
					Seq = curr2CrsLoadResponseForCursor.Items[curr2Crs_CursorCounter].GetValue<int?>(2);
					SiteRef = curr2CrsLoadResponseForCursor.Items[curr2Crs_CursorCounter].GetValue<string>(3);
				}
				curr2Crs_CursorFetch_Status = (curr2Crs_CursorCounter == curr2CrsLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLNotEqual(curr2Crs_CursorFetch_Status, 0) == true)
				{
					
					break;
					
				}
				TRate = null;
				
				#region CRUD ExecuteMethodCall
				
				//Please Generate the bounce for this stored procedure: CurrCnvtSp
				var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(
					CurrCode: VendorCurrCode,
					FromDomestic: 0,
					UseBuyRate: 1,
					RoundResult: 1,
					Date: null,
					RoundPlaces: null,
					UseCustomsAndExciseRates: null,
					ForceRate: null,
					FindTTFixed: null,
					TRate: TRate,
					Infobar: Infobar,
					Amount1: Amount,
					Result1: Amount,
					Site: SiteRef,
					DomCurrCode: DomCurrCode);
				Severity = CurrCnvt1.ReturnCode;
				TRate = CurrCnvt1.TRate;
				Infobar = CurrCnvt1.Infobar;
				Amount = CurrCnvt1.Result1;
				
				#endregion ExecuteMethodCall
				
				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					
					break;
					
				}
				this.iHome_MetricPaymentComparisonCRUD.Aptrxp3Update(Seq, Amount);
				
			}
			//Deallocate Cursor curr2Crs
			(PeriodPaymentIn1, PeriodPaymentIn2, PeriodPaymentIn3, PeriodPaymentIn4, PeriodPaymentIn5, PeriodPaymentIn6, rowCount) = this.iHome_MetricPaymentComparisonCRUD.Artran4Load(PeriodStart1,
				 PeriodEnd1,
				 PeriodStart2,
				 PeriodEnd2,
				 PeriodStart3,
				 PeriodEnd3,
				 PeriodStart4,
				 PeriodEnd4,
				 PeriodStart5,
				 PeriodEnd5,
				 PeriodStart6,
				 PeriodEnd6,
				 PeriodPaymentIn1,
				 PeriodPaymentIn2,
				 PeriodPaymentIn3,
				 PeriodPaymentIn4,
				 PeriodPaymentIn5,
				 PeriodPaymentIn6);
			(PeriodPaymentOut1, PeriodPaymentOut2, PeriodPaymentOut3, PeriodPaymentOut4, PeriodPaymentOut5, PeriodPaymentOut6, rowCount) = this.iHome_MetricPaymentComparisonCRUD.Aptrxp4Load(PeriodStart1,
				 PeriodEnd1,
				 PeriodStart2,
				 PeriodEnd2,
				 PeriodStart3,
				 PeriodEnd3,
				 PeriodStart4,
				 PeriodEnd4,
				 PeriodStart5,
				 PeriodEnd5,
				 PeriodStart6,
				 PeriodEnd6,
				 PeriodPaymentOut1,
				 PeriodPaymentOut2,
				 PeriodPaymentOut3,
				 PeriodPaymentOut4,
				 PeriodPaymentOut5,
				 PeriodPaymentOut6);
			EOF: ;
			this.iHome_MetricPaymentComparisonCRUD.NontableInsert(PeriodPaymentIn3, PeriodPaymentOut3, PeriodEnd3);

			this.iHome_MetricPaymentComparisonCRUD.NontableInsert(PeriodPaymentIn4, PeriodPaymentOut4, PeriodEnd4);

			this.iHome_MetricPaymentComparisonCRUD.NontableInsert(PeriodPaymentIn5, PeriodPaymentOut5, PeriodEnd5);

			this.iHome_MetricPaymentComparisonCRUD.NontableInsert(PeriodPaymentIn6, PeriodPaymentOut6, PeriodEnd6);

			var tv_resultsLoadResponse = this.iHome_MetricPaymentComparisonCRUD.Tv_ResultsSelect();
			Data = tv_resultsLoadResponse;
			return (Data, Severity);
			
		}
		
	}
}
