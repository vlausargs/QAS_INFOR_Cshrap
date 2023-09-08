//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricOnTimeShipment.cs

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
using CSI.Finance;

namespace CSI.Logistics.Customer
{
	public class Home_MetricOnTimeShipment : IHome_MetricOnTimeShipment
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IPeriodsGetDates iPeriodsGetDates;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IMidnightOf iMidnightOf;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPerGet iPerGet;
		readonly IHome_MetricOnTimeShipmentCRUD iHome_MetricOnTimeShipmentCRUD;
		
		public Home_MetricOnTimeShipment(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IPeriodsGetDates iPeriodsGetDates,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IMidnightOf iMidnightOf,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ISQLValueComparerUtil sQLUtil,
			IPerGet iPerGet,
			IHome_MetricOnTimeShipmentCRUD iHome_MetricOnTimeShipmentCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.iPeriodsGetDates = iPeriodsGetDates;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.iMidnightOf = iMidnightOf;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.sQLUtil = sQLUtil;
			this.iPerGet = iPerGet;
			this.iHome_MetricOnTimeShipmentCRUD = iHome_MetricOnTimeShipmentCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Home_MetricOnTimeShipmentSp (
			int? Count = 4,
			int? MultipleSites = 0,
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
			int? CurrentPeriod = null;
			int? PeriodsFiscalYear = null;
			string Site = null;
			DateTime? PerStart = null;
			DateTime? PerEnd = null;
			int? i = null;
			int? FirstFlag = null;
			decimal? PeriodTotal1 = null;
			decimal? PeriodTotal2 = null;
			decimal? PeriodTotal3 = null;
			decimal? PeriodTotal4 = null;
			decimal? PeriodTotal5 = null;
			decimal? PeriodTotal6 = null;
			decimal? PeriodTotal7 = null;
			decimal? PeriodTotal8 = null;
			decimal? PeriodTotal9 = null;
			decimal? PeriodTotal10 = null;
			decimal? PeriodOnTime1 = null;
			decimal? PeriodOnTime2 = null;
			decimal? PeriodOnTime3 = null;
			decimal? PeriodOnTime4 = null;
			decimal? PeriodOnTime5 = null;
			decimal? PeriodOnTime6 = null;
			decimal? PeriodOnTime7 = null;
			decimal? PeriodOnTime8 = null;
			decimal? PeriodOnTime9 = null;
			decimal? PeriodOnTime10 = null;
			if (this.iHome_MetricOnTimeShipmentCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iHome_MetricOnTimeShipmentCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iHome_MetricOnTimeShipmentCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iHome_MetricOnTimeShipmentCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iHome_MetricOnTimeShipmentCRUD.AltExtGen_Home_MetricOnTimeShipmentSp (ALTGEN_SpName,
						Count,
						MultipleSites,
						SiteGroup);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iHome_MetricOnTimeShipmentCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricOnTimeShipmentSp") != null)
			{
				var EXTGEN = this.iHome_MetricOnTimeShipmentCRUD.AltExtGen_Home_MetricOnTimeShipmentSp("dbo.EXTGEN_Home_MetricOnTimeShipmentSp",
					Count,
					MultipleSites,
					SiteGroup);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			if (Count== null)
			{
				Count = 4;
				
			}
			if (MultipleSites== null)
			{
				MultipleSites = 0;
				
			}
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @coitem TABLE (
				    due_date      DateType,
				    on_time_count INT     ,
				    line_count    INT     );
				SELECT * into #tv_coitem from @coitem");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @results TABLE (
				    on_time         DECIMAL (5, 2),
				    period_end      NVARCHAR (10) ,
				    period_end_date DateType      );
				SELECT * into #tv_results from @results");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @sites TABLE (
				    site SiteType PRIMARY KEY);
				SELECT * into #tv_sites from @sites
				ALTER TABLE #tv_sites ADD PRIMARY KEY (site)");
			Severity = 0;
			Today = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			(Site, rowCount) = this.iHome_MetricOnTimeShipmentCRUD.ParmsLoad(Site);
			
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
			i = Count;
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
					if (sQLUtil.SQLEqual(i, 10) == true)
					{
						PeriodStart10 = convertToUtil.ToDateTime(PerStart);
						PeriodEnd10 = convertToUtil.ToDateTime(PerEnd);
						
					}
					else
					{
						if (sQLUtil.SQLEqual(i, 9) == true)
						{
							PeriodStart9 = convertToUtil.ToDateTime(PerStart);
							PeriodEnd9 = convertToUtil.ToDateTime(PerEnd);
							
						}
						else
						{
							if (sQLUtil.SQLEqual(i, 8) == true)
							{
								PeriodStart8 = convertToUtil.ToDateTime(PerStart);
								PeriodEnd8 = convertToUtil.ToDateTime(PerEnd);
								
							}
							else
							{
								if (sQLUtil.SQLEqual(i, 7) == true)
								{
									PeriodStart7 = convertToUtil.ToDateTime(PerStart);
									PeriodEnd7 = convertToUtil.ToDateTime(PerEnd);
									
								}
								else
								{
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
									
								}
								
							}
							
						}
						
					}
					i = (int?)(i - 1);
					FirstFlag = 0;
					
				}
				CurrentPeriod = (int?)(CurrentPeriod - 1);
				
			}
			PerStart = convertToUtil.ToDateTime(stringUtil.Coalesce<DateTime?>(PeriodStart1,PeriodStart2,PeriodStart3,PeriodStart4,PeriodStart5,PeriodStart6,PeriodStart7,PeriodStart8,PeriodStart9,PeriodStart10));
			PerEnd = convertToUtil.ToDateTime(stringUtil.Coalesce<DateTime?>(PeriodEnd10,PeriodEnd9,PeriodEnd8,PeriodEnd7,PeriodEnd6,PeriodEnd5,PeriodEnd4,PeriodEnd3,PeriodEnd2,PeriodEnd1));
			if (PerStart== null)
			{
				goto EOF;
				
			}
			if (sQLUtil.SQLEqual(MultipleSites, 0) == true)
			{
				var nonTableLoadResponse = this.iHome_MetricOnTimeShipmentCRUD.NontableSelect(Site);
				Data = nonTableLoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.NontableInsert(nonTableLoadResponse);
				
			}
			else
			{
				var sitesLoadResponse = this.iHome_MetricOnTimeShipmentCRUD.SitesSelect(SiteGroup);
				this.iHome_MetricOnTimeShipmentCRUD.SitesInsert(sitesLoadResponse);
				
			}
			var tv_coitemLoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Tv_CoitemSelect(Today, PerStart, PerEnd);
			this.iHome_MetricOnTimeShipmentCRUD.Tv_CoitemInsert(tv_coitemLoadResponse);
			
			(PeriodTotal1,
				 PeriodOnTime1,
				 PeriodTotal2,
				 PeriodOnTime2,
				 PeriodTotal3,
				 PeriodOnTime3,
				 PeriodTotal4,
				 PeriodOnTime4,
				 PeriodTotal5,
				 PeriodOnTime5,
				 PeriodTotal6,
				 PeriodOnTime6,
				 PeriodTotal7,
				 PeriodOnTime7,
				 PeriodTotal8,
				 PeriodOnTime8,
				 PeriodTotal9,
				 PeriodOnTime9,
				 PeriodTotal10,
				 PeriodOnTime10, rowCount) = this.iHome_MetricOnTimeShipmentCRUD.Tv_Coitem1Load(PeriodStart1,
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
				 PeriodStart7,
				 PeriodEnd7,
				 PeriodStart8,
				 PeriodEnd8,
				 PeriodStart9,
				 PeriodEnd9,
				 PeriodStart10,
				 PeriodEnd10,
				 PeriodTotal1,
				 PeriodTotal2,
				 PeriodTotal3,
				 PeriodTotal4,
				 PeriodTotal5,
				 PeriodTotal6,
				 PeriodTotal7,
				 PeriodTotal8,
				 PeriodTotal9,
				 PeriodTotal10,
				 PeriodOnTime1,
				 PeriodOnTime2,
				 PeriodOnTime3,
				 PeriodOnTime4,
				 PeriodOnTime5,
				 PeriodOnTime6,
				 PeriodOnTime7,
				 PeriodOnTime8,
				 PeriodOnTime9,
				 PeriodOnTime10);
			EOF: ;
			var nonTable1LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable1Select(PeriodOnTime1, PeriodTotal1, PeriodEnd1);
			Data = nonTable1LoadResponse;
			this.iHome_MetricOnTimeShipmentCRUD.Nontable1Insert(nonTable1LoadResponse);
			var nonTable2LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable2Select(PeriodOnTime2, PeriodTotal2, PeriodEnd2);
			Data = nonTable2LoadResponse;
			this.iHome_MetricOnTimeShipmentCRUD.Nontable2Insert(nonTable2LoadResponse);
			var nonTable3LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable3Select(PeriodOnTime3, PeriodTotal3, PeriodEnd3);
			Data = nonTable3LoadResponse;
			this.iHome_MetricOnTimeShipmentCRUD.Nontable3Insert(nonTable3LoadResponse);
			var nonTable4LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable4Select(PeriodOnTime4, PeriodTotal4, PeriodEnd4);
			Data = nonTable4LoadResponse;
			this.iHome_MetricOnTimeShipmentCRUD.Nontable4Insert(nonTable4LoadResponse);
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 5) == true)
			{
				var nonTable5LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable5Select(PeriodOnTime5, PeriodTotal5, PeriodEnd5);
				Data = nonTable5LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable5Insert(nonTable5LoadResponse);
				
			}
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 6) == true)
			{
				var nonTable6LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable6Select(PeriodOnTime6, PeriodTotal6, PeriodEnd6);
				Data = nonTable6LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable6Insert(nonTable6LoadResponse);
				
			}
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 7) == true)
			{
				var nonTable7LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable7Select(PeriodOnTime7, PeriodTotal7, PeriodEnd7);
				Data = nonTable7LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable7Insert(nonTable7LoadResponse);
				
			}
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 8) == true)
			{
				var nonTable8LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable8Select(PeriodOnTime8, PeriodTotal8, PeriodEnd8);
				Data = nonTable8LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable8Insert(nonTable8LoadResponse);
				
			}
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 9) == true)
			{
				var nonTable9LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable9Select(PeriodOnTime9, PeriodTotal9, PeriodEnd9);
				Data = nonTable9LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable9Insert(nonTable9LoadResponse);
				
			}
			if (sQLUtil.SQLGreaterThanOrEqual(Count, 10) == true)
			{
				var nonTable10LoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Nontable10Select(PeriodOnTime10, PeriodTotal10, PeriodEnd10);
				Data = nonTable10LoadResponse;
				this.iHome_MetricOnTimeShipmentCRUD.Nontable10Insert(nonTable10LoadResponse);
				
			}
			var tv_resultsLoadResponse = this.iHome_MetricOnTimeShipmentCRUD.Tv_ResultsSelect();
			Data = tv_resultsLoadResponse;
			return (Data, Severity);
			
		}
		
	}
}
