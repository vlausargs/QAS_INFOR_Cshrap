//PROJECT NAME: CSICustomer
//CLASS NAME: PickListSplitting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPickListSplitting
	{
		int PickListSplittingSp(decimal? OldPickList,
		                        Guid? ProcessId,
		                        ref decimal? NewPickList,
		                        ref string InfoBar);
	}
	
	public class PickListSplitting : IPickListSplitting
	{
		readonly IApplicationDB appDB;
		
		public PickListSplitting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PickListSplittingSp(decimal? OldPickList,
		                               Guid? ProcessId,
		                               ref decimal? NewPickList,
		                               ref string InfoBar)
		{
			PickListIDType _OldPickList = OldPickList;
			RowPointerType _ProcessId = ProcessId;
			PickListIDType _NewPickList = NewPickList;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PickListSplittingSp";
				
				appDB.AddCommandParameter(cmd, "OldPickList", _OldPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewPickList", _NewPickList, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewPickList = _NewPickList;
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
