//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCcPurge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemCcPurge
	{
		(int? ReturnCode, int? ProcessCount, string Infobar) ItemCcPurgeSp(byte? RollBackonProcessCount,
		string CurWhse,
		string CycleStatus,
		string AbcCode,
		string BegItem,
		string EndItem,
		string BegLoc,
		string EndLoc,
		DateTime? BegCycleDate,
		DateTime? EndCycleDate,
		string BegProductCode,
		string EndProductCode,
		string BegPlanCode,
		string EndPlanCode,
		int? ProcessCount,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		byte? CycleFlag = null);
	}
	
	public class ItemCcPurge : IItemCcPurge
	{
		readonly IApplicationDB appDB;
		
		public ItemCcPurge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? ProcessCount, string Infobar) ItemCcPurgeSp(byte? RollBackonProcessCount,
		string CurWhse,
		string CycleStatus,
		string AbcCode,
		string BegItem,
		string EndItem,
		string BegLoc,
		string EndLoc,
		DateTime? BegCycleDate,
		DateTime? EndCycleDate,
		string BegProductCode,
		string EndProductCode,
		string BegPlanCode,
		string EndPlanCode,
		int? ProcessCount,
		string Infobar,
		short? StartingDateOffset = null,
		short? EndingDateOffset = null,
		byte? CycleFlag = null)
		{
			Flag _RollBackonProcessCount = RollBackonProcessCount;
			WhseType _CurWhse = CurWhse;
			StringType _CycleStatus = CycleStatus;
			StringType _AbcCode = AbcCode;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			LocType _BegLoc = BegLoc;
			LocType _EndLoc = EndLoc;
			DateType _BegCycleDate = BegCycleDate;
			DateType _EndCycleDate = EndCycleDate;
			ProductCodeType _BegProductCode = BegProductCode;
			ProductCodeType _EndProductCode = EndProductCode;
			UserCodeType _BegPlanCode = BegPlanCode;
			UserCodeType _EndPlanCode = EndPlanCode;
			IntType _ProcessCount = ProcessCount;
			InfobarType _Infobar = Infobar;
			DateOffsetType _StartingDateOffset = StartingDateOffset;
			DateOffsetType _EndingDateOffset = EndingDateOffset;
			ListYesNoType _CycleFlag = CycleFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCcPurgeSp";
				
				appDB.AddCommandParameter(cmd, "RollBackonProcessCount", _RollBackonProcessCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CycleStatus", _CycleStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbcCode", _AbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegLoc", _BegLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLoc", _EndLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegCycleDate", _BegCycleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCycleDate", _EndCycleDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegProductCode", _BegProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegPlanCode", _BegPlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPlanCode", _EndPlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessCount", _ProcessCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingDateOffset", _StartingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDateOffset", _EndingDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CycleFlag", _CycleFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProcessCount = _ProcessCount;
				Infobar = _Infobar;
				
				return (Severity, ProcessCount, Infobar);
			}
		}
	}
}
