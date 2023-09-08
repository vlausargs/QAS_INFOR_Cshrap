//PROJECT NAME: Codes
//CLASS NAME: CLM_LoadDimAttributeOverrideCRUD.cs

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

namespace CSI.Codes
{
	public class CLM_LoadDimAttributeOverrideCRUD : ICLM_LoadDimAttributeOverrideCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IConvertToUtil convertToUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;

		public CLM_LoadDimAttributeOverrideCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IConvertToUtil convertToUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.convertToUtil = convertToUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
		}

		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_LoadDimAttributeOverrideSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_LoadDimAttributeOverrideSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_LoadDimAttributeOverrideSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

		public ICollectionLoadResponse SelectChart(string Acct, string SubscriberObjectName, Guid? SubscriberObjectRowPointer)
		{
			var chartLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"attribute","dimatt.attribute"},
					{"description","CAST (NULL AS NVARCHAR)"},
					{"value","dimattovr.value"},
					{"readonly","dimatt.read_only"},
					{"hidden","dimatt.hidden"},
					{"masking","dimatt.masking"},
					{"required","dimatt.required"},
					{"objectname","doatt.object_name"},
					{"DomainIDOName","doatt.DomainIDOName"},
					{"DomainProperty","doatt.DomainProperty"},
					{"DomainListProperty","doatt.DomainListProperty"},
					{"InlineList","doatt.InlineList"},
					{"u0","doatt.description"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "chart",
				fromClause: collectionLoadRequestFactory.Clause(@" left outer join dim_attribute as dimatt on chart.ledger_dim_name = dimatt.dim_name
					and dimatt.object_name = 'ledger' left outer join dim_object_attribute as doatt on doatt.object_name = dimatt.object_name
					and doatt.attribute = dimatt.attribute left outer join dim_attribute_override as dimattovr on dimatt.attribute = dimattovr.attribute
					and dimattovr.subscriber_object_name = {1}
					and dimattovr.subscriber_object_rowpointer = {0}", SubscriberObjectRowPointer, SubscriberObjectName),
				whereClause: collectionLoadRequestFactory.Clause("chart.acct = {0}", Acct),
				orderByClause: collectionLoadRequestFactory.Clause(" dimatt.required DESC, dimatt.sequence"));

			var chartLoadResponse = this.appDB.Load(chartLoadRequest);

			foreach (var chartItem in chartLoadResponse.Items)
			{
				chartItem.SetValue<string>("attribute", chartItem.GetValue<string>("attribute"));
				chartItem.SetValue<string>("description", (chartItem.GetValue<string>("u0") == null || sQLUtil.SQLEqual(stringUtil.Len(chartItem.GetValue<string>("u0")), 0) == true ? convertToUtil.ToString(chartItem.GetValue<string>("attribute")) : convertToUtil.ToString(chartItem.GetValue<string>("u0"))));
				chartItem.SetValue<string>("value", chartItem.GetValue<string>("value"));
				chartItem.SetValue<int?>("readonly", chartItem.GetValue<int?>("readonly"));
				chartItem.SetValue<int?>("hidden", chartItem.GetValue<int?>("hidden"));
				chartItem.SetValue<string>("masking", chartItem.GetValue<string>("masking"));
				chartItem.SetValue<int?>("required", chartItem.GetValue<int?>("required"));
				chartItem.SetValue<string>("objectname", chartItem.GetValue<string>("objectname"));
				chartItem.SetValue<string>("DomainIDOName", chartItem.GetValue<string>("DomainIDOName"));
				chartItem.SetValue<string>("DomainProperty", chartItem.GetValue<string>("DomainProperty"));
				chartItem.SetValue<string>("DomainListProperty", chartItem.GetValue<string>("DomainListProperty"));
				chartItem.SetValue<string>("InlineList", chartItem.GetValue<string>("InlineList"));
			};

			return chartLoadResponse;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_LoadDimAttributeOverrideSp(
			string AltExtGenSp,
			string Acct = null,
			string SubscriberObjectName = null,
			Guid? SubscriberObjectRowPointer = null)
		{
			AcctType _Acct = Acct;
			DimensionObjectNameType _SubscriberObjectName = SubscriberObjectName;
			RowPointerType _SubscriberObjectRowPointer = SubscriberObjectRowPointer;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubscriberObjectName", _SubscriberObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubscriberObjectRowPointer", _SubscriberObjectRowPointer, ParameterDirection.Input);

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
