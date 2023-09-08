//PROJECT NAME: CSICustomer
//CLASS NAME: CheckDelPick.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckDelPick
	{
		int CheckDelPickSp(decimal? PickListId,
		                   int? Sequence,
		                   ref string Error,
		                   ref string Infobar);
	}
	
	public class CheckDelPick : ICheckDelPick
	{
		readonly IApplicationDB appDB;
		
		public CheckDelPick(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckDelPickSp(decimal? PickListId,
		                          int? Sequence,
		                          ref string Error,
		                          ref string Infobar)
		{
			PickListIDType _PickListId = PickListId;
			PickListSequenceType _Sequence = Sequence;
			LongListType _Error = Error;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckDelPickSp";
				
				appDB.AddCommandParameter(cmd, "PickListId", _PickListId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Error", _Error, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Error = _Error;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
