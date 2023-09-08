//PROJECT NAME: Data
//CLASS NAME: FloorStkReplenCel06LI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FloorStkReplenCel06LI : IFloorStkReplenCel06LI
	{
		readonly IApplicationDB appDB;
		
		public FloorStkReplenCel06LI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FloorStkReplenCel06LISp(
			string pStartPsNum,
			string pEndPsNum,
			string pStartJob,
			string pEndJob,
			int? pStartJobSuffix,
			int? pEndJobSuffix,
			string pStartItem,
			string pEndItem,
			string pStartJobmatlItem,
			string pEndJobmatlItem,
			string pJobType,
			DateTime? pStartDate,
			DateTime? pEndDate,
			string pStartWc,
			string pEndWc,
			int? pSubtractFlrQty,
			string pWarehouse,
			string pSearchField,
			string Infobar)
		{
			PsNumType _pStartPsNum = pStartPsNum;
			PsNumType _pEndPsNum = pEndPsNum;
			JobType _pStartJob = pStartJob;
			JobType _pEndJob = pEndJob;
			SuffixType _pStartJobSuffix = pStartJobSuffix;
			SuffixType _pEndJobSuffix = pEndJobSuffix;
			ItemType _pStartItem = pStartItem;
			ItemType _pEndItem = pEndItem;
			ItemType _pStartJobmatlItem = pStartJobmatlItem;
			ItemType _pEndJobmatlItem = pEndJobmatlItem;
			JobTypeType _pJobType = pJobType;
			DateType _pStartDate = pStartDate;
			DateType _pEndDate = pEndDate;
			WcType _pStartWc = pStartWc;
			WcType _pEndWc = pEndWc;
			FlagNyType _pSubtractFlrQty = pSubtractFlrQty;
			WhseType _pWarehouse = pWarehouse;
			StringType _pSearchField = pSearchField;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FloorStkReplenCel06LISp";
				
				appDB.AddCommandParameter(cmd, "pStartPsNum", _pStartPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndPsNum", _pEndPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartJob", _pStartJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJob", _pEndJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartJobSuffix", _pStartJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJobSuffix", _pEndJobSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartItem", _pStartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndItem", _pEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartJobmatlItem", _pStartJobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndJobmatlItem", _pEndJobmatlItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJobType", _pJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartWc", _pStartWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndWc", _pEndWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSubtractFlrQty", _pSubtractFlrQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pWarehouse", _pWarehouse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSearchField", _pSearchField, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
