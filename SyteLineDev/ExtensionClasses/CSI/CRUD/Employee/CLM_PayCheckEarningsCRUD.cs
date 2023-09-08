//PROJECT NAME: Employee
//CLASS NAME: CLM_PayCheckEarningsCRUD.cs

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
using CSI.Data.Cache;

namespace CSI.Employee
{
	public class CLM_PayCheckEarningsCRUD : ICLM_PayCheckEarningsCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		// Bunching required interfaces.
		readonly IRecordStreamFactory recordStreamFactory;
		readonly ICache mgSessionVariableBasedCache;
		readonly IQueryLanguage queryLanguage;
		readonly ISortOrderFactory sortOrderFactory;
		// Bunching required interfaces.


		public CLM_PayCheckEarningsCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IRecordStreamFactory recordStreamFactory,
			ISortOrderFactory sortOrderFactory,
			IQueryLanguage queryLanguage,
			ICache mgSessionVariableBasedCache)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.recordStreamFactory = recordStreamFactory;
			this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
			this.queryLanguage = queryLanguage;
			this.sortOrderFactory = sortOrderFactory;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PayCheckEarningsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_PayCheckEarningsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			
			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
			
			foreach(var optional_module1Item in optional_module1LoadResponse.Items){
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_PayCheckEarningsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
					{"description","description"},
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
		
		public (int? CheckNum, int? rowCount) PrtrxpLoad(Guid? CheckRowPointer, int? CheckNum)
		{
			PrCheckNumType _CheckNum = DBNull.Value;
			
			var prtrxpLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_CheckNum,"check_num"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prtrxpLoadResponse = this.appDB.Load(prtrxpLoadRequest);
			if(prtrxpLoadResponse.Items.Count > 0)
			{
				CheckNum = _CheckNum;
			}
			
			int rowCount = prtrxpLoadResponse.Items.Count;
			return (CheckNum, rowCount);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl1Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Salary')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("0")},
					{"hrs",collectionLoadRequestFactory.Clause("0")},
					{"pay",collectionLoadRequestFactory.Clause("CASE WHEN p1.pay_salary = 1 THEN p1.reg_pay ELSE 0 END")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.reg_pay) FROM   prtrxp AS p2 WHERE  p2.pay_salary = 1        AND LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("1")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl1LoadRequest);
		}
		
		public void Tv_Tmp_Tbl1Insert(ICollectionLoadResponse tv_tmp_tbl1LoadResponse)
		{
			var tv_tmp_tbl1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl1LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl1InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl2Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Hourly')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.pay_salary = 0          AND p1.reg_hrs > 0 THEN p1.reg_pay / p1.reg_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("CASE WHEN p1.pay_salary = 0 THEN p1.reg_hrs ELSE 0 END")},
					{"pay",collectionLoadRequestFactory.Clause("CASE WHEN p1.pay_salary = 0 THEN p1.reg_pay ELSE 0 END")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.reg_pay) FROM   prtrxp AS p2 WHERE  p2.pay_salary = 0        AND LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("2")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl2LoadRequest);
		}
		
		public void Tv_Tmp_Tbl2Insert(ICollectionLoadResponse tv_tmp_tbl2LoadResponse)
		{
			var tv_tmp_tbl2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl2LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl2InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl3Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Overtime')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.ot_hrs > 0 THEN p1.ot_pay / p1.ot_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.ot_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.ot_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.ot_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("3")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl3LoadRequest);
		}
		
		public void Tv_Tmp_Tbl3Insert(ICollectionLoadResponse tv_tmp_tbl3LoadResponse)
		{
			var tv_tmp_tbl3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl3LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl3InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl4Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!DoubleTime')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.dt_hrs > 0 THEN p1.dt_pay / p1.dt_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.dt_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.dt_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.dt_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("4")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl4LoadRequest);
		}
		
		public void Tv_Tmp_Tbl4Insert(ICollectionLoadResponse tv_tmp_tbl4LoadResponse)
		{
			var tv_tmp_tbl4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl4LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl4InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl5Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Vacation')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.vac_hrs > 0 THEN p1.vac_pay / p1.vac_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.vac_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.vac_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.vac_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("5")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl5LoadRequest);
		}
		
		public void Tv_Tmp_Tbl5Insert(ICollectionLoadResponse tv_tmp_tbl5LoadResponse)
		{
			var tv_tmp_tbl5InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl5LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl5InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl6Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Sick')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.sick_hrs > 0 THEN p1.sick_pay / p1.sick_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.sick_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.sick_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.sick_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("6")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl6LoadRequest);
		}
		
		public void Tv_Tmp_Tbl6Insert(ICollectionLoadResponse tv_tmp_tbl6LoadResponse)
		{
			var tv_tmp_tbl6InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl6LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl6InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl7Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl7LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Holiday')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.hol_hrs > 0 THEN p1.hol_pay / p1.hol_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.hol_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.hol_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.hol_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("7")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl7LoadRequest);
		}
		
		public void Tv_Tmp_Tbl7Insert(ICollectionLoadResponse tv_tmp_tbl7LoadResponse)
		{
			var tv_tmp_tbl7InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl7LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl7InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl8Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl8LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@!Other')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("CASE WHEN p1.oth_hrs > 0 THEN p1.oth_pay / p1.oth_hrs ELSE 0 END")},
					{"hrs",collectionLoadRequestFactory.Clause("p1.oth_hrs")},
					{"pay",collectionLoadRequestFactory.Clause("p1.oth_pay")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.oth_pay) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("8")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl8LoadRequest);
		}
		
		public void Tv_Tmp_Tbl8Insert(ICollectionLoadResponse tv_tmp_tbl8LoadResponse)
		{
			var tv_tmp_tbl8InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl8LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl8InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl9Select(DateTime? YearStart, DateTime? CheckDate, int? CheckNum, string EmpNum, Guid? CheckRowPointer)
		{
			var tv_tmp_tbl9LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByColumnName: new Dictionary<string, IParameterizedCommand>()
				{
					{"description",collectionLoadRequestFactory.Clause("dbo.GetLabel('@prtrxp.suppl_earn')")},
					{"code",collectionLoadRequestFactory.Clause("NULL")},
					{"rate",collectionLoadRequestFactory.Clause("0")},
					{"hrs",collectionLoadRequestFactory.Clause("0")},
					{"pay",collectionLoadRequestFactory.Clause("p1.suppl_earn")},
					{"ytd_pay",collectionLoadRequestFactory.Clause("(SELECT SUM(p2.suppl_earn) FROM   prtrxp AS p2 WHERE  LTRIM(p2.emp_num) = {3}        AND p2.check_date >= {0}        AND p2.check_date <= {1}        AND p2.check_num <= {2})", YearStart,CheckDate,CheckNum,EmpNum)},
					{"sort",collectionLoadRequestFactory.Clause("9")},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(" AS p1"),
				whereClause: collectionLoadRequestFactory.Clause("p1.RowPointer = {0}",CheckRowPointer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl9LoadRequest);
		}
		
		public void Tv_Tmp_Tbl9Insert(ICollectionLoadResponse tv_tmp_tbl9LoadResponse)
		{
			var tv_tmp_tbl9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl9LoadResponse.Items);
			
			this.appDB.Insert(tv_tmp_tbl9InsertRequest);
		}
		
		public IRecordStream Prtrxp1Select(DateTime? CheckDate, string EmpNum, DateTime? YearStart, int? CheckNum, Guid? CheckRowPointer, LoadType loadType, CachePageSize pageSize)
		{
			var CurprtrxpLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"de_code##1","de_code##1"},
					{"de_code##2","de_code##2"},
					{"de_code##3","de_code##3"},
					{"de_code##4","de_code##4"},
					{"de_code##5","de_code##5"},
					{"de_code##6","de_code##6"},
					{"de_code##7","de_code##7"},
					{"de_code##8","de_code##8"},
					{"de_code##9","de_code##9"},
					{"de_code##10","de_code##10"},
					{"de_code##11","de_code##11"},
					{"de_code##12","de_code##12"},
					{"de_code##13","de_code##13"},
					{"de_code##14","de_code##14"},
					{"de_code##15","de_code##15"},
					{"de_code##16","de_code##16"},
					{"de_code##17","de_code##17"},
					{"de_code##18","de_code##18"},
					{"de_amt##1","de_amt##1"},
					{"de_amt##2","de_amt##2"},
					{"de_amt##3","de_amt##3"},
					{"de_amt##4","de_amt##4"},
					{"de_amt##5","de_amt##5"},
					{"de_amt##6","de_amt##6"},
					{"de_amt##7","de_amt##7"},
					{"de_amt##8","de_amt##8"},
					{"de_amt##9","de_amt##9"},
					{"de_amt##10","de_amt##10"},
					{"de_amt##11","de_amt##11"},
					{"de_amt##12","de_amt##12"},
					{"de_amt##13","de_amt##13"},
					{"de_amt##14","de_amt##14"},
					{"de_amt##15","de_amt##15"},
					{"de_amt##16","de_amt##16"},
					{"de_amt##17","de_amt##17"},
					{"de_amt##18","de_amt##18"},
					{"RowPointer","RowPointer"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prtrxp",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("LTRIM(prtrxp.emp_num) = {3} AND prtrxp.check_date >= {0} AND prtrxp.check_date <= {1} AND prtrxp.check_num <= {2}",YearStart,CheckDate,CheckNum,EmpNum),
				orderByClause: collectionLoadRequestFactory.Clause("RowPointer"));

			Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
			dicSortOrder.Add("RowPointer", SortOrderDirection.Ascending);

			Dictionary<string, object> dicDefaultValue = new Dictionary<string, object>();
			dicDefaultValue.Add("RowPointer", new Guid("00000000-0000-0000-0000-000000000000"));
			ISortOrder prtrxpSortOrder = sortOrderFactory.Create(dicSortOrder, dicDefaultValue);
			return recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
													collectionLoadRequestFactory, CurprtrxpLoadRequestForCursor, prtrxpSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, Convert.ToInt32(pageSize), loadType, false);
		}
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) PrdecdLoad(string PrtrxpDeCode__1,
			decimal? PrtrxpDeAmt__1,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecdLoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__1)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__1)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__1),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecdLoadResponse = this.appDB.Load(prdecdLoadRequest);
			if(prdecdLoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecdLoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd1Load(string PrtrxpDeCode__2,
			decimal? PrtrxpDeAmt__2,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__2)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__2)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__2),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd1LoadResponse = this.appDB.Load(prdecd1LoadRequest);
			if(prdecd1LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd1LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd2Load(string PrtrxpDeCode__3,
			decimal? PrtrxpDeAmt__3,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__3)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__3)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__3),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd2LoadResponse = this.appDB.Load(prdecd2LoadRequest);
			if(prdecd2LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd2LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd3Load(string PrtrxpDeCode__4,
			decimal? PrtrxpDeAmt__4,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__4)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__4)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__4),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd3LoadResponse = this.appDB.Load(prdecd3LoadRequest);
			if(prdecd3LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd3LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd4Load(string PrtrxpDeCode__5,
			decimal? PrtrxpDeAmt__5,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__5)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__5)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__5),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd4LoadResponse = this.appDB.Load(prdecd4LoadRequest);
			if(prdecd4LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd4LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd5Load(string PrtrxpDeCode__6,
			decimal? PrtrxpDeAmt__6,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__6)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__6)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__6),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd5LoadResponse = this.appDB.Load(prdecd5LoadRequest);
			if(prdecd5LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd5LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd6Load(string PrtrxpDeCode__7,
			decimal? PrtrxpDeAmt__7,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__7)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__7)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__7),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd6LoadResponse = this.appDB.Load(prdecd6LoadRequest);
			if(prdecd6LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd6LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd7Load(string PrtrxpDeCode__8,
			decimal? PrtrxpDeAmt__8,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd7LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__8)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__8)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__8),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd7LoadResponse = this.appDB.Load(prdecd7LoadRequest);
			if(prdecd7LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd7LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd8Load(string PrtrxpDeCode__9,
			decimal? PrtrxpDeAmt__9,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd8LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__9)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__9)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__9),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd8LoadResponse = this.appDB.Load(prdecd8LoadRequest);
			if(prdecd8LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd8LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd9Load(string PrtrxpDeCode__10,
			decimal? PrtrxpDeAmt__10,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd9LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__10)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__10)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__10),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd9LoadResponse = this.appDB.Load(prdecd9LoadRequest);
			if(prdecd9LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd9LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd10Load(string PrtrxpDeCode__11,
			decimal? PrtrxpDeAmt__11,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd10LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__11)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__11)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__11),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd10LoadResponse = this.appDB.Load(prdecd10LoadRequest);
			if(prdecd10LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd10LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd11Load(string PrtrxpDeCode__12,
			decimal? PrtrxpDeAmt__12,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__12)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__12)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__12),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd11LoadResponse = this.appDB.Load(prdecd11LoadRequest);
			if(prdecd11LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd11LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd12Load(string PrtrxpDeCode__13,
			decimal? PrtrxpDeAmt__13,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd12LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__13)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__13)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__13),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd12LoadResponse = this.appDB.Load(prdecd12LoadRequest);
			if(prdecd12LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd12LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd13Load(string PrtrxpDeCode__14,
			decimal? PrtrxpDeAmt__14,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd13LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__14)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__14)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__14),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd13LoadResponse = this.appDB.Load(prdecd13LoadRequest);
			if(prdecd13LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd13LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd14Load(string PrtrxpDeCode__15,
			decimal? PrtrxpDeAmt__15,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd14LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__15)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__15)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__15),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd14LoadResponse = this.appDB.Load(prdecd14LoadRequest);
			if(prdecd14LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd14LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd15Load(string PrtrxpDeCode__16,
			decimal? PrtrxpDeAmt__16,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd15LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__16)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__16)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__16),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd15LoadResponse = this.appDB.Load(prdecd15LoadRequest);
			if(prdecd15LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd15LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd16Load(string PrtrxpDeCode__17,
			decimal? PrtrxpDeAmt__17,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd16LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__17)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__17)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__17),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd16LoadResponse = this.appDB.Load(prdecd16LoadRequest);
			if(prdecd16LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd16LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public (string TmpDeCode, string TmpDescription, string TmpType, decimal? TmpDeAmt, int? rowCount) Prdecd17Load(string PrtrxpDeCode__18,
			decimal? PrtrxpDeAmt__18,
			string TmpDescription,
			string TmpDeCode,
			decimal? TmpDeAmt,
			string TmpType)
		{
			DeCodeType _TmpDeCode = DBNull.Value;
			DescriptionType _TmpDescription = DBNull.Value;
			DeTypeType _TmpType = DBNull.Value;
			PrAmountType _TmpDeAmt = DBNull.Value;
			
			var prdecd17LoadRequest = collectionLoadRequestFactory.SQLLoad(columnParametizedByVariableToAssign: new Dictionary<IUDDTType, IParameterizedCommand>()
				{
					{_TmpDeCode,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeCode__18)},
					{_TmpDescription,collectionLoadRequestFactory.Clause("description")},
					{_TmpType,collectionLoadRequestFactory.Clause("type")},
					{_TmpDeAmt,collectionLoadRequestFactory.Clause("{0}", PrtrxpDeAmt__18)},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"prdecd",
				fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
				whereClause: collectionLoadRequestFactory.Clause("code = {0} AND (type = 'E' OR type = 'P' OR type = 'M' OR type = 'T')",PrtrxpDeCode__18),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var prdecd17LoadResponse = this.appDB.Load(prdecd17LoadRequest);
			if(prdecd17LoadResponse.Items.Count > 0)
			{
				TmpDeCode = _TmpDeCode;
				TmpDescription = _TmpDescription;
				TmpType = _TmpType;
				TmpDeAmt = _TmpDeAmt;
			}
			
			int rowCount = prdecd17LoadResponse.Items.Count;
			return (TmpDeCode, TmpDescription, TmpType, TmpDeAmt, rowCount);
		}
		
		public bool Tv_Tmp_Tbl10ForExists(string TmpDeCode)
		{
			return existsChecker.Exists(tableName: "#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("code = {0}",TmpDeCode));
		}
		
		public ICollectionLoadResponse Nontable1Select(string TmpDescription, string TmpDeCode, Guid? CheckRowPointer, Guid? PrtrxpRowPointer, decimal? TmpDeAmt)
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "description", TmpDescription },
					{ "code", TmpDeCode },
					{ "rate", null },
					{ "hrs", null },
					{ "pay", (sQLUtil.SQLEqual(CheckRowPointer, PrtrxpRowPointer) == true ? TmpDeAmt : 0) },
					{ "ytd_pay", TmpDeAmt },
					{ "sort", 99 },
			});
			
			return this.appDB.Load(nonTable1LoadRequest);
		}
		public void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse)
		{
			var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tmp_tbl",
				items: nonTable1LoadResponse.Items);
			
			this.appDB.Insert(nonTable1InsertRequest);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl11Select(string TmpDeCode)
		{
			var tv_tmp_tbl11LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"pay","#tv_tmp_tbl.pay"},
					{"ytd_pay","#tv_tmp_tbl.ytd_pay"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("code = {0}",TmpDeCode),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(tv_tmp_tbl11LoadRequest);
		}
		
		public void Tv_Tmp_Tbl11Update(Guid? CheckRowPointer, Guid? PrtrxpRowPointer, decimal? TmpDeAmt, ICollectionLoadResponse tv_tmp_tbl11LoadResponse)
		{
			foreach(var tv_tmp_tbl11Item in tv_tmp_tbl11LoadResponse.Items){
				tv_tmp_tbl11Item.SetValue<decimal?>("pay", (sQLUtil.SQLEqual(CheckRowPointer, PrtrxpRowPointer) == true ? TmpDeAmt : tv_tmp_tbl11Item.GetDeletedValue<decimal?>("pay")));
				tv_tmp_tbl11Item.SetValue<decimal?>("ytd_pay", tv_tmp_tbl11Item.GetDeletedValue<decimal?>("ytd_pay") + TmpDeAmt);
			};
			
			var tv_tmp_tbl11RequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "#tv_tmp_tbl",
				items: tv_tmp_tbl11LoadResponse.Items);
			
			this.appDB.Update(tv_tmp_tbl11RequestUpdate);
		}
		
		public ICollectionLoadResponse Tv_Tmp_Tbl12Select()
		{
			var tv_tmp_tbl12LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"description","description"},
					{"rate","rate"},
					{"hrs","hrs"},
					{"pay","pay"},
					{"ytd_pay","ytd_pay"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName:"#tv_tmp_tbl",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("pay > 0 OR ytd_pay <> 0"),
				orderByClause: collectionLoadRequestFactory.Clause(" sort, description"));
			return this.appDB.Load(tv_tmp_tbl12LoadRequest);
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_PayCheckEarningsSp(
			string AltExtGenSp,
			DateTime? CheckDate,
			Guid? CheckRowPointer,
			string EmpNum)
		{
			DateType _CheckDate = CheckDate;
			RowPointerType _CheckRowPointer = CheckRowPointer;
			EmpNumType _EmpNum = EmpNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckRowPointer", _CheckRowPointer, ParameterDirection.Input);
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
