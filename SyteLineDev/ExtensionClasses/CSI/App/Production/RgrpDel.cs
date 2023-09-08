//PROJECT NAME: Production
//CLASS NAME: RgrpDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class RgrpDel : IRgrpDel
	{
		readonly IApplicationDB appDB;
		
		
		public RgrpDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RgrpDelSp(string Rgid,
		int? AltNo,
		string Infobar)
		{
			ApsResgroupType _Rgid = Rgid;
			ApsAltNoType _AltNo = AltNo;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RgrpDelSp";
				
				appDB.AddCommandParameter(cmd, "Rgid", _Rgid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
