//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class RgrpMbrsDel : IRgrpMbrsDel
	{
		readonly IApplicationDB appDB;
		
		
		public RgrpMbrsDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RgrpMbrsDelSp(Guid? Rowp,
		string PRgrp,
		string PRes,
		int? AltNo)
		{
			RowPointerType _Rowp = Rowp;
			ApsResgroupType _PRgrp = PRgrp;
			ApsResourceType _PRes = PRes;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RgrpMbrsDelSp";
				
				appDB.AddCommandParameter(cmd, "Rowp", _Rowp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRgrp", _PRgrp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRes", _PRes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
