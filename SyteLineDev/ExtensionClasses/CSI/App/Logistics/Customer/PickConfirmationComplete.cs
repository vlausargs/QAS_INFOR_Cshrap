//PROJECT NAME: CSICustomer
//CLASS NAME: PickConfirmationComplete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPickConfirmationComplete
	{
		int PickConfirmationCompleteSp(Guid? ProcessId,
		                               decimal? PPickListID,
		                               byte? RecordDiff,
		                               ref string Infobar);
	}
	
	public class PickConfirmationComplete : IPickConfirmationComplete
	{
		readonly IApplicationDB appDB;
		
		public PickConfirmationComplete(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PickConfirmationCompleteSp(Guid? ProcessId,
		                                      decimal? PPickListID,
		                                      byte? RecordDiff,
		                                      ref string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			PickListIDType _PPickListID = PPickListID;
			ListYesNoType _RecordDiff = RecordDiff;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PickConfirmationCompleteSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPickListID", _PPickListID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDiff", _RecordDiff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
