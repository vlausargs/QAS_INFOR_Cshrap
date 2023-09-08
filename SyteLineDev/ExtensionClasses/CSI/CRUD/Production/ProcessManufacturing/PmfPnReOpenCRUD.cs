//PROJECT NAME: Production
//CLASS NAME: PmfPnReOpenCRUD.cs

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

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnReOpenCRUD : IPmfPnReOpenCRUD
	{
		readonly IApplicationDB appDB;
		readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
		readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
		readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
		readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
		readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
		readonly IExistsChecker existsChecker;
		readonly IStringUtil stringUtil;
		readonly IConvertToUtil convertToUtil;
		
		public PmfPnReOpenCRUD(IApplicationDB appDB,
			ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
			ICollectionInsertRequestFactory collectionInsertRequestFactory,
			ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
			ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
			ICollectionLoadRequestFactory collectionLoadRequestFactory,
			IExistsChecker existsChecker,
			IStringUtil stringUtil,
            IConvertToUtil convertToUtil)
		{
			this.appDB = appDB;
			this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
			this.collectionInsertRequestFactory = collectionInsertRequestFactory;
			this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
			this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
			this.collectionLoadRequestFactory = collectionLoadRequestFactory;
			this.existsChecker = existsChecker;
			this.stringUtil = stringUtil;
			this.convertToUtil = convertToUtil;
		}
		
		public bool Optional_ModuleForExists()
		{
			return existsChecker.Exists(tableName:"optional_module",
				fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfPnReOpenSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
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
				whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('PmfPnReOpenSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(optional_module1LoadRequest);
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
		
		public ICollectionLoadResponse Pmf_Pn_BatchSelect(Guid? PnRp)
		{
			var pmf_pn_batchLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"Status","pn.Status"},
				}, 
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"pmf_pn_batch",
				fromClause: collectionLoadRequestFactory.Clause(" AS pn"),
				whereClause: collectionLoadRequestFactory.Clause("pn.RowPointer = {0}",PnRp),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(pmf_pn_batchLoadRequest);
		}
		
		public void Pmf_Pn_BatchUpdate(ICollectionLoadResponse pmf_pn_batchLoadResponse)
		{
			foreach(var pmf_pn_batchItem in pmf_pn_batchLoadResponse.Items){
				pmf_pn_batchItem.SetValue<int?>("Status", 1);
			};
			
			var pmf_pn_batchRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "pmf_pn_batch",
				items: pmf_pn_batchLoadResponse.Items);
			
			this.appDB.Update(pmf_pn_batchRequestUpdate);
		}
		
		public ICollectionLoadResponse JobSelect(Guid? PnRp)
		{
			var jobLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"stat","j.stat"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"job",
				fromClause: collectionLoadRequestFactory.Clause(" AS j"),
				whereClause: collectionLoadRequestFactory.Clause("j.pmf_pn_batch_RowPointer = {0}",PnRp),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(jobLoadRequest);
		}
		
		public void JobUpdate(ICollectionLoadResponse jobLoadResponse)
		{
			foreach(var jobItem in jobLoadResponse.Items){
				jobItem.SetValue<string>("stat", "R");
			};
			
			var jobRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "job",
				items: jobLoadResponse.Items);
			
			this.appDB.Update(jobRequestUpdate);
		}
		
		public ICollectionLoadResponse Pmf_FormulaSelect(Guid? PnRp)
		{
			var pmf_formulaLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
				{
					{"status","fm.status"},
				},
                loadForChange: true, 
                lockingType: LockingType.UPDLock,
                tableName:"pmf_formula",
				fromClause: collectionLoadRequestFactory.Clause(" AS fm INNER JOIN job AS j ON fm.RowPointer = j.pmf_pn_batch_RowPointer"),
				whereClause: collectionLoadRequestFactory.Clause("j.pmf_pn_batch_RowPointer = {0} AND j.pmf_formula_RowPointer IS NOT NULL",PnRp),
				orderByClause: collectionLoadRequestFactory.Clause(""));
			return this.appDB.Load(pmf_formulaLoadRequest);
		}
		
		public void Pmf_FormulaUpdate(ICollectionLoadResponse pmf_formulaLoadResponse)
		{
			foreach(var pmf_formulaItem in pmf_formulaLoadResponse.Items){
				pmf_formulaItem.SetValue<int?>("status", 1);
			};
			
			var pmf_formulaRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "pmf_formula",
				items: pmf_formulaLoadResponse.Items);
			
			this.appDB.Update(pmf_formulaRequestUpdate);
		}		
		
		public (int? ReturnCode,
			string InfoBar)
		AltExtGen_PmfPnReOpenSp(
			string AltExtGenSp,
			string InfoBar = null,
			Guid? PnRp = null)
		{
			InfobarType _InfoBar = InfoBar;
			RowPointerType _PnRp = PnRp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = AltExtGenSp;
				
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PnRp", _PnRp, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
		
	}
}
