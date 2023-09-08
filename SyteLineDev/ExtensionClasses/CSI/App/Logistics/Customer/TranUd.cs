//PROJECT NAME: Logistics
//CLASS NAME: TranUd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TranUd : ITranUd
	{
		readonly IApplicationDB appDB;
		
		
		public TranUd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? LastTran,
		string Infobar) TranUdSp(int? LasttranKey,
		decimal? LastTran,
		string Infobar)
		{
			LasttranKeyType _LasttranKey = LasttranKey;
			LastTranType _LastTran = LastTran;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TranUdSp";
				
				appDB.AddCommandParameter(cmd, "LasttranKey", _LasttranKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTran", _LastTran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LastTran = _LastTran;
				Infobar = _Infobar;
				
				return (Severity, LastTran, Infobar);
			}
		}
	}
}
