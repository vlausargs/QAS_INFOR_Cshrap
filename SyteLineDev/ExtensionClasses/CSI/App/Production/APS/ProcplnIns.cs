//PROJECT NAME: Production
//CLASS NAME: ProcplnIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ProcplnIns : IProcplnIns
	{
		readonly IApplicationDB appDB;
		
		
		public ProcplnIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProcplnInsSp(string Procplan,
		string Descr,
		string Effect,
		string SchedOnlyFg,
		int? AltNo)
		{
			ApsProcplanType _Procplan = Procplan;
			ApsDescriptType _Descr = Descr;
			ApsEffectType _Effect = Effect;
			ApsFlagType _SchedOnlyFg = SchedOnlyFg;
			ApsAltNoType _AltNo = AltNo;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcplnInsSp";
				
				appDB.AddCommandParameter(cmd, "Procplan", _Procplan, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Descr", _Descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Effect", _Effect, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SchedOnlyFg", _SchedOnlyFg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
