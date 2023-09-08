//PROJECT NAME: Logistics
//CLASS NAME: SSSTraceStartWrapCRUD.cs

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

namespace CSI.Logistics.FieldService
{
	public class SSSTraceStartWrapCRUD : ISSSTraceStartWrapCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public SSSTraceStartWrapCRUD(IApplicationDB appDB,
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
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'SSSTraceStartWrapSp_' + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME(N'SSSTraceStartWrapSp_' + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.Concat("SSSTraceStartWrapSp_", optional_module1Item.GetValue<string>("u0")));
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

		public (int? ReturnCode,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar)
		AltExtGen_SSSTraceStartWrapSp(
			string AltExtGenSp,
			long? iMaxTraceSizeMB,
			int? oTraceID,
			string oServerName,
			string oTraceFile,
			string Infobar,
			string FilterDatabaseNameLike,
			string FilterHostNameLike,
			string FilterLoginNameLike,
			string FilterTextDataLike,
			string FilterObjectNameLike,
			int? FilterSPIDEQ)
		{
			LongType _iMaxTraceSizeMB = iMaxTraceSizeMB;
			IntType _oTraceID = oTraceID;
			StringType _oServerName = oServerName;
			StringType _oTraceFile = oTraceFile;
			InfobarType _Infobar = Infobar;
			StringType _FilterDatabaseNameLike = FilterDatabaseNameLike;
			StringType _FilterHostNameLike = FilterHostNameLike;
			StringType _FilterLoginNameLike = FilterLoginNameLike;
			StringType _FilterTextDataLike = FilterTextDataLike;
			StringType _FilterObjectNameLike = FilterObjectNameLike;
			IntType _FilterSPIDEQ = FilterSPIDEQ;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "iMaxTraceSizeMB", _iMaxTraceSizeMB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "oTraceID", _oTraceID, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oServerName", _oServerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "oTraceFile", _oTraceFile, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FilterDatabaseNameLike", _FilterDatabaseNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterHostNameLike", _FilterHostNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterLoginNameLike", _FilterLoginNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterTextDataLike", _FilterTextDataLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterObjectNameLike", _FilterObjectNameLike, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterSPIDEQ", _FilterSPIDEQ, ParameterDirection.Input);

				var Severity = appDB.ExecuteNonQuery(cmd);

				oTraceID = _oTraceID;
				oServerName = _oServerName;
				oTraceFile = _oTraceFile;
				Infobar = _Infobar;

				return (Severity, oTraceID, oServerName, oTraceFile, Infobar);
			}
		}

	}
}
