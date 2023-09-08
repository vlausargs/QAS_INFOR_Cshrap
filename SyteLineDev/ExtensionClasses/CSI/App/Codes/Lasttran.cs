//PROJECT NAME: Codes
//CLASS NAME: Lasttran.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class Lasttran : ILasttran
	{
		readonly IApplicationDB appDB;
		
		
		public Lasttran(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Success,
		string Infobar) LasttranSp(int? Key,
		decimal? LockUserid,
		int? TransLocked,
		int? Success,
		string Infobar)
		{
			LasttranKeyType _Key = Key;
			TokenType _LockUserid = LockUserid;
			IntType _TransLocked = TransLocked;
			FlagNyType _Success = Success;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LasttranSp";
				
				appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockUserid", _LockUserid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransLocked", _TransLocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Success", _Success, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Success = _Success;
				Infobar = _Infobar;
				
				return (Severity, Success, Infobar);
			}
		}
	}
}
