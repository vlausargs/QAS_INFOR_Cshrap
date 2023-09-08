//PROJECT NAME: Material
//CLASS NAME: CheckConsgnWhseForItem.cs

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

namespace CSI.Material
{
	public class CheckConsgnWhseForItem : ICheckConsgnWhseForItem
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICheckConsgnWhseForItemCRUD iCheckConsgnWhseForItemCRUD;
		
		public CheckConsgnWhseForItem(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICheckConsgnWhseForItemCRUD iCheckConsgnWhseForItemCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCheckConsgnWhseForItemCRUD = iCheckConsgnWhseForItemCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		CheckConsgnWhseForItemSp (
			string Item,
			string Whse,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCheckConsgnWhseForItemCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckConsgnWhseForItemCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCheckConsgnWhseForItemCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCheckConsgnWhseForItemCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckConsgnWhseForItemCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckConsgnWhseForItemCRUD.AltExtGen_CheckConsgnWhseForItemSp (ALTGEN_SpName,
						Item,
						Whse,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckConsgnWhseForItemCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckConsgnWhseForItemCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckConsgnWhseForItemSp") != null)
			{
				var EXTGEN = this.iCheckConsgnWhseForItemCRUD.AltExtGen_CheckConsgnWhseForItemSp("dbo.EXTGEN_CheckConsgnWhseForItemSp",
					Item,
					Whse,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			if (this.iCheckConsgnWhseForItemCRUD.WhseForExists(Whse))
			{
				if (this.iCheckConsgnWhseForItemCRUD.ItemwhseForExists(Item, Whse))
				{
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "E=AssignVendToConsgnWhse",
						Parm1: "@Item",
						Parm2: Item,
						Parm3: "@co.consignment",
						Parm4: "@whse");
					Severity = MsgApp.ReturnCode;
					Infobar = MsgApp.Infobar;
					
					#endregion ExecuteMethodCall
					
				}
				
			}
			return (Severity, Infobar);
			
		}
		
	}
}
