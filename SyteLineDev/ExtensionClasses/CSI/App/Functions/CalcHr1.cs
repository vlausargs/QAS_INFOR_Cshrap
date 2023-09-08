//PROJECT NAME: Data
//CLASS NAME: CalcHr1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcHr1 : ICalcHr1
	{
		readonly IApplicationDB appDB;
		
		public CalcHr1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CalcHr1Sp(
			decimal? pSchedTicks,
			string pOperSched,
			decimal? pQtyComplete,
			decimal? pRunHrsTLbr,
			decimal? pSetupTicks,
			decimal? pEfficiency,
			decimal? pSetupHrsT,
			string pSchedDriver,
			decimal? pRunHrsTMch)
		{
			TicksType _pSchedTicks = pSchedTicks;
			ListHoursPiecesType _pOperSched = pOperSched;
			QtyUnitType _pQtyComplete = pQtyComplete;
			TotalHoursType _pRunHrsTLbr = pRunHrsTLbr;
			TicksType _pSetupTicks = pSetupTicks;
			EfficiencyType _pEfficiency = pEfficiency;
			TotalHoursType _pSetupHrsT = pSetupHrsT;
			SchedDriverType _pSchedDriver = pSchedDriver;
			TotalHoursType _pRunHrsTMch = pRunHrsTMch;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcHr1Sp";
				
				appDB.AddCommandParameter(cmd, "pSchedTicks", _pSchedTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOperSched", _pOperSched, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyComplete", _pQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunHrsTLbr", _pRunHrsTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSetupTicks", _pSetupTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEfficiency", _pEfficiency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSetupHrsT", _pSetupHrsT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSchedDriver", _pSchedDriver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunHrsTMch", _pRunHrsTMch, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
