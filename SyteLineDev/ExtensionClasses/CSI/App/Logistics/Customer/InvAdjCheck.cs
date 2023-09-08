//PROJECT NAME: CSICustomer
//CLASS NAME: InvAdjCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IInvAdjCheck
	{
		(int? ReturnCode, string Infobar) InvAdjCheckSp(string CoNum,
		decimal? UserId,
		Guid? SessionID,
		string Infobar,
		decimal? Freight = 0,
		decimal? MiscCharges = 0);
	}
	
	public class InvAdjCheck : IInvAdjCheck
	{
		readonly IApplicationDB appDB;
		
		public InvAdjCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) InvAdjCheckSp(string CoNum,
		decimal? UserId,
		Guid? SessionID,
		string Infobar,
		decimal? Freight = 0,
		decimal? MiscCharges = 0)
		{
			CoNumType _CoNum = CoNum;
			TokenType _UserId = UserId;
			RowPointerType _SessionID = SessionID;
			InfobarType _Infobar = Infobar;
			AmountType _Freight = Freight;
			AmountType _MiscCharges = MiscCharges;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvAdjCheckSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Freight", _Freight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MiscCharges", _MiscCharges, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
