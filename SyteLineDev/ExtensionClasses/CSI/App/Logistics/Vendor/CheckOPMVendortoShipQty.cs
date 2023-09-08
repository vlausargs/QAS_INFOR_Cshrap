//PROJECT NAME: Logistics
//CLASS NAME: CheckOPMVendortoShipQty.cs

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

namespace CSI.Logistics.Vendor
{
	public class CheckOPMVendortoShipQty : ICheckOPMVendortoShipQty
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		
		public CheckOPMVendortoShipQty(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
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
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		CheckOPMVendortoShipQtySp (
			string PoNum,
			int? PoLine,
			int? PoRelease = 0,
			decimal? PoOrderedQtyConv = 0,
			string Infobar = null)
		{
			
			
			
			
			
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			QtyUnitNoNegType _DispQty = DBNull.Value;
			decimal? DispQty = null;
			if (existsChecker.Exists(tableName:"optional_module",
			fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
			whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'CheckOPMVendortoShipQtySp_' + [om].[ModuleName])) IS NOT NULL")))
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute("DECLARE @ALTGEN TABLE ("
				+ "    [SpName] sysname);"
				+ "SELECT * into #tv_ALTGEN from @ALTGEN ");
				
				#region CRUD LoadToRecord
				var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName",$"CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
                lockingType: LockingType.None,
                tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause($"ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'CheckOPMVendortoShipQtySp_' + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord
				
				
				#region CRUD InsertByRecords
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.Concat("CheckOPMVendortoShipQtySp_", optional_module1Item.GetValue<string>("u0")));
				};
				
			var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
				
				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords
				
				while (existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("")))
				{
					//BEGIN
					
					#region CRUD LoadToVariable
					var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
					{
						{_ALTGEN_SpName,$"[SpName]"},
					},
					loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
					tableName:"#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause(""),
					orderByClause: collectionLoadRequestFactory.Clause(""));
					var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
					if(tv_ALTGEN1LoadResponse.Items.Count > 0)
					{
						ALTGEN_SpName = _ALTGEN_SpName;
					}
					#endregion  LoadToVariable
					
					var ALTGEN = AltExtGen_CheckOPMVendortoShipQtySp (_ALTGEN_SpName,
						PoNum,
						PoLine,
						PoRelease,
						PoOrderedQtyConv,
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
					tableName:"#tv_ALTGEN",
                    loadForChange: true, 
                    lockingType: LockingType.None,
                    fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
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
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckOPMVendortoShipQtySp") != null)
			{
				var EXTGEN = AltExtGen_CheckOPMVendortoShipQtySp("dbo.EXTGEN_CheckOPMVendortoShipQtySp",
					PoNum,
					PoLine,
					PoRelease,
					PoOrderedQtyConv,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			Infobar = null;
			//BEGIN
			
			#region CRUD LoadToVariable
			var vend_to_shipLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
			{
				{_DispQty,$"qty_disp_conv"},
			},
			loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "poitem",
            fromClause: collectionLoadRequestFactory.Clause(" INNER JOIN vend_to_ship ON poitem.po_num = vend_to_ship.ref_num "
            + "AND poitem.po_line = vend_to_ship.ref_line_suf "
            + "AND poitem.po_release = vend_to_ship.ref_release "
            + "AND vend_to_ship.ref_type = 'P' "
            + "AND vend_to_ship.complete = 0"),
            whereClause: collectionLoadRequestFactory.Clause("poitem.po_num = {3} AND poitem.po_line = {2} AND poitem.po_release = {1} AND vend_to_ship.qty_disp_conv <> {0}", PoOrderedQtyConv, PoRelease, PoLine, PoNum),
			orderByClause: collectionLoadRequestFactory.Clause(""));
			var vend_to_shipLoadResponse = this.appDB.Load(vend_to_shipLoadRequest);
			if(vend_to_shipLoadResponse.Items.Count > 0)
			{
				DispQty = _DispQty;
                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "I=IsCompare<>1",
                    Parm1: "@!QtyOrdered",
                    Parm2: "@vend_to_ship.qty_disp",
                    Parm3: "@jobroute",
                    Parm4: "@vend_to_ship.qty_disp",
                    Parm5: convertToUtil.ToString(DispQty));
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall
            }
            #endregion  LoadToVariable

            //END
            return (Severity, Infobar);
			
		}
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_CheckOPMVendortoShipQtySp(
			string AltExtGenSp,
			string PoNum,
			int? PoLine,
			int? PoRelease = 0,
			decimal? PoOrderedQtyConv = 0,
			string Infobar = null)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			PoReleaseType _PoRelease = PoRelease;
			QtyUnitNoNegType _PoOrderedQtyConv = PoOrderedQtyConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoRelease", _PoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoOrderedQtyConv", _PoOrderedQtyConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				
				
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
