//PROJECT NAME: CSICustomer
//CLASS NAME: PickConfirmation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPickConfirmation
	{
		int PickConfirmationSp(Guid? ProcessId,
		                       decimal? PPickListID,
		                       int? RecordDiff,
		                       ref string Infobar);
	}
	
	public class PickConfirmation : IPickConfirmation
	{
		readonly IApplicationDB appDB;
		
		public PickConfirmation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PickConfirmationSp(Guid? ProcessId,
		                              decimal? PPickListID,
		                              int? RecordDiff,
		                              ref string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			PickListIDType _PPickListID = PPickListID;
			IntType _RecordDiff = RecordDiff;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PickConfirmationSp";
				
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
