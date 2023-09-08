//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetCOCustInfo.cs

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
using CSI.Material;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSGetCOCustInfo : ISSSFSGetCOCustInfo
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ISSSFSGetCOCustInfoCRUD iSSSFSGetCOCustInfoCRUD;
        readonly IExpandKyByType iExpandKyByType;

        public SSSFSGetCOCustInfo(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ISSSFSGetCOCustInfoCRUD iSSSFSGetCOCustInfoCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iSSSFSGetCOCustInfoCRUD = iSSSFSGetCOCustInfoCRUD;
		}
		
		public (
			int? ReturnCode,
			string oCustNum,
			int? oCustSeq)
		SSSFSGetCOCustInfoSp (
			string iCoNum,
			string oCustNum,
			int? oCustSeq)
		{
			
			CustNumType _oCustNum = oCustNum;
			CustSeqType _oCustSeq = oCustSeq;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iSSSFSGetCOCustInfoCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSSFSGetCOCustInfoCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("SSSFSGetCOCustInfoSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iSSSFSGetCOCustInfoCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iSSSFSGetCOCustInfoCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iSSSFSGetCOCustInfoCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iSSSFSGetCOCustInfoCRUD.AltExtGen_SSSFSGetCOCustInfoSp (ALTGEN_SpName,
						iCoNum,
						oCustNum,
						oCustSeq);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, oCustNum, oCustSeq);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSSFSGetCOCustInfoCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iSSSFSGetCOCustInfoCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSFSGetCOCustInfoSp") != null)
			{
				var EXTGEN = this.iSSSFSGetCOCustInfoCRUD.AltExtGen_SSSFSGetCOCustInfoSp("dbo.EXTGEN_SSSFSGetCOCustInfoSp",
					iCoNum,
					oCustNum,
					oCustSeq);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.oCustNum, EXTGEN.oCustSeq);
				}
			}
			
			iCoNum = this.iExpandKyByType.ExpandKyByTypeFn(
				"CoNumType",
				iCoNum);
			(oCustNum, oCustSeq, rowCount) = this.iSSSFSGetCOCustInfoCRUD.COLoad(iCoNum, oCustNum, oCustSeq);
			
			return (Severity, oCustNum, oCustSeq);
		}
		
	}
}
