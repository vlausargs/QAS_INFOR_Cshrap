//PROJECT NAME: Logistics
//CLASS NAME: COReturnQtyValidate.cs

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
using CSI.Admin;

namespace CSI.Logistics.Customer
{
	public class COReturnQtyValidate : ICOReturnQtyValidate
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IIsFeatureActive iIsFeatureActive;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly IMathUtil mathUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public COReturnQtyValidate(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IIsFeatureActive iIsFeatureActive,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			IMathUtil mathUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.iIsFeatureActive = iIsFeatureActive;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.mathUtil = mathUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (
			int? ReturnCode,
			string Infobar)
		COReturnQtyValidateSp(
			string CoitemCoNum,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string SDoNum,
			int? SDoLine,
			decimal? SQty,
			int? SReturn,
			string SLoc,
			string SLot,
			int? PackNum = null,
			int? LotTrack = null,
			string Infobar = null)
		{

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			QtyUnitType _TAdjQty = DBNull.Value;
			decimal? TAdjQty = null;
			ListYesNoType _CustomerPrintPackInv = DBNull.Value;
			int? CustomerPrintPackInv = null;
			int? Severity = null;
			CustNumType _CoCustNum = DBNull.Value;
			string CoCustNum = null;
			string ProductNameRS8297 = null;
			string FeatureIDRS8297 = null;
			int? FeatureRS8297Active = null;
			int? MexicanCountryPackOn = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('COReturnQtyValidateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('COReturnQtyValidateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("COReturnQtyValidateSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_COReturnQtyValidateSp(ALTGEN_SpName,
						CoitemCoNum,
						CoitemCoLine,
						CoitemCoRelease,
						SDoNum,
						SDoLine,
						SQty,
						SReturn,
						SLoc,
						SLot,
						PackNum,
						LotTrack,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);

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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_COReturnQtyValidateSp") != null)
			{
				var EXTGEN = AltExtGen_COReturnQtyValidateSp("dbo.EXTGEN_COReturnQtyValidateSp",
					CoitemCoNum,
					CoitemCoLine,
					CoitemCoRelease,
					SDoNum,
					SDoLine,
					SQty,
					SReturn,
					SLoc,
					SLot,
					PackNum,
					LotTrack,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}

			ProductNameRS8297 = "CSI";
			FeatureIDRS8297 = "RS8297";

			#region CRUD ExecuteMethodCall

			//Please Generate the bounce for this stored procedure: IsFeatureActiveSp
			var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
				ProductName: ProductNameRS8297,
				FeatureID: FeatureIDRS8297,
				FeatureActive: FeatureRS8297Active,
				InfoBar: Infobar);
			Severity = IsFeatureActive.ReturnCode;
			FeatureRS8297Active = IsFeatureActive.FeatureActive;
			Infobar = IsFeatureActive.InfoBar;

			#endregion ExecuteMethodCall

			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, Infobar);
			}
			MexicanCountryPackOn = convertToUtil.ToInt32((sQLUtil.SQLEqual(FeatureRS8297Active, 1) == true && sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("MexicanCountryPack"), 1) == true ? 1 : 0));

			#region CRUD LoadToVariable
			var coLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CoCustNum,"co.cust_num"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "co",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (UPDLOCK)"),
				whereClause: collectionLoadRequestFactory.Clause("co.co_num = {0} AND (CHARINDEX(co.stat, 'OP') <> 0)", CoitemCoNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var coLoadResponse = this.appDB.Load(coLoadRequest);
			if (coLoadResponse.Items.Count > 0)
			{
				CoCustNum = _CoCustNum;
			}
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
			var customerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CustomerPrintPackInv,"print_pack_inv"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "customer",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("customer.cust_num = {0} AND customer.cust_seq = 0", CoCustNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var customerLoadResponse = this.appDB.Load(customerLoadRequest);
			if (customerLoadResponse.Items.Count > 0)
			{
				CustomerPrintPackInv = _CustomerPrintPackInv;
			}
			#endregion  LoadToVariable

			TAdjQty = 0;
			if (sQLUtil.SQLEqual(MexicanCountryPackOn, 1) == true)
			{
				//BEGIN
				if (((sQLUtil.SQLNotEqual(SReturn, 0) == true && sQLUtil.SQLGreaterThan(SQty, 0) == true) || (sQLUtil.SQLEqual(SReturn, 0) == true && sQLUtil.SQLLessThan(SQty, 0) == true)))
				{
					//BEGIN
					if (sQLUtil.SQLNotEqual(SReturn, 0) == true)
					{
						//BEGIN

						#region CRUD LoadToVariable
						var co_shipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TAdjQty,"SUM(IsNull(co_ship.qty_shipped, 0) - isnull(co_ship.qty_returned, 0))"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "co_ship",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("co_ship.co_num = {2} AND co_ship.co_line = {1} AND co_ship.co_release = {0} AND isnull(co_ship.do_num, '') = isnull({4}, '') AND ISNULL(co_ship.do_line, '') = ISNULL({3}, '')", CoitemCoRelease, CoitemCoLine, CoitemCoNum, SDoLine, SDoNum),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var co_shipLoadResponse = this.appDB.Load(co_shipLoadRequest);
						if (co_shipLoadResponse.Items.Count > 0)
						{
							TAdjQty = _TAdjQty;
						}
						#endregion  LoadToVariable

						//END

					}
					else
					{
						//BEGIN

						#region CRUD LoadToVariable
						var co_ship1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
							{
								{_TAdjQty,"SUM(isnull(co_ship.qty_shipped, 0))"},
							},
							loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "co_ship",
							fromClause: collectionLoadRequestFactory.Clause(""),
							whereClause: collectionLoadRequestFactory.Clause("co_ship.co_num = {3} AND co_ship.co_line = {2} AND co_ship.co_release = {1} AND isnull(co_ship.do_num, '') = isnull({6}, '') AND ISNULL(co_ship.do_line, '') = ISNULL({4}, '') AND isnull(co_ship.pack_num, 0) = isnull(CASE WHEN {0} = 1 THEN {5} ELSE co_ship.pack_num END, 0) AND co_ship.qty_shipped > 0", CustomerPrintPackInv, CoitemCoRelease, CoitemCoLine, CoitemCoNum, SDoLine, PackNum, SDoNum),
							orderByClause: collectionLoadRequestFactory.Clause(""));
						var co_ship1LoadResponse = this.appDB.Load(co_ship1LoadRequest);
						if (co_ship1LoadResponse.Items.Count > 0)
						{
							TAdjQty = _TAdjQty;
						}
						#endregion  LoadToVariable

						//END

					}
					if (sQLUtil.SQLGreaterThan(mathUtil.Abs<decimal?>(SQty), stringUtil.IsNull<decimal?>(
							TAdjQty,
							0)) == true)
					{
						//BEGIN
						TAdjQty = (decimal?)(stringUtil.IsNull<decimal?>(
							TAdjQty,
							0));
						SDoLine = (int?)(stringUtil.IsNull(
							SDoLine,
							0));

						#region CRUD ExecuteMethodCall

						var MsgApp = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=IsCompare>3",
							Parm1: "@co_ship.qty_returned",
							Parm2: convertToUtil.ToString(TAdjQty),
							Parm3: "@co_ship",
							Parm4: "@co_ship.do_num",
							Parm5: SDoNum,
							Parm6: "@co_ship.do_line",
							Parm7: convertToUtil.ToString(SDoLine),
							Parm8: "@pck_hdr.pack_num",
							Parm9: convertToUtil.ToString(PackNum));
						Severity = MsgApp.ReturnCode;
						Infobar = MsgApp.Infobar;

						#endregion ExecuteMethodCall

						//END

					}
					//END

				}
				//END

			}
			else
			{
				//BEGIN
				if (((sQLUtil.SQLNotEqual(SReturn, 0) == true && sQLUtil.SQLGreaterThan(SQty, 0) == true) || (sQLUtil.SQLEqual(SReturn, 0) == true && sQLUtil.SQLLessThan(SQty, 0) == true)))
				{
					//BEGIN
					if ((sQLUtil.SQLEqual(LotTrack, 1) == true && SDoNum != null))
					{
						//BEGIN
						if (sQLUtil.SQLNotEqual(SReturn, 0) == true)
						{

							#region CRUD LoadToVariable
							var do_seqLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
								{
									{_TAdjQty,"SUM(IsNull(co_ship.qty_invoiced, 0) - isnull(co_ship.qty_returned, 0))"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "do_seq",
								fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN matltrack WITH (READUNCOMMITTED) ON matltrack.ref_type = do_seq.ref_type
									AND matltrack.ref_num = do_seq.ref_num
									AND matltrack.ref_line_suf = do_seq.ref_line
									AND matltrack.ref_release = do_seq.ref_release
									AND matltrack.trans_date = do_seq.ship_date
									AND matltrack.date_seq = do_seq.date_seq
									AND matltrack.lot = ISNULL({0}, matltrack.lot) INNER JOIN co_ship ON co_ship.do_num = do_seq.do_num
									AND co_ship.do_line = do_seq.do_line
									AND co_ship.do_seq = do_seq.do_seq", SLot),
								whereClause: collectionLoadRequestFactory.Clause("do_seq.do_num = {1} AND do_seq.do_line = {0}", SDoLine, SDoNum),
								orderByClause: collectionLoadRequestFactory.Clause(""));
							var do_seqLoadResponse = this.appDB.Load(do_seqLoadRequest);
							if (do_seqLoadResponse.Items.Count > 0)
							{
								TAdjQty = _TAdjQty;
							}
							#endregion  LoadToVariable

						}
						else
						{

							#region CRUD LoadToVariable
							var do_seq1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
								{
									{_TAdjQty,"SUM(isnull(co_ship.qty_shipped, 0) - isnull(co_ship.qty_invoiced, 0))"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "do_seq",
								fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN matltrack WITH (READUNCOMMITTED) ON matltrack.ref_type = do_seq.ref_type
									AND matltrack.ref_num = do_seq.ref_num
									AND matltrack.ref_line_suf = do_seq.ref_line
									AND matltrack.ref_release = do_seq.ref_release
									AND matltrack.trans_date = do_seq.ship_date
									AND matltrack.date_seq = do_seq.date_seq
									AND matltrack.lot = ISNULL({0}, matltrack.lot) INNER JOIN co_ship ON co_ship.do_num = do_seq.do_num
									AND co_ship.do_line = do_seq.do_line
									AND co_ship.do_seq = do_seq.do_seq", SLot),
								whereClause: collectionLoadRequestFactory.Clause("do_seq.do_num = {1} AND do_seq.do_line = {0}", SDoLine, SDoNum),
								orderByClause: collectionLoadRequestFactory.Clause(""));
							var do_seq1LoadResponse = this.appDB.Load(do_seq1LoadRequest);
							if (do_seq1LoadResponse.Items.Count > 0)
							{
								TAdjQty = _TAdjQty;
							}
							#endregion  LoadToVariable

						}
						//END

					}
					else
					{
						//BEGIN
						if (sQLUtil.SQLNotEqual(SReturn, 0) == true)
						{

							#region CRUD LoadToVariable
							var co_ship2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
								{
									{_TAdjQty,"SUM(IsNull(co_ship.qty_invoiced, 0) - isnull(co_ship.qty_returned, 0))"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "co_ship",
								fromClause: collectionLoadRequestFactory.Clause(""),
								whereClause: collectionLoadRequestFactory.Clause("co_ship.co_num = {2} AND co_ship.co_line = {1} AND co_ship.co_release = {0} AND isnull(co_ship.do_num, '') = isnull({4}, '') AND ISNULL(co_ship.do_line, '') = ISNULL({3}, '')", CoitemCoRelease, CoitemCoLine, CoitemCoNum, SDoLine, SDoNum),
								orderByClause: collectionLoadRequestFactory.Clause(""));
							var co_ship2LoadResponse = this.appDB.Load(co_ship2LoadRequest);
							if (co_ship2LoadResponse.Items.Count > 0)
							{
								TAdjQty = _TAdjQty;
							}
							#endregion  LoadToVariable

						}
						else
						{

							#region CRUD LoadToVariable
							var co_ship3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
								{
									{_TAdjQty,"SUM(isnull(co_ship.qty_shipped, 0) - isnull(co_ship.qty_invoiced, 0))"},
								},
								loadForChange: false, 
                                lockingType: LockingType.None,
                                tableName: "co_ship",
								fromClause: collectionLoadRequestFactory.Clause(""),
								whereClause: collectionLoadRequestFactory.Clause("co_ship.co_num = {3} AND co_ship.co_line = {2} AND co_ship.co_release = {1} AND isnull(co_ship.do_num, '') = isnull({6}, '') AND ISNULL(co_ship.do_line, '') = ISNULL({4}, '') AND isnull(co_ship.pack_num, 0) = isnull(CASE WHEN {0} = 1 THEN {5} ELSE co_ship.pack_num END, 0) AND co_ship.qty_shipped > 0", CustomerPrintPackInv, CoitemCoRelease, CoitemCoLine, CoitemCoNum, SDoLine, PackNum, SDoNum),
								orderByClause: collectionLoadRequestFactory.Clause(""));
							var co_ship3LoadResponse = this.appDB.Load(co_ship3LoadRequest);
							if (co_ship3LoadResponse.Items.Count > 0)
							{
								TAdjQty = _TAdjQty;
							}
							#endregion  LoadToVariable

						}
						//END

					}
					if (sQLUtil.SQLGreaterThan(mathUtil.Abs<decimal?>(SQty), stringUtil.IsNull<decimal?>(
							TAdjQty,
							0)) == true)
					{
						//BEGIN
						TAdjQty = (decimal?)(stringUtil.IsNull<decimal?>(
							TAdjQty,
							0));
						SDoLine = (int?)(stringUtil.IsNull(
							SDoLine,
							0));

						#region CRUD ExecuteMethodCall

						var MsgApp1 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=IsCompare>3",
							Parm1: "@co_ship.qty_returned",
							Parm2: convertToUtil.ToString(TAdjQty),
							Parm3: "@co_ship",
							Parm4: "@co_ship.do_num",
							Parm5: SDoNum,
							Parm6: "@co_ship.do_line",
							Parm7: convertToUtil.ToString(SDoLine),
							Parm8: "@pck_hdr.pack_num",
							Parm9: convertToUtil.ToString(PackNum));
						Severity = MsgApp1.ReturnCode;
						Infobar = MsgApp1.Infobar;

						#endregion ExecuteMethodCall

						//END

					}
					//END

				}
				//END

			}
			return (Severity, Infobar);

		}
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_COReturnQtyValidateSp(
			string AltExtGenSp,
			string CoitemCoNum,
			int? CoitemCoLine,
			int? CoitemCoRelease,
			string SDoNum,
			int? SDoLine,
			decimal? SQty,
			int? SReturn,
			string SLoc,
			string SLot,
			int? PackNum = null,
			int? LotTrack = null,
			string Infobar = null)
		{
			CoNumType _CoitemCoNum = CoitemCoNum;
			CoLineType _CoitemCoLine = CoitemCoLine;
			CoReleaseType _CoitemCoRelease = CoitemCoRelease;
			DoNumType _SDoNum = SDoNum;
			DoLineType _SDoLine = SDoLine;
			QtyUnitNoNegType _SQty = SQty;
			ListYesNoType _SReturn = SReturn;
			LocType _SLoc = SLoc;
			LotType _SLot = SLot;
			PackNumType _PackNum = PackNum;
			ListYesNoType _LotTrack = LotTrack;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "CoitemCoNum", _CoitemCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoLine", _CoitemCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemCoRelease", _CoitemCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDoNum", _SDoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDoLine", _SDoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SQty", _SQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SReturn", _SReturn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLoc", _SLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLot", _SLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PackNum", _PackNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTrack", _LotTrack, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				Infobar = _Infobar;

				return (Severity, Infobar);
			}
		}

	}
}
