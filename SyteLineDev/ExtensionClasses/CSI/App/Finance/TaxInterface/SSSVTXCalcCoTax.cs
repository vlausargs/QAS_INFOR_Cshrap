//PROJECT NAME: Finance
//CLASS NAME: SSSVTXCalcCoTax.cs

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
using CSI.Logistics.Customer;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXCalcCoTax : ISSSVTXCalcCoTax
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IUndefineVariable iUndefineVariable;
		readonly IDefineVariable iDefineVariable;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ISumCo iSumCo;
		readonly ISSSVTXCalcCoTaxCRUD iSSSVTXCalcCoTaxCRUD;
		
		public SSSVTXCalcCoTax(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IUndefineVariable iUndefineVariable,
			IDefineVariable iDefineVariable,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ISumCo iSumCo,
			ISSSVTXCalcCoTaxCRUD iSSSVTXCalcCoTaxCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iUndefineVariable = iUndefineVariable;
			this.iDefineVariable = iDefineVariable;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iSumCo = iSumCo;
			this.iSSSVTXCalcCoTaxCRUD = iSSSVTXCalcCoTaxCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		SSSVTXCalcCoTaxSp (
			string pCoNum,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iSSSVTXCalcCoTaxCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSSVTXCalcCoTaxCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("SSSVTXCalcCoTaxSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iSSSVTXCalcCoTaxCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iSSSVTXCalcCoTaxCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iSSSVTXCalcCoTaxCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iSSSVTXCalcCoTaxCRUD.AltExtGen_SSSVTXCalcCoTaxSp (ALTGEN_SpName,
						pCoNum,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSSVTXCalcCoTaxCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iSSSVTXCalcCoTaxCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSVTXCalcCoTaxSp") != null)
			{
				var EXTGEN = this.iSSSVTXCalcCoTaxCRUD.AltExtGen_SSSVTXCalcCoTaxSp("dbo.EXTGEN_SSSVTXCalcCoTaxSp",
					pCoNum,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: DefineVariableSp
			var DefineVariable = this.iDefineVariable.DefineVariableSp(
				VariableName: "SSSVTXTaxCalcForceCalc",
				VariableValue: convertToUtil.ToString(1),
				Infobar: Infobar);
			Severity = DefineVariable.ReturnCode;
			Infobar = DefineVariable.Infobar;
			
			#endregion ExecuteMethodCall
			
			if (sQLUtil.SQLNotEqual(Severity, 0) == true)
			{
				return (Severity, Infobar);
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: SumCoSp
			var SumCo = this.iSumCo.SumCoSp(
				PCoNum: pCoNum,
				Infobar: Infobar);
			Severity = SumCo.ReturnCode;
			Infobar = SumCo.Infobar;
			
			#endregion ExecuteMethodCall
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: UndefineVariableSp
			var UndefineVariable = this.iUndefineVariable.UndefineVariableSp(
				VariableName: "SSSVTXTaxCalcForceCalc",
				Infobar: Infobar);
			Infobar = UndefineVariable.Infobar;
			
			#endregion ExecuteMethodCall
			
			return (Severity, Infobar);
			
		}
		
	}
}
