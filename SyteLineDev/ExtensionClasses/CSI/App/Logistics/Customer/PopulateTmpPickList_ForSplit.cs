//PROJECT NAME: CSICustomer
//CLASS NAME: PopulateTmpPickList_ForSplit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPopulateTmpPickList_ForSplit
	{
		int PopulateTmpPickList_ForSplitSp(decimal? picklistid,
		                                   Guid? processid);
	}
	
	public class PopulateTmpPickList_ForSplit : IPopulateTmpPickList_ForSplit
	{
		readonly IApplicationDB appDB;
		
		public PopulateTmpPickList_ForSplit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PopulateTmpPickList_ForSplitSp(decimal? picklistid,
		                                          Guid? processid)
		{
			PickListIDType _picklistid = picklistid;
			RowPointerType _processid = processid;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PopulateTmpPickList_ForSplitSp";
				
				appDB.AddCommandParameter(cmd, "picklistid", _picklistid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "processid", _processid, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
