﻿//PROJECT NAME: Finance
//CLASS NAME: UpdateCurrentPeriodDepreciationToZeroCRUD.cs

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
	public class UpdateCurrentPeriodDepreciationToZeroCRUD : IUpdateCurrentPeriodDepreciationToZeroCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public UpdateCurrentPeriodDepreciationToZeroCRUD(IApplicationDB appDB,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
		}

		public bool CheckOptional_ModuleForExists()
		{
			return existsChecker.Exists(tableName: "optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('UpdateCurrentPeriodDepreciationToZeroSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
		}

		public ICollectionLoadResponse SelectOptional_Module()
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('UpdateCurrentPeriodDepreciationToZeroSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("UpdateCurrentPeriodDepreciationToZeroSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
			};

			return optional_module1LoadResponse;
		}

		public void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse)
		{
			var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
				items: optional_module1LoadResponse.Items);

			this.appDB.Insert(optional_module1InsertRequest);
		}

		public bool CheckTv_ALTGENForExists()
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

		public ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName)
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

		public ICollectionLoadResponse SelectFadepr(string pFaNum)
		{
			var fadeprLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"curr_depr","fadepr.curr_depr"},
				},
				loadForChange: true,
				lockingType: LockingType.UPDLock,
				tableName: "fadepr",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("fa_num = {0}", pFaNum),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(fadeprLoadRequest);
		}

		public void UpdateFadepr(ICollectionLoadResponse fadeprLoadResponse)
		{
			foreach (var fadeprItem in fadeprLoadResponse.Items)
			{
				fadeprItem.SetValue<int?>("curr_depr", 0);
			};

			var fadeprRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "fadepr",
				items: fadeprLoadResponse.Items);

			this.appDB.Update(fadeprRequestUpdate);
		}

		public (int? ReturnCode,
			int? pNeedToUpdateCurPerDepr)
		AltExtGen_UpdateCurrentPeriodDepreciationToZeroSp(
			string AltExtGenSp,
			string pFaNum,
			int? pNeedToUpdateCurPerDepr)
		{
			FaNumType _pFaNum = pFaNum;
			ListYesNoType _pNeedToUpdateCurPerDepr = pNeedToUpdateCurPerDepr;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "pFaNum", _pFaNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pNeedToUpdateCurPerDepr", _pNeedToUpdateCurPerDepr, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				pNeedToUpdateCurPerDepr = _pNeedToUpdateCurPerDepr;

				return (Severity, pNeedToUpdateCurPerDepr);
			}
		}

	}
}