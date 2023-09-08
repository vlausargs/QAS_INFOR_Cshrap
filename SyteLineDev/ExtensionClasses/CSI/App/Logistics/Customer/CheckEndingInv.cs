//PROJECT NAME: Logistics
//CLASS NAME: CheckEndingInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckEndingInv : ICheckEndingInv
	{
		readonly IApplicationDB appDB;
		
		
		public CheckEndingInv(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckEndingInvSp(string PEndInv,
		string Infobar)
		{
			InvNumType _PEndInv = PEndInv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckEndingInvSp";
				
				appDB.AddCommandParameter(cmd, "PEndInv", _PEndInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
