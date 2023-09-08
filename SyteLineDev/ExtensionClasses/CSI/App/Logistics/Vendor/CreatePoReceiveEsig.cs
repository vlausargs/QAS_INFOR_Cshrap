//PROJECT NAME: CSIVendor
//CLASS NAME: CreatePoReceiveEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICreatePoReceiveEsig
	{
		int CreatePoReceiveEsigSp(ref string Infobar);
	}
	
	public class CreatePoReceiveEsig : ICreatePoReceiveEsig
	{
		readonly IApplicationDB appDB;
		
		public CreatePoReceiveEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CreatePoReceiveEsigSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePoReceiveEsigSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
