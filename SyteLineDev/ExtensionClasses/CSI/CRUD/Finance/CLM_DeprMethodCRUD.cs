//PROJECT NAME: Finance
//CLASS NAME: CLM_DeprMethodCRUD.cs

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

namespace CSI.Finance
{
	public class CLM_DeprMethodCRUD : ICLM_DeprMethodCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IGetCodeDesc iGetCodeDesc;
		readonly IStringUtil stringUtil;

		public CLM_DeprMethodCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IGetCodeDesc iGetCodeDesc,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.iGetCodeDesc = iGetCodeDesc;
			this.stringUtil = stringUtil;
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_DeprMethodSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

		public ICollectionLoadResponse SelectOptional_ModuleForInsert()
		{
			var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"SpName","CAST (NULL AS NVARCHAR)"},
					{"u0","[om].[ModuleName]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_DeprMethodSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_DeprMethodSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};

			return optional_module1LoadResponse;
		}

		public void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);

			this.appDB.Insert(optional_module1InsertRequest);
		}

		public bool Tv_ALTGENForExists()
		{
			return existsChecker.Exists(tableName: "#tv_ALTGEN",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""));
		}

		public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName)
		{
			StringType _ALTGEN_SpName = DBNull.Value;

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

			int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
			return (ALTGEN_SpName, rowCount);
		}

		public ICollectionLoadResponse SelectTv_ALTGENForDelete(string ALTGEN_SpName)
		{
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
			return this.appDB.Load(tv_ALTGEN2LoadRequest);
		}

		public void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}

		public ICollectionLoadResponse SelectDeprmethod()
		{
			var DeprMethodLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"method","method"},
					{"meth_desc","meth_desc"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "fadeptab",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause(""),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(DeprMethodLoadRequest);
		}

		public ICollectionLoadResponse SelectMethodSL()
		{
			var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "SL"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"SL",
						null)},
			});

			return this.appDB.Load(nonTableLoadRequest);
		}

		public ICollectionLoadResponse SelectMethodSYD()
		{
			var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "SYD"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"SYD",
						null)},
			});

			return this.appDB.Load(nonTable1LoadRequest);
		}

		public ICollectionLoadResponse SelectMethodUSAGE()
		{
			var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "USAGE"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"USAGE",
						null)},
			});

			return this.appDB.Load(nonTable2LoadRequest);
		}

		public ICollectionLoadResponse SelectMethod125DB()
		{
			var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "125DB"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"125DB",
						null)},
			});

			return this.appDB.Load(nonTable3LoadRequest);
		}

		public ICollectionLoadResponse SelectMethod150DB()
		{
			var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "150DB"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"150DB",
						null)},
			});

			return this.appDB.Load(nonTable4LoadRequest);
		}

		public ICollectionLoadResponse SelectMethod175DB()
		{
			var nonTable5LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "175DB"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"175DB",
						null)},
			});

			return this.appDB.Load(nonTable5LoadRequest);
		}

		public ICollectionLoadResponse SelectMethod200DB()
		{
			var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
			{
					{ "method", "200DB"},
					{ "meth_desc", this.iGetCodeDesc.GetCodeDescFn(
						"DeprMethod",
						"200DB",
						null)},
			});

			return this.appDB.Load(nonTable6LoadRequest);
		}


		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_DeprMethodSp(
			string AltExtGenSp)
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

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
