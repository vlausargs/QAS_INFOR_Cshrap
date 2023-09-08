//PROJECT NAME: Employee
//CLASS NAME: CLM_PayCheckEarnings.cs

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

namespace CSI.Employee
{
	public class CLM_PayCheckEarnings : ICLM_PayCheckEarnings
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_PayCheckEarningsCRUD iCLM_PayCheckEarningsCRUD;
		readonly IBunchedLoadCollection bunchedLoadCollection;

		public CLM_PayCheckEarnings(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_PayCheckEarningsCRUD iCLM_PayCheckEarningsCRUD,
			IBunchedLoadCollection bunchedLoadCollection)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_PayCheckEarningsCRUD = iCLM_PayCheckEarningsCRUD;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_PayCheckEarningsSp(
			DateTime? CheckDate,
			Guid? CheckRowPointer,
			string EmpNum)
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			DateTime? YearStart = null;
			decimal? PrtrxpDeAmt__1 = null;
			decimal? PrtrxpDeAmt__2 = null;
			decimal? PrtrxpDeAmt__3 = null;
			decimal? PrtrxpDeAmt__4 = null;
			decimal? PrtrxpDeAmt__5 = null;
			decimal? PrtrxpDeAmt__6 = null;
			decimal? PrtrxpDeAmt__7 = null;
			decimal? PrtrxpDeAmt__8 = null;
			decimal? PrtrxpDeAmt__9 = null;
			decimal? PrtrxpDeAmt__10 = null;
			decimal? PrtrxpDeAmt__11 = null;
			decimal? PrtrxpDeAmt__12 = null;
			decimal? PrtrxpDeAmt__13 = null;
			decimal? PrtrxpDeAmt__14 = null;
			decimal? PrtrxpDeAmt__15 = null;
			decimal? PrtrxpDeAmt__16 = null;
			decimal? PrtrxpDeAmt__17 = null;
			decimal? PrtrxpDeAmt__18 = null;
			string PrtrxpDeCode__1 = null;
			string PrtrxpDeCode__2 = null;
			string PrtrxpDeCode__3 = null;
			string PrtrxpDeCode__4 = null;
			string PrtrxpDeCode__5 = null;
			string PrtrxpDeCode__6 = null;
			string PrtrxpDeCode__7 = null;
			string PrtrxpDeCode__8 = null;
			string PrtrxpDeCode__9 = null;
			string PrtrxpDeCode__10 = null;
			string PrtrxpDeCode__11 = null;
			string PrtrxpDeCode__12 = null;
			string PrtrxpDeCode__13 = null;
			string PrtrxpDeCode__14 = null;
			string PrtrxpDeCode__15 = null;
			string PrtrxpDeCode__16 = null;
			string PrtrxpDeCode__17 = null;
			string PrtrxpDeCode__18 = null;
			Guid? PrtrxpRowPointer = null;
			string TmpDescription = null;
			string TmpDeCode = null;
			decimal? TmpDeAmt = null;
			string TmpType = null;
			int? Cnt = null;
			int? CheckNum = null;
			if (this.iCLM_PayCheckEarningsCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_PayCheckEarningsCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_PayCheckEarningsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_PayCheckEarningsCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_PayCheckEarningsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_PayCheckEarningsCRUD.AltExtGen_CLM_PayCheckEarningsSp(ALTGEN_SpName,
						CheckDate,
						CheckRowPointer,
						EmpNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_PayCheckEarningsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_PayCheckEarningsSp") != null)
			{
				var EXTGEN = this.iCLM_PayCheckEarningsCRUD.AltExtGen_CLM_PayCheckEarningsSp("dbo.EXTGEN_CLM_PayCheckEarningsSp",
					CheckDate,
					CheckRowPointer,
					EmpNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @tmp_tbl TABLE (
				    description NVARCHAR (40)  ,
				    code        NVARCHAR (3)   ,
				    rate        DECIMAL (8, 3) ,
				    hrs         DECIMAL (19, 8),
				    pay         DECIMAL (8, 2) ,
				    ytd_pay     DECIMAL (14, 2),
				    sort        INT            );
				SELECT * into #tv_tmp_tbl from @tmp_tbl");
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tmp_tbl ADD tempTableId INT IDENTITY");
			/*Needs to load at least one column from the table: #tv_tmp_tbl for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var tv_tmp_tblLoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_TblSelect();
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_TblDelete(tv_tmp_tblLoadResponse);
			this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tmp_tbl DROP COLUMN tempTableId");
			if (sQLUtil.SQLEqual(stringUtil.IsNull(
					CheckDate,
					DateTime.Parse("1900-01-01 00:00:00.000")), "") == true || sQLUtil.SQLEqual(stringUtil.IsNull(
					EmpNum,
					""), "") == true)
			{
				return (Data, 0);

			}
			YearStart = convertToUtil.ToDateTime(stringUtil.Str(dateTimeUtil.Year<int?>(CheckDate)) + "-01-01");
			(CheckNum, rowCount) = this.iCLM_PayCheckEarningsCRUD.PrtrxpLoad(CheckRowPointer, CheckNum);
			var tv_tmp_tbl1LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl1Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl1Insert(tv_tmp_tbl1LoadResponse);
			var tv_tmp_tbl2LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl2Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl2Insert(tv_tmp_tbl2LoadResponse);
			var tv_tmp_tbl3LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl3Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl3Insert(tv_tmp_tbl3LoadResponse);
			var tv_tmp_tbl4LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl4Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl4Insert(tv_tmp_tbl4LoadResponse);
			var tv_tmp_tbl5LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl5Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl5Insert(tv_tmp_tbl5LoadResponse);
			var tv_tmp_tbl6LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl6Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl6Insert(tv_tmp_tbl6LoadResponse);
			var tv_tmp_tbl7LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl7Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl7Insert(tv_tmp_tbl7LoadResponse);
			var tv_tmp_tbl8LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl8Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl8Insert(tv_tmp_tbl8LoadResponse);
			var tv_tmp_tbl9LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl9Select(YearStart, CheckDate, CheckNum, EmpNum, CheckRowPointer);
			this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl9Insert(tv_tmp_tbl9LoadResponse);

			using (IRecordStream prtrxpRecordStream = this.iCLM_PayCheckEarningsCRUD.Prtrxp1Select(CheckDate, EmpNum, YearStart, CheckNum, CheckRowPointer, bunchedLoadCollection.LoadType))
			{
				while (prtrxpRecordStream.Read())
				{
					// Get the current row from Current property.
					IRecordReadOnly prtrxpRow = prtrxpRecordStream.Current;
					// This is just like fetch cursor into variable.
					PrtrxpDeCode__1 = prtrxpRow.GetValue<string>(0);
					PrtrxpDeCode__2 = prtrxpRow.GetValue<string>(1);
					PrtrxpDeCode__3 = prtrxpRow.GetValue<string>(2);
					PrtrxpDeCode__4 = prtrxpRow.GetValue<string>(3);
					PrtrxpDeCode__5 = prtrxpRow.GetValue<string>(4);
					PrtrxpDeCode__6 = prtrxpRow.GetValue<string>(5);
					PrtrxpDeCode__7 = prtrxpRow.GetValue<string>(6);
					PrtrxpDeCode__8 = prtrxpRow.GetValue<string>(7);
					PrtrxpDeCode__9 = prtrxpRow.GetValue<string>(8);
					PrtrxpDeCode__10 = prtrxpRow.GetValue<string>(9);
					PrtrxpDeCode__11 = prtrxpRow.GetValue<string>(10);
					PrtrxpDeCode__12 = prtrxpRow.GetValue<string>(11);
					PrtrxpDeCode__13 = prtrxpRow.GetValue<string>(12);
					PrtrxpDeCode__14 = prtrxpRow.GetValue<string>(13);
					PrtrxpDeCode__15 = prtrxpRow.GetValue<string>(14);
					PrtrxpDeCode__16 = prtrxpRow.GetValue<string>(15);
					PrtrxpDeCode__17 = prtrxpRow.GetValue<string>(16);
					PrtrxpDeCode__18 = prtrxpRow.GetValue<string>(17);
					PrtrxpDeAmt__1 = prtrxpRow.GetValue<decimal?>(18);
					PrtrxpDeAmt__2 = prtrxpRow.GetValue<decimal?>(19);
					PrtrxpDeAmt__3 = prtrxpRow.GetValue<decimal?>(20);
					PrtrxpDeAmt__4 = prtrxpRow.GetValue<decimal?>(21);
					PrtrxpDeAmt__5 = prtrxpRow.GetValue<decimal?>(22);
					PrtrxpDeAmt__6 = prtrxpRow.GetValue<decimal?>(23);
					PrtrxpDeAmt__7 = prtrxpRow.GetValue<decimal?>(24);
					PrtrxpDeAmt__8 = prtrxpRow.GetValue<decimal?>(25);
					PrtrxpDeAmt__9 = prtrxpRow.GetValue<decimal?>(26);
					PrtrxpDeAmt__10 = prtrxpRow.GetValue<decimal?>(27);
					PrtrxpDeAmt__11 = prtrxpRow.GetValue<decimal?>(28);
					PrtrxpDeAmt__12 = prtrxpRow.GetValue<decimal?>(29);
					PrtrxpDeAmt__13 = prtrxpRow.GetValue<decimal?>(30);
					PrtrxpDeAmt__14 = prtrxpRow.GetValue<decimal?>(31);
					PrtrxpDeAmt__15 = prtrxpRow.GetValue<decimal?>(32);
					PrtrxpDeAmt__16 = prtrxpRow.GetValue<decimal?>(33);
					PrtrxpDeAmt__17 = prtrxpRow.GetValue<decimal?>(34);
					PrtrxpDeAmt__18 = prtrxpRow.GetValue<decimal?>(35);
					PrtrxpRowPointer = prtrxpRow.GetValue<Guid?>(36);


					Cnt = 1;
					while (sQLUtil.SQLBool(sQLUtil.SQLLessThan(Cnt, 19)))
					{
						TmpDeCode = null;
						TmpDescription = null;
						TmpType = null;
						TmpDeAmt = null;
						if (sQLUtil.SQLEqual(Cnt, 1) == true)
						{
							(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.PrdecdLoad(PrtrxpDeCode__1, PrtrxpDeAmt__1, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

						}
						else
						{
							if (sQLUtil.SQLEqual(Cnt, 2) == true)
							{
								(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd1Load(PrtrxpDeCode__2, PrtrxpDeAmt__2, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

							}
							else
							{
								if (sQLUtil.SQLEqual(Cnt, 3) == true)
								{
									(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd2Load(PrtrxpDeCode__3, PrtrxpDeAmt__3, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

								}
								else
								{
									if (sQLUtil.SQLEqual(Cnt, 4) == true)
									{
										(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd3Load(PrtrxpDeCode__4, PrtrxpDeAmt__4, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

									}
									else
									{
										if (sQLUtil.SQLEqual(Cnt, 5) == true)
										{
											(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd4Load(PrtrxpDeCode__5, PrtrxpDeAmt__5, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

										}
										else
										{
											if (sQLUtil.SQLEqual(Cnt, 6) == true)
											{
												(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd5Load(PrtrxpDeCode__6, PrtrxpDeAmt__6, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

											}
											else
											{
												if (sQLUtil.SQLEqual(Cnt, 7) == true)
												{
													(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd6Load(PrtrxpDeCode__7, PrtrxpDeAmt__7, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

												}
												else
												{
													if (sQLUtil.SQLEqual(Cnt, 8) == true)
													{
														(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd7Load(PrtrxpDeCode__8, PrtrxpDeAmt__8, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

													}
													else
													{
														if (sQLUtil.SQLEqual(Cnt, 9) == true)
														{
															(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd8Load(PrtrxpDeCode__9, PrtrxpDeAmt__9, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

														}
														else
														{
															if (sQLUtil.SQLEqual(Cnt, 10) == true)
															{
																(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd9Load(PrtrxpDeCode__10, PrtrxpDeAmt__10, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

															}
															else
															{
																if (sQLUtil.SQLEqual(Cnt, 11) == true)
																{
																	(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd10Load(PrtrxpDeCode__11, PrtrxpDeAmt__11, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																}
																else
																{
																	if (sQLUtil.SQLEqual(Cnt, 12) == true)
																	{
																		(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd11Load(PrtrxpDeCode__12, PrtrxpDeAmt__12, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																	}
																	else
																	{
																		if (sQLUtil.SQLEqual(Cnt, 13) == true)
																		{
																			(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd12Load(PrtrxpDeCode__13, PrtrxpDeAmt__13, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																		}
																		else
																		{
																			if (sQLUtil.SQLEqual(Cnt, 14) == true)
																			{
																				(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd13Load(PrtrxpDeCode__14, PrtrxpDeAmt__14, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																			}
																			else
																			{
																				if (sQLUtil.SQLEqual(Cnt, 15) == true)
																				{
																					(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd14Load(PrtrxpDeCode__15, PrtrxpDeAmt__15, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																				}
																				else
																				{
																					if (sQLUtil.SQLEqual(Cnt, 16) == true)
																					{
																						(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd15Load(PrtrxpDeCode__16, PrtrxpDeAmt__16, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																					}
																					else
																					{
																						if (sQLUtil.SQLEqual(Cnt, 17) == true)
																						{
																							(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd16Load(PrtrxpDeCode__17, PrtrxpDeAmt__17, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

																						}
																						else
																						{
																							if (sQLUtil.SQLEqual(Cnt, 18) == true)
																							{
																								(TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount) = this.iCLM_PayCheckEarningsCRUD.Prdecd17Load(PrtrxpDeCode__18, PrtrxpDeAmt__18, TmpDescription, TmpDeCode, TmpDeAmt, TmpType);

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

													}

												}

											}

										}

									}

								}

							}

						}
						if (sQLUtil.SQLBool(TmpDeCode != null))
						{
							if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl10ForExists(TmpDeCode))))
							{
								var nonTable1LoadResponse = this.iCLM_PayCheckEarningsCRUD.Nontable1Select(TmpDescription, TmpDeCode, CheckRowPointer, PrtrxpRowPointer, TmpDeAmt);
								Data = nonTable1LoadResponse;
								this.iCLM_PayCheckEarningsCRUD.Nontable1Insert(nonTable1LoadResponse);

							}
							else
							{
								this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tmp_tbl ADD tempTableId INT IDENTITY");
								var tv_tmp_tbl11LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl11Select(TmpDeCode);
								this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl11Update(CheckRowPointer, PrtrxpRowPointer, TmpDeAmt, tv_tmp_tbl11LoadResponse);
								this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_tmp_tbl DROP COLUMN tempTableId");

							}

						}
						Cnt = (int?)(Cnt + 1);

					}
				}
			}
			//Deallocate Cursor Curprtrxp
			var tv_tmp_tbl12LoadResponse = this.iCLM_PayCheckEarningsCRUD.Tv_Tmp_Tbl12Select();
			Data = tv_tmp_tbl12LoadResponse;

			return (Data, 0);

		}

	}
}
