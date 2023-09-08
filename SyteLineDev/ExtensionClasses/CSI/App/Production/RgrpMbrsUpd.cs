//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class RgrpMbrsUpd : IRgrpMbrsUpd
	{
		readonly IApplicationDB appDB;
		
		
		public RgrpMbrsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) RgrpMbrsUpdSp(Guid? Rowp,
		int? Seqno,
		string Rgid,
		string Resid,
		int? AltNo,
		string Infobar)
		{
			RowPointerType _Rowp = Rowp;
			ApsIntType _Seqno = Seqno;
			ApsResgroupType _Rgid = Rgid;
			ApsResourceType _Resid = Resid;
			ApsAltNoType _AltNo = AltNo;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RgrpMbrsUpdSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seqno", _Seqno, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Rgid", _Rgid, ParameterDirection.Input);
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
