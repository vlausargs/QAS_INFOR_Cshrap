//PROJECT NAME: Production
//CLASS NAME: ProjCostRollupJobTree.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjCostRollupJobTree : IProjCostRollupJobTree
	{
		readonly IApplicationDB appDB;
		
		public ProjCostRollupJobTree(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? AccumMatlCost,
			decimal? AccumLbrCost,
			decimal? AccumFovhdCost,
			decimal? AccumVovhdCost,
			decimal? AccumOutCost,
			string Infobar) ProjCostRollupJobTreeSp(
			string PJobType,
			string PJob,
			int? PSuffix,
			string PItem,
			decimal? PQty,
			int? ProjtaskTaskNum,
			string ProjmatlCostCode,
			int? ProjmatlSeq,
			int? CurrencyPlaces,
			int? MrpParmScrapFlag,
			int? Level,
			string ProjType,
			decimal? AccumMatlCost,
			decimal? AccumLbrCost,
			decimal? AccumFovhdCost,
			decimal? AccumVovhdCost,
			decimal? AccumOutCost,
			string Infobar)
		{
			JobTypeType _PJobType = PJobType;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			ItemType _PItem = PItem;
			QtyPerType _PQty = PQty;
			TaskNumType _ProjtaskTaskNum = ProjtaskTaskNum;
			CostCodeType _ProjmatlCostCode = ProjmatlCostCode;
			ProjmatlSeqType _ProjmatlSeq = ProjmatlSeq;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			ListYesNoType _MrpParmScrapFlag = MrpParmScrapFlag;
			IntType _Level = Level;
			ProjTypeType _ProjType = ProjType;
			CostPrcType _AccumMatlCost = AccumMatlCost;
			CostPrcType _AccumLbrCost = AccumLbrCost;
			CostPrcType _AccumFovhdCost = AccumFovhdCost;
			CostPrcType _AccumVovhdCost = AccumVovhdCost;
			CostPrcType _AccumOutCost = AccumOutCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjCostRollupJobTreeSp";
				
				appDB.AddCommandParameter(cmd, "PJobType", _PJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQty", _PQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjtaskTaskNum", _ProjtaskTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlCostCode", _ProjmatlCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjmatlSeq", _ProjmatlSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmScrapFlag", _MrpParmScrapFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjType", _ProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccumMatlCost", _AccumMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumLbrCost", _AccumLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumFovhdCost", _AccumFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumVovhdCost", _AccumVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccumOutCost", _AccumOutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AccumMatlCost = _AccumMatlCost;
				AccumLbrCost = _AccumLbrCost;
				AccumFovhdCost = _AccumFovhdCost;
				AccumVovhdCost = _AccumVovhdCost;
				AccumOutCost = _AccumOutCost;
				Infobar = _Infobar;
				
				return (Severity, AccumMatlCost, AccumLbrCost, AccumFovhdCost, AccumVovhdCost, AccumOutCost, Infobar);
			}
		}
	}
}
