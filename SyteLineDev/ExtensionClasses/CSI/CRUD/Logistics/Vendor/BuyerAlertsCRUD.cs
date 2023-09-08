//PROJECT NAME: Logistics
//CLASS NAME: BuyerAlertsCRUD.cs

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

namespace CSI.Logistics.Vendor
{
	public class BuyerAlertsCRUD : IBuyerAlertsCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public BuyerAlertsCRUD(IApplicationDB appDB,
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('BuyerAlertsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('BuyerAlertsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("BuyerAlertsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

		public (int? OverDuePOLines, int? rowCount) LoadPOLinesCount(DateTime? Today, string Buyer, int? OverDuePOLines)
		{
			NumberOfLinesType _OverDuePOLines = DBNull.Value;

			var poitemASpoiLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_OverDuePOLines,"COUNT(*)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "poitem AS poi",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN po AS po ON po.po_num = poi.po_num
					AND po.type = 'R'
					AND po.stat = 'O'"),
				whereClause: collectionLoadRequestFactory.Clause("poi.stat = 'O' AND poi.qty_ordered > poi.qty_received AND DATEDIFF(dd, poi.due_date, {0}) > 0 AND (po.buyer = {1} OR poi.item IN (SELECT i.item FROM item AS i WHERE i.buyer = {1}))", Today, Buyer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitemASpoiLoadResponse = this.appDB.Load(poitemASpoiLoadRequest);
			if (poitemASpoiLoadResponse.Items.Count > 0)
			{
				OverDuePOLines = _OverDuePOLines;
			}

			int rowCount = poitemASpoiLoadResponse.Items.Count;
			return (OverDuePOLines, rowCount);
		}

		public (int? OverDuePOReleases, int? rowCount) LoadPOReleasesCount(DateTime? Today, string Buyer, int? OverDuePOReleases)
		{
			NumberOfLinesType _OverDuePOReleases = DBNull.Value;

			var poitemASpoi1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_OverDuePOReleases,"COUNT(*)"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "poitem AS poi",
				fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN po AS po ON po.po_num = poi.po_num
					AND po.type = 'B'
					AND po.stat = 'O'"),
				whereClause: collectionLoadRequestFactory.Clause("poi.stat = 'O' AND poi.qty_ordered > poi.qty_received AND DATEDIFF(dd, poi.due_date, {0}) > 0 AND (po.buyer = {1} OR poi.item IN (SELECT i.item FROM item AS i WHERE i.buyer = {1}))", Today, Buyer),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var poitemASpoi1LoadResponse = this.appDB.Load(poitemASpoi1LoadRequest);
			if (poitemASpoi1LoadResponse.Items.Count > 0)
			{
				OverDuePOReleases = _OverDuePOReleases;
			}

			int rowCount = poitemASpoi1LoadResponse.Items.Count;
			return (OverDuePOReleases, rowCount);
		}

		public (int? ReturnCode,
			int? OverDuePOLines,
			int? OverDuePOReleases,
			int? NumberOfUserTasks,
			int? NumberOfEventMessages)
		AltExtGen_BuyerAlertsSp(
			string AltExtGenSp,
			int? OverDuePOLines,
			int? OverDuePOReleases,
			int? NumberOfUserTasks,
			int? NumberOfEventMessages)
		{
			NumberOfLinesType _OverDuePOLines = OverDuePOLines;
			NumberOfLinesType _OverDuePOReleases = OverDuePOReleases;
			NumberOfLinesType _NumberOfUserTasks = NumberOfUserTasks;
			NumberOfLinesType _NumberOfEventMessages = NumberOfEventMessages;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "OverDuePOLines", _OverDuePOLines, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OverDuePOReleases", _OverDuePOReleases, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfUserTasks", _NumberOfUserTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfEventMessages", _NumberOfEventMessages, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				OverDuePOLines = _OverDuePOLines;
				OverDuePOReleases = _OverDuePOReleases;
				NumberOfUserTasks = _NumberOfUserTasks;
				NumberOfEventMessages = _NumberOfEventMessages;

				return (Severity, OverDuePOLines, OverDuePOReleases, NumberOfUserTasks, NumberOfEventMessages);
			}
		}

	}
}
