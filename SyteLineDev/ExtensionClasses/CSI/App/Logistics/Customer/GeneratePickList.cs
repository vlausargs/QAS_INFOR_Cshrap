//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePickList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGeneratePickList
	{
		(int? ReturnCode, Guid? BGTaskProcessId1, Guid? BGTaskProcessId2, decimal? StartingPickListId, decimal? EndingPickListId, string InfoBar) GeneratePickListSp(Guid? ProcessId,
		string PPicker,
		string PPackLoc,
		Guid? BGTaskProcessId1,
		Guid? BGTaskProcessId2,
		decimal? StartingPickListId,
		decimal? EndingPickListId,
		byte? PrintPickList,
		byte? GenerateBulkPickList,
		string InfoBar,
		string WareHouse = null);
	}
	
	public class GeneratePickList : IGeneratePickList
	{
		readonly IApplicationDB appDB;
		
		public GeneratePickList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? BGTaskProcessId1, Guid? BGTaskProcessId2, decimal? StartingPickListId, decimal? EndingPickListId, string InfoBar) GeneratePickListSp(Guid? ProcessId,
		string PPicker,
		string PPackLoc,
		Guid? BGTaskProcessId1,
		Guid? BGTaskProcessId2,
		decimal? StartingPickListId,
		decimal? EndingPickListId,
		byte? PrintPickList,
		byte? GenerateBulkPickList,
		string InfoBar,
		string WareHouse = null)
		{
			RowPointerType _ProcessId = ProcessId;
			UsernameType _PPicker = PPicker;
			LocType _PPackLoc = PPackLoc;
			RowPointerType _BGTaskProcessId1 = BGTaskProcessId1;
			RowPointerType _BGTaskProcessId2 = BGTaskProcessId2;
			PickListIDType _StartingPickListId = StartingPickListId;
			PickListIDType _EndingPickListId = EndingPickListId;
			ListYesNoType _PrintPickList = PrintPickList;
			ListYesNoType _GenerateBulkPickList = GenerateBulkPickList;
			InfobarType _InfoBar = InfoBar;
			WhseType _WareHouse = WareHouse;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GeneratePickListSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPicker", _PPicker, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPackLoc", _PPackLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskProcessId1", _BGTaskProcessId1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BGTaskProcessId2", _BGTaskProcessId2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "StartingPickListId", _StartingPickListId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndingPickListId", _EndingPickListId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintPickList", _PrintPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateBulkPickList", _GenerateBulkPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "WareHouse", _WareHouse, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BGTaskProcessId1 = _BGTaskProcessId1;
				BGTaskProcessId2 = _BGTaskProcessId2;
				StartingPickListId = _StartingPickListId;
				EndingPickListId = _EndingPickListId;
				InfoBar = _InfoBar;
				
				return (Severity, BGTaskProcessId1, BGTaskProcessId2, StartingPickListId, EndingPickListId, InfoBar);
			}
		}
	}
}
