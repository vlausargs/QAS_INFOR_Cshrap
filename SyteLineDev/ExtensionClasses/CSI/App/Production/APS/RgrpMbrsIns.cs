//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class RgrpMbrsIns : IRgrpMbrsIns
	{
		readonly IApplicationDB appDB;
		
		
		public RgrpMbrsIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RgrpMbrsInsSp(string PRgrp,
		string PRes,
		int? Seqno,
		int? AltNo)
		{
			ApsResgroupType _PRgrp = PRgrp;
			ApsResourceType _PRes = PRes;
			ApsIntType _Seqno = Seqno;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RgrpMbrsInsSp";
				
				appDB.AddCommandParameter(cmd, "PRgrp", _PRgrp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRes", _PRes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seqno", _Seqno, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
