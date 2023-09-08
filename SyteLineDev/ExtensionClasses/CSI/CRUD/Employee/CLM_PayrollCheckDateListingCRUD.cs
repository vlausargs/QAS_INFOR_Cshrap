//PROJECT NAME: Employee
//CLASS NAME: CLM_PayrollCheckDateListingCRUD.cs

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
	public class CLM_PayrollCheckDateListingCRUD : ICLM_PayrollCheckDateListingCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		
		public CLM_PayrollCheckDateListingCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PayrollCheckDateListingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}
		
		public ICollectionLoadResponse Optional_Module1Select()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PayrollCheckDateListingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_PayrollCheckDateListingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};
			
			return optional_module1LoadResponse;
		}
		
		public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);
			
			this.appDB.Insert(optional_module1InsertRequest);
		}
		
		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}
		
		public (string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;
			
			var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_ALTGEN_SpName,"[SpName]"},
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
			
			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}
		
		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
		{
			var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"[SpName]","[SpName]"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}",ALTGEN_SpName),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}
		
		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_TblSelect()
		{
			var tv_tmp_tblLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"RowPointer","RowPointer"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tblLoadRequest);
		}
		
		public void Tv_Tmp_TblDelete(ICollectionLoadResponse tv_tmp_tblLoadResponse)
		{
			var tv_tmp_tblDeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tblLoadResponse.Items);
			this.appDB.Delete(tv_tmp_tblDeleteRequest);
		}
		
		public ICollectionLoadResponse PrtrxpSelect(string EmpNum)
		{
			var prtrxpLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CheckDate","p1.check_date"},
					{"CheckNum","p1.check_num"},
					{"RowPointer","p1.RowPointer"},
					{"PerStart","p1.per_start"},
					{"PerEnd","p1.per_end"},
					{"GrossPay","p1.gross_pay"},
					{"NetPay","CAST (NULL AS DECIMAL)"},
					{"TotalTaxes","CAST (NULL AS DECIMAL)"},
					{"TotalDed","CAST (NULL AS DECIMAL)"},
					{"DirectDep","CAST (NULL AS DECIMAL)"},
					{"Type","p1.Type"},
					{"u0","p1.net_pay"},
					{"u1","p1.dep_amt"},
					{"u2","p1.fwt"},
					{"u3","p1.e_fica"},
					{"u4","p1.e_med"},
					{"u5","p1.swt"},
					{"u6","p1.ost"},
					{"u7","p1.cwt"},
					{"u8","p1.eic"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("LTRIM(p1.emp_num) = LTRIM({0}) AND type <> 'A'",EmpNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var prtrxpLoadResponse = this.appDB.Load(prtrxpLoadRequest);
			
			foreach(var prtrxpItem in prtrxpLoadResponse.Items){
				prtrxpItem.SetValue<DateTime?>("CheckDate", prtrxpItem.GetValue<DateTime?>("CheckDate"));
				prtrxpItem.SetValue<int?>("CheckNum", prtrxpItem.GetValue<int?>("CheckNum"));
				prtrxpItem.SetValue<Guid?>("RowPointer", prtrxpItem.GetValue<Guid?>("RowPointer"));
				prtrxpItem.SetValue<DateTime?>("PerStart", prtrxpItem.GetValue<DateTime?>("PerStart"));
				prtrxpItem.SetValue<DateTime?>("PerEnd", prtrxpItem.GetValue<DateTime?>("PerEnd"));
				prtrxpItem.SetValue<decimal?>("GrossPay", prtrxpItem.GetValue<decimal?>("GrossPay"));
				prtrxpItem.SetValue<decimal?>("NetPay", (prtrxpItem.GetValue<decimal?>("u0") + prtrxpItem.GetValue<decimal?>("u1")));
				prtrxpItem.SetValue<decimal?>("TotalTaxes", (prtrxpItem.GetValue<decimal?>("u2") + prtrxpItem.GetValue<decimal?>("u3") + prtrxpItem.GetValue<decimal?>("u4") + prtrxpItem.GetValue<decimal?>("u5") + prtrxpItem.GetValue<decimal?>("u6") + prtrxpItem.GetValue<decimal?>("u7") - prtrxpItem.GetValue<decimal?>("u8")));
				prtrxpItem.SetValue<decimal?>("TotalDed", (prtrxpItem.GetValue<decimal?>("GrossPay") - prtrxpItem.GetValue<decimal?>("u2") - prtrxpItem.GetValue<decimal?>("u3") - prtrxpItem.GetValue<decimal?>("u4") - prtrxpItem.GetValue<decimal?>("u5") - prtrxpItem.GetValue<decimal?>("u6") - prtrxpItem.GetValue<decimal?>("u7") - prtrxpItem.GetValue<decimal?>("u0") - prtrxpItem.GetValue<decimal?>("u1")));
				prtrxpItem.SetValue<decimal?>("DirectDep", stringUtil.IsNull<decimal?>(
					prtrxpItem.GetValue<decimal?>("u1"),
					0));
				prtrxpItem.SetValue<string>("Type", prtrxpItem.GetValue<string>("Type"));
			};
			
			return prtrxpLoadResponse;
		}
		
		public void PrtrxpInsert(ICollectionLoadResponse prtrxpLoadResponse)
		{
			var prtrxpInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: prtrxpLoadResponse.Items);
			
			this.appDB.Insert(prtrxpInsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl1Select()
		{
			var CurprtrxpLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CheckNum","CheckNum"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var CurprtrxpLoadResponseForCursor = this.appDB.Load(CurprtrxpLoadRequestForCursor);
			return CurprtrxpLoadResponseForCursor;
		}
		public bool Prtrxp1ForExists(string EmpNum, int? CheckNum)
		{
			return existsChecker.Exists(tableName: "prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("check_num = {0} AND LTRIM(emp_num) = LTRIM({1}) AND type = 'A'",CheckNum,EmpNum));
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl2Select(int? CheckNum)
		{
			var tv_tmp_tbl2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CheckNum","CheckNum"},
				},
				loadForChange: true,
				lockingType: LockingType.None,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("CheckNum = {0}",CheckNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl2LoadRequest);
		}
		
		public void Tv_Tmp_Tbl2Delete(ICollectionLoadResponse tv_tmp_tbl2LoadResponse)
		{
			var tv_tmp_tbl2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl2LoadResponse.Items);
			this.appDB.Delete(tv_tmp_tbl2DeleteRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl3Select()
		{
			var tv_tmp_tbl3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"CheckDate","CheckDate"},
					{"CheckNum","CheckNum"},
					{"RowPointer","RowPointer"},
					{"PerStart","PerStart"},
					{"PerEnd","PerEnd"},
					{"GrossPay","GrossPay"},
					{"NetPay","NetPay"},
					{"TotalTaxes","TotalTaxes"},
					{"TotalDed","TotalDed"},
					{"DirectDep","DirectDep"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(" CheckDate DESC, CheckNum DESC"));
			return this.appDB.Load(tv_tmp_tbl3LoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_PayrollCheckDateListingSp(
			string AltExtGenSp,
			string EmpNum)
		{
			EmpNumType _EmpNum = EmpNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
				var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;
				
				return (resultSet, returnCode);
			}
		}
		
	}
}
