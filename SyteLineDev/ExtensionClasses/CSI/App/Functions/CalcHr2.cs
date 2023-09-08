//PROJECT NAME: Data
//CLASS NAME: CalcHr2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcHr2 : ICalcHr2
	{
		readonly IApplicationDB appDB;
		
		public CalcHr2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CalcHr2Sp(
			decimal? PSchedTicks,
			string POperSched,
			decimal? PQtyReleased,
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			decimal? PRunTicksLbr,
			decimal? PEfficiency,
			decimal? PRunHrsTLbr,
			decimal? PSetupHrsT,
			string PSchedDriver,
			decimal? PRunHrsTMch,
			decimal? PRunTicksMch)
		{
			TicksType _PSchedTicks = PSchedTicks;
			ListHoursPiecesType _POperSched = POperSched;
			QtyUnitType _PQtyReleased = PQtyReleased;
			QtyUnitType _PQtyComplete = PQtyComplete;
			QtyUnitType _PQtyScrapped = PQtyScrapped;
			RunTicksType _PRunTicksLbr = PRunTicksLbr;
			EfficiencyType _PEfficiency = PEfficiency;
			TotalHoursType _PRunHrsTLbr = PRunHrsTLbr;
			TotalHoursType _PSetupHrsT = PSetupHrsT;
			SchedDriverType _PSchedDriver = PSchedDriver;
			TotalHoursType _PRunHrsTMch = PRunHrsTMch;
			RunTicksType _PRunTicksMch = PRunTicksMch;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcHr2Sp";
				
				appDB.AddCommandParameter(cmd, "PSchedTicks", _PSchedTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperSched", _POperSched, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyReleased", _PQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyComplete", _PQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyScrapped", _PQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRunTicksLbr", _PRunTicksLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEfficiency", _PEfficiency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRunHrsTLbr", _PRunHrsTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSetupHrsT", _PSetupHrsT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSchedDriver", _PSchedDriver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRunHrsTMch", _PRunHrsTMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRunTicksMch", _PRunTicksMch, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
