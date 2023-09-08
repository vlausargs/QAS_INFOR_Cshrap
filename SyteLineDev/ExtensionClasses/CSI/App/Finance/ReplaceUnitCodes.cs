//PROJECT NAME: Finance
//CLASS NAME: ReplaceUnitCodes.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.Data.SQL;
using System.Linq;

namespace CSI.Finance
{
	public class ReplaceUnitCodes : IReplaceUnitCodes
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly IReplaceUnitCodesCRUD iReplaceUnitCodesCRUD;
		
		public ReplaceUnitCodes(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			IReplaceUnitCodesCRUD iReplaceUnitCodesCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iReplaceUnitCodesCRUD = iReplaceUnitCodesCRUD;
		}
		
		public (ICollectionLoadResponse Data, 
			int? ReturnCode,
			string Infobar)
		ReplaceUnitCodesSp (
			string BegAcct,
			string EndAcct,
			int? UnitNumber,
			string OldUnitCode,
			string NewUnitCode,
			string Infobar)
		{
			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;
			string ParmsSite = null;
			string ChartUnitCd1 = null;
			string ChartUnitCd2 = null;
			string ChartUnitCd3 = null;
			string ChartUnitCd4 = null;
			string Unit1 = null;
			string Unit2 = null;
			string Unit3 = null;
			string Unit4 = null;
			string SqlUpdate = null;
			string SqlSet = null;
			string SqlWhereSub01 = null;
			string SqlWhereSub02 = null;
			string SqlWhereSub03 = null;
			string SqlWhereSub04 = null;
			string SqlWhereSub05 = null;
			string SqlWhereSub06 = null;
			string SqlSelect = null;
			if (this.iReplaceUnitCodesCRUD.Optional_ModuleForExists())
			{
				//BEGIN
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iReplaceUnitCodesCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("ReplaceUnitCodesSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iReplaceUnitCodesCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iReplaceUnitCodesCRUD.Tv_ALTGENForExists())
				{
					//BEGIN
					ALTGEN_SpName = this.iReplaceUnitCodesCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iReplaceUnitCodesCRUD.AltExtGen_ReplaceUnitCodesSp (ALTGEN_SpName,
						BegAcct,
						EndAcct,
						UnitNumber,
						OldUnitCode,
						NewUnitCode,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (Data, ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iReplaceUnitCodesCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iReplaceUnitCodesCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					//END
					
				}
				//END
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ReplaceUnitCodesSp") != null)
			{
				var EXTGEN = this.iReplaceUnitCodesCRUD.AltExtGen_ReplaceUnitCodesSp("dbo.EXTGEN_ReplaceUnitCodesSp",
					BegAcct,
					EndAcct,
					UnitNumber,
					OldUnitCode,
					NewUnitCode,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (Data, EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @UpdateTableColumnRange TABLE (
				    TableName      SYSNAME,
				    AcctColumnName SYSNAME,
				    UCColumnName   SYSNAME);
				SELECT * into #tv_UpdateTableColumnRange from @UpdateTableColumnRange");
			Severity = 0;
			Infobar = null;
			var parmsLoadResponseForScalarSubQuery = this.iReplaceUnitCodesCRUD.ParmsSelect();
			ParmsSite = ((parmsLoadResponseForScalarSubQuery.Items != null &&
			parmsLoadResponseForScalarSubQuery.Items.Count != 0) ?
			(parmsLoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<string>("site")) : null);
			ChartUnitCd1 = "chart_unitcd1";
			ChartUnitCd2 = "chart_unitcd2";
			ChartUnitCd3 = "chart_unitcd3";
			ChartUnitCd4 = "chart_unitcd4";
			Unit1 = "unit1";
			Unit2 = "unit2";
			Unit3 = "unit3";
			Unit4 = "unit4";
			SqlUpdate = "UPDATE <TableName> ";
			SqlSet = "SET <UCAcctName> = N'<NewUnitCode>' ";
			SqlWhereSub01 = "WHERE 1 = 1 ";
			SqlWhereSub02 = "AND <AcctColumnName> IN ( SELECT acct FROM <chart_unitcdN> WHERE <UnitN> = N'<NewUnitCode>' ";
			SqlWhereSub03 = "AND acct BETWEEN <BegAcct> AND <EndAcct> ) ";
			SqlWhereSub04 = "AND <UCAcctName> =  N'<OldUnitCode>' ";
			SqlWhereSub05 = "AND from_site IN ( N'<ParmsSite>' ) ";
			SqlWhereSub06 = "AND NOT EXISTS (SELECT 1 FROM <TableName> AS tab WHERE tab.<AcctColumnName> = <TableName>.<AcctColumnName> AND tab.<UCAcctName> = <TableName>.<UCAcctName>)";
			UnionUtil unionTable = new UnionUtil(UnionType.Union);
			var tv_UpdateTableColumnRange1LoadResponse = this.iReplaceUnitCodesCRUD.Tv_Updatetablecolumnrange1Select(UnitNumber);
			this.iReplaceUnitCodesCRUD.Tv_Updatetablecolumnrange1Insert(tv_UpdateTableColumnRange1LoadResponse);
			
			unionTable.Add(tv_UpdateTableColumnRange1LoadResponse);
			var tv_UpdateTableColumnRange2LoadResponse = this.iReplaceUnitCodesCRUD.Tv_Updatetablecolumnrange2Select(UnitNumber);
			this.iReplaceUnitCodesCRUD.Tv_Updatetablecolumnrange2Insert(tv_UpdateTableColumnRange2LoadResponse);
			
			unionTable.Add(tv_UpdateTableColumnRange2LoadResponse);
			var unionTableResultLoadResponse = unionTable.Process();
			this.iReplaceUnitCodesCRUD.UniontableresultInsert(unionTableResultLoadResponse);
			
			SqlSelect = this.iReplaceUnitCodesCRUD.Tv_Updatetablecolumnrange3Load(SqlWhereSub01,
				 SqlWhereSub02,
				 SqlWhereSub03,
				 SqlWhereSub04,
				 SqlWhereSub05,
				 SqlWhereSub06,
				 SqlSelect,
				 SqlUpdate,
				 ParmsSite,
				 SqlSet);
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<NewUnitCode>",
				stringUtil.Replace(
					NewUnitCode,
					"'",
					"''"));
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<BegAcct>",
				(BegAcct== null ? "acct" : stringUtil.Concat("'", stringUtil.Replace(
							BegAcct,
							"'",
							"''"), "'")));
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<EndAcct>",
				(EndAcct== null ? "acct" : stringUtil.Concat("'", stringUtil.Replace(
							EndAcct,
							"'",
							"''"), "'")));
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<OldUnitCode>",
				stringUtil.Replace(
					OldUnitCode,
					"'",
					"''"));
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<chart_unitcdN>",
				(sQLUtil.SQLEqual(UnitNumber, 1) == true ? ChartUnitCd1 : sQLUtil.SQLEqual(UnitNumber, 2) == true ? ChartUnitCd2 : sQLUtil.SQLEqual(UnitNumber, 3) == true ? ChartUnitCd3 : sQLUtil.SQLEqual(UnitNumber, 4) == true ? ChartUnitCd4 : null));
			SqlSelect = stringUtil.Replace(
				SqlSelect,
				"<UnitN>",
				(sQLUtil.SQLEqual(UnitNumber, 1) == true ? Unit1 : sQLUtil.SQLEqual(UnitNumber, 2) == true ? Unit2 : sQLUtil.SQLEqual(UnitNumber, 3) == true ? Unit3 : sQLUtil.SQLEqual(UnitNumber, 4) == true ? Unit4 : null));
			if (sQLUtil.SQLBool((sQLUtil.SQLEqual(UnitNumber, 1))))
			{
				//BEGIN
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iReplaceUnitCodesCRUD.Chart_Unitcd1ForExists(BegAcct, EndAcct, NewUnitCode))))
				{
					goto SP_FAILURE;
					
				}
				//END
				
			}
			if (sQLUtil.SQLBool((sQLUtil.SQLEqual(UnitNumber, 2))))
			{
				//BEGIN
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iReplaceUnitCodesCRUD.Chart_Unitcd2ForExists(BegAcct, EndAcct, NewUnitCode))))
				{
					goto SP_FAILURE;
					
				}
				//END
				
			}
			if (sQLUtil.SQLBool((sQLUtil.SQLEqual(UnitNumber, 3))))
			{
				//BEGIN
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iReplaceUnitCodesCRUD.Chart_Unitcd3ForExists(BegAcct, EndAcct, NewUnitCode))))
				{
					goto SP_FAILURE;
					
				}
				//END
				
			}
			if (sQLUtil.SQLBool((sQLUtil.SQLEqual(UnitNumber, 4))))
			{
				//BEGIN
				if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iReplaceUnitCodesCRUD.Chart_Unitcd4ForExists(BegAcct, EndAcct, NewUnitCode))))
				{
					goto SP_FAILURE;

				}
				//END

			}
			
			
			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SqlSelect, "");
			Data = execResult.Data;


			//SP_SUCCESS: ;
			//BEGIN
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "I=CmdSucceeded",
				Parm1: "@!UnitCodeReplacementUtility");
			Infobar = MsgApp.Infobar;
			
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity, Infobar);
			//END

			SP_FAILURE: ;
			//BEGIN
			
			#region CRUD ExecuteMethodCall
			
			var MsgApp1 = this.iMsgApp.MsgAppSp(
				Infobar: Infobar,
				BaseMsg: "E=InvalidUnitCode",
				Parm1: "@!UnitCodeReplacementUtility");
			Severity = MsgApp1.ReturnCode;
			Infobar = MsgApp1.Infobar;
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity, Infobar);
			//END
			
		}
		
	}
}
