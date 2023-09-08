//PROJECT NAME: Logistics
//CLASS NAME: BArpmtd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class BArpmtd : IBArpmtd
	{
		readonly IApplicationDB appDB;
		
		
		public BArpmtd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) BArpmtdSp(Guid? PRecid,
		string Infobar)
		{
			RowPointerType _PRecid = PRecid;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BArpmtdSp";
				
				appDB.AddCommandParameter(cmd, "PRecid", _PRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
