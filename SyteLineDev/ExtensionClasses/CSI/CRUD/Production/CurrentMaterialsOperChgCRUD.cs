//PROJECT NAME: Production
//CLASS NAME: CurrentMaterialsOperChgCRUD.cs

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

namespace CSI.Production
{
	public class CurrentMaterialsOperChgCRUD : ICurrentMaterialsOperChgCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;

		public CurrentMaterialsOperChgCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CurrentMaterialsOperChgSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CurrentMaterialsOperChgSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));

			var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

			foreach (var optional_module1Item in optional_module1LoadResponse.Items)
			{
				optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CurrentMaterialsOperChgSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
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

		public (int? MOShared, decimal? MOSecondsPerCycle, decimal? MOFormulaMatlWeight, string MOFormulaMatlWeightUnits, int? rowCount) LoadJobroute(string Job,
			int? Suffix,
			int? OperNum,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits)
		{
			ListYesNoType _MOShared = DBNull.Value;
			MO_CycleTimeType _MOSecondsPerCycle = DBNull.Value;
			WeightType _MOFormulaMatlWeight = DBNull.Value;
			WeightUnitsType _MOFormulaMatlWeightUnits = DBNull.Value;

			var jobrouteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
				{
					{_MOShared,"mo_shared"},
					{_MOSecondsPerCycle,"mo_seconds_per_cycle"},
					{_MOFormulaMatlWeight,"mo_formula_matl_weight"},
					{_MOFormulaMatlWeightUnits,"mo_formula_matl_weight_units"},
				},
				loadForChange: false,
				lockingType: LockingType.None,
				tableName: "jobroute",
				fromClause: collectionLoadRequestFactory.Clause(""),
				whereClause: collectionLoadRequestFactory.Clause("job = {2} AND suffix = {1} AND oper_num = {0}", OperNum, Suffix, Job),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			var jobrouteLoadResponse = this.appDB.Load(jobrouteLoadRequest);
			if (jobrouteLoadResponse.Items.Count > 0)
			{
				MOShared = _MOShared;
				MOSecondsPerCycle = _MOSecondsPerCycle;
				MOFormulaMatlWeight = _MOFormulaMatlWeight;
				MOFormulaMatlWeightUnits = _MOFormulaMatlWeightUnits;
			}

			int rowCount = jobrouteLoadResponse.Items.Count;
			return (MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, rowCount);
		}

		public (int? ReturnCode,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits,
			string InfoBar)
		AltExtGen_CurrentMaterialsOperChgSp(
			string AltExtGenSp,
			string Job,
			int? Suffix,
			int? OperNum,
			int? MOShared,
			decimal? MOSecondsPerCycle,
			decimal? MOFormulaMatlWeight,
			string MOFormulaMatlWeightUnits,
			string InfoBar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ListYesNoType _MOShared = MOShared;
			MO_CycleTimeType _MOSecondsPerCycle = MOSecondsPerCycle;
			WeightType _MOFormulaMatlWeight = MOFormulaMatlWeight;
			WeightUnitsType _MOFormulaMatlWeightUnits = MOFormulaMatlWeightUnits;
			InfobarType _InfoBar = InfoBar;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;

				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MOShared", _MOShared, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOSecondsPerCycle", _MOSecondsPerCycle, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOFormulaMatlWeight", _MOFormulaMatlWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MOFormulaMatlWeightUnits", _MOFormulaMatlWeightUnits, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);

				MOShared = _MOShared;
				MOSecondsPerCycle = _MOSecondsPerCycle;
				MOFormulaMatlWeight = _MOFormulaMatlWeight;
				MOFormulaMatlWeightUnits = _MOFormulaMatlWeightUnits;
				InfoBar = _InfoBar;

				return (Severity, MOShared, MOSecondsPerCycle, MOFormulaMatlWeight, MOFormulaMatlWeightUnits, InfoBar);
			}
		}

	}
}
