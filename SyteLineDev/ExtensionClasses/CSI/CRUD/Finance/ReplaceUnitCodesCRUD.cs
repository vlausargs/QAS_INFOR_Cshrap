//PROJECT NAME: Finance
//CLASS NAME: ReplaceUnitCodesCRUD.cs

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
	public class ReplaceUnitCodesCRUD : IReplaceUnitCodesCRUD
	{
		readonly IApplicationDB appDB;
		
		readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IVariableUtil variableUtil;
		
		public ReplaceUnitCodesCRUD(IApplicationDB appDB,
			ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IVariableUtil variableUtil)
		{
			this.appDB = appDB;
			this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.variableUtil = variableUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ReplaceUnitCodesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('ReplaceUnitCodesSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
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
		
		public string Tv_ALTGEN1Load(string ALTGEN_SpName)
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
			
			return ALTGEN_SpName;
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
		
		public ICollectionLoadResponse ParmsSelect()
		{
			var parmsLoadRequestForScalarSubQuery = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"site","site"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"parms",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("parm_key = 0"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(parmsLoadRequestForScalarSubQuery);
		}
		
		public ICollectionLoadResponse Tv_Updatetablecolumnrange1Select(int? UnitNumber)
		{
			var tv_UpdateTableColumnRange1LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "TableName", "syoT.[name]" },
					{ "AcctColumnName", "colsA.[name]" },
					{ "UCColumnName", "colsUc.[name]" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM sys.objects AS syoT
					INNER JOIN
					sys.columns AS colsA
					ON syoT.object_id = colsA.object_id
					INNER JOIN
					sys.types AS colsAUDT
					ON colsA.user_type_id = colsAUDT.user_type_id
					AND PATINDEX('AcctType', colsAUDT.[name]) > 0
					INNER JOIN
					sys.columns AS colsUc
					ON syoT.object_id = colsUc.object_id
					AND PATINDEX(colsA.[name] + '%', colsUc.[name]) > 0
					INNER JOIN
					sys.types AS colsUcUdt
					ON colsUc.user_type_id = colsUcUdt.user_type_id
					AND 1 = CASE WHEN (ISNULL({0}, 0) = 1)
					AND (PATINDEX('UnitCode1Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 2)
					AND (PATINDEX('UnitCode2Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 3)
					AND (PATINDEX('UnitCode3Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 4)
					AND (PATINDEX('UnitCode4Type', colsUcUdt.[name]) > 0) THEN 1 ELSE 2 END
					WHERE 1 = 1
					AND syoT.type = 'V'
					AND syoT.[name] IN ('apparms', 'arparms', 'bank_addr', 'bank_hdr', 'chart_bp', 'chart_d', 'curracct', 'currparms', 'dept', 'discount', 'distacct', 'employee', 'endtype', 'faclass', 'fadist', 'faparms', 'glrptl', 'indcode', 'itemlifo', 'itemloc', 'parms', 'poparms', 'prdecd', 'prodcode', 'prodvar', 'projparm', 'prparms', 'prtaxt', 'reason', 'rmaparms', 'sfcparms', 'sitenet', 'vendcat', 'vendor', 'wc')", UnitNumber));
			
			return this.appDB.Load(tv_UpdateTableColumnRange1LoadRequest);
		}
		
		public void Tv_Updatetablecolumnrange1Insert(ICollectionLoadResponse tv_UpdateTableColumnRange1LoadResponse)
		{
			var tv_UpdateTableColumnRange1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_UpdateTableColumnRange",
				items: tv_UpdateTableColumnRange1LoadResponse.Items);
			
			this.appDB.Insert(tv_UpdateTableColumnRange1InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Updatetablecolumnrange2Select(int? UnitNumber)
		{
			var tv_UpdateTableColumnRange2LoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{ "TableName", "syoT.[name]" },
					{ "AcctColumnName", "colsA.[name]" },
					{ "UCColumnName", "colsUc.[name]" },
				},
				selectStatement: collectionLoadRequestFactory.Clause(@"SELECT @selectList
					FROM sys.objects AS syoT
					INNER JOIN
					sys.columns AS colsA
					ON syoT.object_id = colsA.object_id
					AND colsA.[name] = 'acquisition_vat_acct'
					INNER JOIN
					sys.types AS colsAUDT
					ON colsA.user_type_id = colsAUDT.user_type_id
					AND PATINDEX('AcctType', colsAUDT.[name]) > 0
					INNER JOIN
					sys.columns AS colsUc
					ON syoT.object_id = colsUc.object_id
					AND PATINDEX(colsA.[name] + '%', colsUc.[name]) > 0
					INNER JOIN
					sys.types AS colsUcUdt
					ON colsUc.user_type_id = colsUcUdt.user_type_id
					AND 1 = CASE WHEN (ISNULL({0}, 0) = 1)
					AND (PATINDEX('UnitCode1Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 2)
					AND (PATINDEX('UnitCode2Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 3)
					AND (PATINDEX('UnitCode3Type', colsUcUdt.[name]) > 0) THEN 1 WHEN (ISNULL({0}, 0) = 4)
					AND (PATINDEX('UnitCode4Type', colsUcUdt.[name]) > 0) THEN 1 ELSE 2 END
					WHERE 1 = 1
					AND syoT.type = 'V'
					AND syoT.[name] = 'taxcode'", UnitNumber));
			
			return this.appDB.Load(tv_UpdateTableColumnRange2LoadRequest);
		}
		
		public void Tv_Updatetablecolumnrange2Insert(ICollectionLoadResponse tv_UpdateTableColumnRange2LoadResponse)
		{
			var tv_UpdateTableColumnRange2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_UpdateTableColumnRange",
				items: tv_UpdateTableColumnRange2LoadResponse.Items);
			
			this.appDB.Insert(tv_UpdateTableColumnRange2InsertRequest);
		}
		
		public void UniontableresultInsert(ICollectionLoadResponse unionTableResultLoadResponse)
		{
			var unionTableResultInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_UpdateTableColumnRange",
				items: unionTableResultLoadResponse.Items);
			
			this.appDB.Insert(unionTableResultInsertRequest);
		}
		
		public string Tv_Updatetablecolumnrange3Load(string SqlWhereSub01,
			string SqlWhereSub02,
			string SqlWhereSub03,
			string SqlWhereSub04,
			string SqlWhereSub05,
			string SqlWhereSub06,
			string SqlSelect,
			string SqlUpdate,
			string ParmsSite,
			string SqlSet)
		{
			StringType _SqlSelect = DBNull.Value;
			
			var tv_UpdateTableColumnRange3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_SqlSelect,$"ISNULL({variableUtil.GetQuotedValue<string>(SqlSelect)}, N'') + (N'' + REPLACE({variableUtil.GetQuotedValue<string>(SqlUpdate)}, '<TableName>', tmp.TableName) + REPLACE({variableUtil.GetQuotedValue<string>(SqlSet)}, '<UCAcctName>', tmp.UCColumnName) + {variableUtil.GetQuotedValue<string>(SqlWhereSub01)} + REPLACE({variableUtil.GetQuotedValue<string>(SqlWhereSub02)}, '<AcctColumnName>', tmp.AcctColumnName) + {variableUtil.GetQuotedValue<string>(SqlWhereSub03)} + REPLACE({variableUtil.GetQuotedValue<string>(SqlWhereSub04)}, '<UCAcctName>', tmp.UCColumnName) + CASE WHEN ISNULL(tmp.TableName, N'') = 'sitenet' THEN REPLACE({variableUtil.GetQuotedValue<string>(SqlWhereSub05)}, '<ParmsSite>', REPLACE({variableUtil.GetQuotedValue<string>(ParmsSite)}, N'''', N'''''')) ELSE N'' END + CASE WHEN tmp.TableName IN ('chart_bp') THEN replace(replace(replace(replace({variableUtil.GetQuotedValue<string>(SqlWhereSub06)}, '<TableName>', tmp.TableName), '<UCAcctName>', tmp.UCColumnName), '<AcctColumnName>', tmp.AcctColumnName), '<UCAcctName>', tmp.UCColumnName) ELSE N'' END) + NCHAR(13)"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName:"#tv_UpdateTableColumnRange",
				fromClause: collectionLoadRequestFactory.Clause(" AS tmp"),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var tv_UpdateTableColumnRange3LoadResponse = this.appDB.Load(tv_UpdateTableColumnRange3LoadRequest);
			if(tv_UpdateTableColumnRange3LoadResponse.Items.Count > 0)
			{
				SqlSelect = _SqlSelect;
			}
			
			return SqlSelect;
		}
		
		public bool Chart_Unitcd1ForExists(string BegAcct, string EndAcct, string NewUnitCode)
		{
			return existsChecker.Exists(tableName:"chart_unitcd1",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("unit1 = {0} AND acct BETWEEN ISNULL({1}, acct) AND ISNULL({2}, acct)",NewUnitCode,BegAcct,EndAcct));
		}
		
		public bool Chart_Unitcd2ForExists(string BegAcct, string EndAcct, string NewUnitCode)
		{
			return existsChecker.Exists(tableName:"chart_unitcd2",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("unit2 = {0} AND acct BETWEEN ISNULL({1}, acct) AND ISNULL({2}, acct)",NewUnitCode,BegAcct,EndAcct));
		}
		
		public bool Chart_Unitcd3ForExists(string BegAcct, string EndAcct, string NewUnitCode)
		{
			return existsChecker.Exists(tableName:"chart_unitcd3",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("unit3 = {0} AND acct BETWEEN ISNULL({1}, acct) AND ISNULL({2}, acct)",NewUnitCode,BegAcct,EndAcct));
		}
		
		public bool Chart_Unitcd4ForExists(string BegAcct, string EndAcct, string NewUnitCode)
		{
			return existsChecker.Exists(tableName:"chart_unitcd4",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("unit4 = {0} AND acct BETWEEN ISNULL({1}, acct) AND ISNULL({2}, acct)",NewUnitCode,BegAcct,EndAcct));
		}
		
		public (int? ReturnCode,
			string Infobar)
		AltExtGen_ReplaceUnitCodesSp(
			string AltExtGenSp,
			string BegAcct,
			string EndAcct,
			int? UnitNumber,
			string OldUnitCode,
			string NewUnitCode,
			string Infobar)
		{
			AcctType _BegAcct = BegAcct;
			AcctType _EndAcct = EndAcct;
			IntType _UnitNumber = UnitNumber;
			UnitCode1Type _OldUnitCode = OldUnitCode;
			UnitCode1Type _NewUnitCode = NewUnitCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "BegAcct", _BegAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAcct", _EndAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitNumber", _UnitNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldUnitCode", _OldUnitCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewUnitCode", _NewUnitCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
		
	}
}
