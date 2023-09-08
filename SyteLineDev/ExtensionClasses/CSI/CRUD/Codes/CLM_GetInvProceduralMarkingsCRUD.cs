//PROJECT NAME: Codes
//CLASS NAME: CLM_GetInvProceduralMarkingsCRUD.cs

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
	public class CLM_GetInvProceduralMarkingsCRUD : ICLM_GetInvProceduralMarkingsCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public CLM_GetInvProceduralMarkingsCRUD(IApplicationDB appDB,
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GetInvProceduralMarkingsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_GetInvProceduralMarkingsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_GetInvProceduralMarkingsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

		public ICollectionLoadResponse SelectVat_Procedural_Marking_All(string SiteRef, string InvNum, int? InvSeq)
		{
			var vat_procedural_marking_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"selected","CAST (NULL AS INT)"},
					{"inv_num","CAST (NULL AS NVARCHAR)"},
					{"inv_seq","CAST (NULL AS INT)"},
					{"vat_procedural_marking_id","CAST (NULL AS NVARCHAR)"},
					{"site_ref","CAST (NULL AS NVARCHAR)"},
					{"u0","[invprocm_all].[inv_num]"},
					{"u1","[vatprocm_all].[vat_procedural_marking_id]"},
					{"u2","[vatprocm_all].[site_ref]"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "vat_procedural_marking_all",
				fromClause: collectionLoadRequestFactory.Clause(@"as [vatprocm_all] left outer join [dbo].[inv_procedural_marking_all] as [invprocm_all] on [vatprocm_all].[vat_procedural_marking_id] = [invprocm_all].[vat_procedural_marking_id]
					and [vatprocm_all].[site_ref] = [invprocm_all].[site_ref]
					and [vatprocm_all].[ref_type] in (N'T', N'C')
					and [invprocm_all].[inv_num] = {0}
					and [invprocm_all].[inv_seq] = {1}", InvNum, InvSeq),
				whereClause: collectionLoadRequestFactory.Clause("[vatprocm_all].[site_ref] = {0} AND [vatprocm_all].[ref_type] IN (N'T', N'C')", SiteRef),
				orderByClause: collectionLoadRequestFactory.Clause(" [vatprocm_all].[vat_procedural_marking_id]"));

			var vat_procedural_marking_allLoadResponse = this.appDB.Load(vat_procedural_marking_allLoadRequest);

			foreach (var vat_procedural_marking_allItem in vat_procedural_marking_allLoadResponse.Items)
			{
				vat_procedural_marking_allItem.SetValue<int?>("selected", (vat_procedural_marking_allItem.GetValue<string>("u0") != null ? 1 : 0));
				vat_procedural_marking_allItem.SetValue<string>("inv_num", InvNum);
				vat_procedural_marking_allItem.SetValue<int?>("inv_seq", InvSeq);
				vat_procedural_marking_allItem.SetValue<string>("vat_procedural_marking_id", vat_procedural_marking_allItem.GetValue<string>("u1"));
				vat_procedural_marking_allItem.SetValue<string>("site_ref", vat_procedural_marking_allItem.GetValue<string>("u2"));
			};

			return vat_procedural_marking_allLoadResponse;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		AltExtGen_CLM_GetInvProceduralMarkingsSp(
			string AltExtGenSp,
			string InvNum,
			int? InvSeq,
			string SiteRef)
		{
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			SiteType _SiteRef = SiteRef;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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
