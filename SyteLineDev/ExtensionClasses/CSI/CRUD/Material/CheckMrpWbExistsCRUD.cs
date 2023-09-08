//PROJECT NAME: Material
//CLASS NAME: CheckMrpWbExistsCRUD.cs

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

namespace CSI.Material
{
	public class CheckMrpWbExistsCRUD : ICheckMrpWbExistsCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public CheckMrpWbExistsCRUD(IApplicationDB appDB,
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckMrpWbExistsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CheckMrpWbExistsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CheckMrpWbExistsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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
			return existsChecker.Exists(tableName: "#tv_ALTGEN",
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

		public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
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

		public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
		{
			var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
				items: tv_ALTGEN2LoadResponse.Items);
			this.appDB.Delete(tv_ALTGEN2DeleteRequest);
		}

		public (int? MrpWbExists, int? rowCount) Mrp_WbLoad(string FromItem, string ToItem, int? MrpWbExists)
		{
			ListYesNoType _MrpWbExists = DBNull.Value;

			var mrp_wbLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_MrpWbExists,"1"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				maximumRows: 1,
				tableName: "mrp_wb",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("mrp_wb.ref_type = 'M' AND mrp_wb.item BETWEEN ISNULL({0}, mrp_wb.item) AND ISNULL({1}, mrp_wb.item)", FromItem, ToItem),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var mrp_wbLoadResponse = this.appDB.Load(mrp_wbLoadRequest);
			if (mrp_wbLoadResponse.Items.Count > 0)
			{
				MrpWbExists = _MrpWbExists;
			}

			int rowCount = mrp_wbLoadResponse.Items.Count;
			return (MrpWbExists, rowCount);
		}

		public (int? ReturnCode,
			int? MrpWbExists,
			string Infobar)
		AltExtGen_CheckMrpWbExistsSp(
			string AltExtGenSp,
			string FromItem,
			string ToItem,
			int? MrpWbExists,
			string Infobar)
		{
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			ListYesNoType _MrpWbExists = MrpWbExists;
			InfobarType _Infobar = Infobar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpWbExists", _MrpWbExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				MrpWbExists = _MrpWbExists;
				Infobar = _Infobar;

				return (Severity, MrpWbExists, Infobar);
			}
		}

	}
}
