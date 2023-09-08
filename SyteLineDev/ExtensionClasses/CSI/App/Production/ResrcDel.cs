//PROJECT NAME: Production
//CLASS NAME: ResrcDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class ResrcDel : IResrcDel
	{
		readonly IApplicationDB appDB;
		
		
		public ResrcDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ResrcDelSp(string Resid,
		int? AltNo,
		string Infobar)
		{
			ApsResourceType _Resid = Resid;
			ApsAltNoType _AltNo = AltNo;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ResrcDelSp";
				
				appDB.AddCommandParameter(cmd, "Resid", _Resid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
