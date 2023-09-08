//PROJECT NAME: Logistics
//CLASS NAME: GetVendFixedRate.cs

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
	public class GetVendFixedRate : IGetVendFixedRate
	{
		readonly IApplicationDB appDB;

		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public GetVendFixedRate(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public (
			int? ReturnCode,
			int? FixedRate,
			string Infobar)
		GetVendFixedRateSp(
			string VendNum,
			string CurrCode,
			int? FixedRate,
			string Infobar)
		{
			ListYesNoType _FixedRate = FixedRate;
			StringType _ALTGEN_SpName = DBNull.Value;
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? Severity = null;

			if (existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetVendFixedRateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN ");

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
					whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('GetVendFixedRateSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
					orderByClause: collectionLoadRequestFactory.Clause(""));
				var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
				#endregion  LoadToRecord

				#region CRUD InsertByRecords
				foreach (var optional_module1Item in optional_module1LoadResponse.Items)
				{
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("GetVendFixedRateSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};

				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
					items: optional_module1LoadResponse.Items);

				this.appDB.Insert(optional_module1InsertRequest);
				#endregion InsertByRecords

				while (existsChecker.Exists(tableName: "#tv_ALTGEN",
					fromClause: collectionLoadRequestFactory.Clause(""),
					whereClause: collectionLoadRequestFactory.Clause("")))
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

					var ALTGEN = AltExtGen_GetVendFixedRateSp(_ALTGEN_SpName,
						VendNum,
						CurrCode,
						FixedRate,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						FixedRate = _FixedRate;
						return (ALTGEN_Severity, FixedRate, Infobar);
					}

					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					#region CRUD LoadToRecord
					var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
						{
							{"[SpName]","[SpName]"},
						},
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        tableName: "#tv_ALTGEN",
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
				}
			}

			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_GetVendFixedRateSp") != null)
			{
				var EXTGEN = AltExtGen_GetVendFixedRateSp("dbo.EXTGEN_GetVendFixedRateSp",
					VendNum,
					CurrCode,
					FixedRate,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.FixedRate, EXTGEN.Infobar);
				}
			}

			Severity = 0;
			Infobar = null;

			#region CRUD LoadToVariable
			var vendor_currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_FixedRate,"vendor_currency.fixed_rate"},
				},
				loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "vendor_currency",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("vendor_currency.vend_num = {1} AND vendor_currency.curr_code = {0}", CurrCode, VendNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var vendor_currencyLoadResponse = this.appDB.Load(vendor_currencyLoadRequest);
			if (vendor_currencyLoadResponse.Items.Count > 0)
			{
				FixedRate = _FixedRate;
			}
			#endregion  LoadToVariable

			return (Severity, FixedRate, Infobar);
		}

		public (int? ReturnCode,
			int? FixedRate,
			string Infobar)
		AltExtGen_GetVendFixedRateSp(
			string AltExtGenSp,
			string VendNum,
			string CurrCode,
			int? FixedRate,
			string Infobar)
		{
			VendNumType _VendNum = VendNum;
			CurrCodeType _CurrCode = CurrCode;
			ListYesNoType _FixedRate = FixedRate;
			Infobar _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedRate", _FixedRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				FixedRate = _FixedRate;
				Infobar = _Infobar;

				return (Severity, FixedRate, Infobar);
			}
		}
	}
}
