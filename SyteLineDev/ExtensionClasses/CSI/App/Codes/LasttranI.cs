//PROJECT NAME: Codes
//CLASS NAME: LasttranI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class LasttranI : ILasttranI
	{
		readonly IApplicationDB appDB;
		
		
		public LasttranI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LasttranLastTran,
		string Infobar) LasttranISp(int? LasttranKey,
		string Action,
		decimal? LasttranLastTran,
		string Infobar)
		{
			LasttranKeyType _LasttranKey = LasttranKey;
			StringType _Action = Action;
			LastTranType _LasttranLastTran = LasttranLastTran;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LasttranISp";
				
				appDB.AddCommandParameter(cmd, "LasttranKey", _LasttranKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LasttranLastTran", _LasttranLastTran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LasttranLastTran = _LasttranLastTran;
				Infobar = _Infobar;
				
				return (Severity, LasttranLastTran, Infobar);
			}
		}
	}
}
