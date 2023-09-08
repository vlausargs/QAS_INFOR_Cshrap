//PROJECT NAME: Material
//CLASS NAME: CoResValidateQty.cs

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
using CSI.Logistics.Customer;
using CSI.DataCollection;

namespace CSI.Material
{
	public class CoResValidateQty : ICoResValidateQty
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IUomConvQty iUomConvQty;
		readonly IStringUtil stringUtil;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;

		public CoResValidateQty(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IUomConvQty iUomConvQty,
			IStringUtil stringUtil,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.iUomConvQty = iUomConvQty;
			this.stringUtil = stringUtil;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}

		public (
			int? ReturnCode,
			string PUM,
			string Infobar)
		CoResValidateQtySp(
			string PItem,
			decimal? PQtyRsvd,
			decimal? PQtyRsvdOld = 0,
			string PUM = null,
			string PCoNum = null,
			int? PLotTracked = null,
			string PCurWhse = null,
			string PLot = null,
			string PLoc = null,
			string Infobar = null,
			string PImportDocId = null,
			int? PTaxFreeMatl = null)
		{

			UMType _PUM = PUM;

			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			decimal? TBaseQtyTorsv = null;
			decimal? UomConvFactor = null;
			RowPointerType _LotLocRowPointer = DBNull.Value;
			Guid? LotLocRowPointer = null;
			QtyUnitType _LotLocQtyOnHand = DBNull.Value;
			decimal? LotLocQtyOnHand = null;
			QtyUnitType _LotLocQtyRsvd = DBNull.Value;
			decimal? LotLocQtyRsvd = null;
			QtyUnitNoNegType _LotLocQtyContained = DBNull.Value;
			decimal? LotLocQtyContained = null;
			RowPointerType _ItemlocRowPointer = DBNull.Value;
			Guid? ItemlocRowPointer = null;
			QtyUnitType _ItemlocQtyOnHand = DBNull.Value;
			decimal? ItemlocQtyOnHand = null;
			QtyUnitType _ItemlocQtyRsvd = DBNull.Value;
			decimal? ItemlocQtyRsvd = null;
			QtyUnitType _ItemlocQtyContained = DBNull.Value;
			decimal? ItemlocQtyContained = null;
			UMType _ItemUM = DBNull.Value;
			string ItemUM = null;
			RowPointerType _TFIQRowPointer = DBNull.Value;
			Guid? TFIQRowPointer = null;
			QtyUnitType _TFIQQtyOnHand = DBNull.Value;
			decimal? TFIQQtyOnHand = null;
			QtyUnitNoNegType _TFIQQtyRsvd = DBNull.Value;
			decimal? TFIQQtyRsvd = null;
			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CoResValidateQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CoResValidateQtySp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CoResValidateQtySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

					var ALTGEN = AltExtGen_CoResValidateQtySp(ALTGEN_SpName,
						PItem,
						PQtyRsvd,
						PQtyRsvdOld,
						PUM,
						PCoNum,
						PLotTracked,
						PCurWhse,
						PLot,
						PLoc,
						Infobar,
						PImportDocId,
						PTaxFreeMatl);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						PUM = _PUM;
						return (ALTGEN_Severity, PUM, Infobar);

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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CoResValidateQtySp") != null)
			{
				var EXTGEN = AltExtGen_CoResValidateQtySp("dbo.EXTGEN_CoResValidateQtySp",
					PItem,
					PQtyRsvd,
					PQtyRsvdOld,
					PUM,
					PCoNum,
					PLotTracked,
					PCurWhse,
					PLot,
					PLoc,
					Infobar,
					PImportDocId,
					PTaxFreeMatl);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.PUM, EXTGEN.Infobar);
				}
			}

			Severity = 0;

			#region CRUD LoadToVariable
			var itemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ItemUM,"item.u_m"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "item",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("item.item = {0}", PItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var itemLoadResponse = this.appDB.Load(itemLoadRequest);
			if (itemLoadResponse.Items.Count > 0)
			{
				ItemUM = _ItemUM;
			}
			#endregion  LoadToVariable

			#region CRUD LoadToVariable
			var u_mLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_PUM,"u_m.u_m"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "u_m",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("u_m.u_m = {0}", PUM),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var u_mLoadResponse = this.appDB.Load(u_mLoadRequest);
			if (u_mLoadResponse.Items.Count > 0)
			{
				PUM = _PUM;
			}
			#endregion  LoadToVariable

			TBaseQtyTorsv = (decimal?)(PQtyRsvd - PQtyRsvdOld);
			if (sQLUtil.SQLNotEqual(PUM, ItemUM) == true)
			{
				//BEGIN

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: GetumcfSp
				var Getumcf = this.iGetumcf.GetumcfSp(
					OtherUM: PUM,
					Item: PItem,
					VendNum: PCoNum,
					Area: "C",
					ConvFactor: UomConvFactor,
					Infobar: Infobar);
				Severity = Getumcf.ReturnCode;
				UomConvFactor = Getumcf.ConvFactor;
				Infobar = Getumcf.Infobar;

				#endregion ExecuteMethodCall

				if (sQLUtil.SQLNotEqual(Severity, 0) == true)
				{
					return (Severity, PUM, Infobar);
				}

				#region CRUD ExecuteMethodCall

				//Please Generate the bounce for this stored procedure: UomConvQtySp
				var UomConvQty = this.iUomConvQty.UomConvQtySp(
					QtyToBeConverted: TBaseQtyTorsv,
					UomConvFactor: UomConvFactor,
					FROMBase: "To Base",
					ConvertedQty: TBaseQtyTorsv,
					Infobar: Infobar);
				TBaseQtyTorsv = UomConvQty.ConvertedQty;
				Infobar = UomConvQty.Infobar;

				#endregion ExecuteMethodCall

				//END

			}
			else
			{
				UomConvFactor = 1M;

			}
			if (sQLUtil.SQLEqual(PLotTracked, 1) == true)
			{
				//BEGIN
				LotLocRowPointer = null;
				LotLocQtyOnHand = 0;
				LotLocQtyRsvd = 0;
				LotLocQtyContained = 0;

				#region CRUD LoadToVariable
				var lot_locLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_LotLocRowPointer,"lot_loc.RowPointer"},
						{_LotLocQtyOnHand,"lot_loc.qty_on_hand"},
						{_LotLocQtyRsvd,"lot_loc.qty_rsvd"},
						{_LotLocQtyContained,"lot_loc.qty_contained"},
					},
					loadForChange: false,
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName: "lot_loc",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("lot_loc.whse = {0} AND lot_loc.item = {1} AND lot_loc.lot = {2} AND lot_loc.loc = {3}", PCurWhse, PItem, PLot, PLoc),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var lot_locLoadResponse = this.appDB.Load(lot_locLoadRequest);
				if (lot_locLoadResponse.Items.Count > 0)
				{
					LotLocRowPointer = _LotLocRowPointer;
					LotLocQtyOnHand = _LotLocQtyOnHand;
					LotLocQtyRsvd = _LotLocQtyRsvd;
					LotLocQtyContained = _LotLocQtyContained;
				}
				#endregion  LoadToVariable

				if (LotLocRowPointer != null)
				{
					if (sQLUtil.SQLLessThan(LotLocQtyOnHand - LotLocQtyRsvd - LotLocQtyContained, TBaseQtyTorsv) == true)
					{
						//BEGIN
						Infobar = null;

						#region CRUD ExecuteMethodCall

						var MsgApp = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=CmdInvalid",
							Parm1: "@%add");
						Severity = MsgApp.ReturnCode;
						Infobar = MsgApp.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp1 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "I=IsCompare>",
							Parm1: "@rsvd_inv.qty_rsvd",
							Parm2: "@lot_loc.qty_on_hand");
						Infobar = MsgApp1.Infobar;

						#endregion ExecuteMethodCall

						//END

					}

				}
				//END

			}
			else
			{
				//BEGIN
				ItemlocRowPointer = null;
				ItemlocQtyOnHand = 0;
				ItemlocQtyRsvd = 0;

				#region CRUD LoadToVariable
				var itemlocLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_ItemlocRowPointer,"itemloc.RowPointer"},
						{_ItemlocQtyOnHand,"itemloc.qty_on_hand"},
						{_ItemlocQtyRsvd,"itemloc.qty_rsvd"},
						{_ItemlocQtyContained,"itemloc.qty_contained"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName: "itemloc",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("itemloc.whse = {0} AND itemloc.item = {1} AND itemloc.loc = {2}", PCurWhse, PItem, PLoc),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var itemlocLoadResponse = this.appDB.Load(itemlocLoadRequest);
				if (itemlocLoadResponse.Items.Count > 0)
				{
					ItemlocRowPointer = _ItemlocRowPointer;
					ItemlocQtyOnHand = _ItemlocQtyOnHand;
					ItemlocQtyRsvd = _ItemlocQtyRsvd;
					ItemlocQtyContained = _ItemlocQtyContained;
				}
				#endregion  LoadToVariable

				if (ItemlocRowPointer != null)
				{
					if (sQLUtil.SQLLessThan(ItemlocQtyOnHand - ItemlocQtyRsvd - ItemlocQtyContained, TBaseQtyTorsv) == true)
					{
						//BEGIN
						Infobar = null;

						#region CRUD ExecuteMethodCall

						var MsgApp2 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=CmdInvalid",
							Parm1: "@%add");
						Severity = MsgApp2.ReturnCode;
						Infobar = MsgApp2.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp3 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "I=IsCompare>",
							Parm1: "@rsvd_inv.qty_rsvd",
							Parm2: "@itemloc.qty_on_hand");
						Infobar = MsgApp3.Infobar;

						#endregion ExecuteMethodCall

						//END

					}

				}
				//END

			}
			if (sQLUtil.SQLEqual(PTaxFreeMatl, 1) == true)
			{
				//BEGIN
				TFIQRowPointer = null;
				TFIQQtyOnHand = 0;
				TFIQQtyRsvd = 0;

				#region CRUD LoadToVariable
				var tax_free_import_qtyAStfiqLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_TFIQRowPointer,"tfiq.RowPointer"},
						{_TFIQQtyOnHand,"tfiq.qty_on_hand"},
						{_TFIQQtyRsvd,"tfiq.qty_rsvd"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName: "tax_free_import_qty AS tfiq",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("tfiq.whse = {2} AND tfiq.item = {3} AND ISNULL(tfiq.lot, '') = CASE WHEN {1} = 1 THEN {4} ELSE '' END AND tfiq.loc = {5} AND tfiq.import_doc_id = {0}", PImportDocId, PLotTracked, PCurWhse, PItem, PLot, PLoc),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var tax_free_import_qtyAStfiqLoadResponse = this.appDB.Load(tax_free_import_qtyAStfiqLoadRequest);
				if (tax_free_import_qtyAStfiqLoadResponse.Items.Count > 0)
				{
					TFIQRowPointer = _TFIQRowPointer;
					TFIQQtyOnHand = _TFIQQtyOnHand;
					TFIQQtyRsvd = _TFIQQtyRsvd;
				}
				#endregion  LoadToVariable

				if (TFIQRowPointer != null)
				{
					if (sQLUtil.SQLLessThan(TFIQQtyOnHand - TFIQQtyRsvd, TBaseQtyTorsv) == true)
					{
						//BEGIN
						Infobar = null;

						#region CRUD ExecuteMethodCall

						var MsgApp4 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "E=CmdInvalid",
							Parm1: "@%add");
						Severity = MsgApp4.ReturnCode;
						Infobar = MsgApp4.Infobar;

						#endregion ExecuteMethodCall

						#region CRUD ExecuteMethodCall

						var MsgApp5 = this.iMsgApp.MsgAppSp(
							Infobar: Infobar,
							BaseMsg: "I=IsCompare>",
							Parm1: "@rsvd_inv.qty_rsvd",
							Parm2: "@lot_loc.qty_on_hand");
						Infobar = MsgApp5.Infobar;

						#endregion ExecuteMethodCall

						//END

					}

				}
				//END

			}
			return (Severity, PUM, Infobar);

		}
		public (int? ReturnCode,
			string PUM,
			string Infobar)
		AltExtGen_CoResValidateQtySp(
			string AltExtGenSp,
			string PItem,
			decimal? PQtyRsvd,
			decimal? PQtyRsvdOld = 0,
			string PUM = null,
			string PCoNum = null,
			int? PLotTracked = null,
			string PCurWhse = null,
			string PLot = null,
			string PLoc = null,
			string Infobar = null,
			string PImportDocId = null,
			int? PTaxFreeMatl = null)
		{
			ItemType _PItem = PItem;
			QtyUnitType _PQtyRsvd = PQtyRsvd;
			QtyUnitType _PQtyRsvdOld = PQtyRsvdOld;
			UMType _PUM = PUM;
			CoNumType _PCoNum = PCoNum;
			ListYesNoType _PLotTracked = PLotTracked;
			WhseType _PCurWhse = PCurWhse;
			LotType _PLot = PLot;
			LocType _PLoc = PLoc;
			InfobarType _Infobar = Infobar;
			ImportDocIdType _PImportDocId = PImportDocId;
			ListYesNoType _PTaxFreeMatl = PTaxFreeMatl;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyRsvd", _PQtyRsvd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyRsvdOld", _PQtyRsvdOld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLotTracked", _PLotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurWhse", _PCurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLot", _PLot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLoc", _PLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PImportDocId", _PImportDocId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxFreeMatl", _PTaxFreeMatl, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				PUM = _PUM;
				Infobar = _Infobar;

				return (Severity, PUM, Infobar);
			}
		}

	}
}
