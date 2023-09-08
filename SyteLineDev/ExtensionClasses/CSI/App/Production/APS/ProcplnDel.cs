//PROJECT NAME: Production
//CLASS NAME: ProcplnDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ProcplnDel : IProcplnDel
	{
		readonly IApplicationDB appDB;
		
		
		public ProcplnDel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProcplnDelSp(string Procplan,
		int? AltNo)
		{
			ApsProcplanType _Procplan = Procplan;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcplnDelSp";
				
				appDB.AddCommandParameter(cmd, "Procplan", _Procplan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
