//PROJECT NAME: Logistics
//CLASS NAME: CheckPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckPrefix : ICheckPrefix
	{
		readonly IApplicationDB appDB;
		
		
		public CheckPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckPrefixSp(string PStartInv,
		string PEndInv,
		string Infobar)
		{
			InvNumType _PStartInv = PStartInv;
			InvNumType _PEndInv = PEndInv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckPrefixSp";
				
				appDB.AddCommandParameter(cmd, "PStartInv", _PStartInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndInv", _PEndInv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
