//PROJECT NAME: Data
//CLASS NAME: CalcHrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CalcHrs : ICalcHrs
	{
		readonly IApplicationDB appDB;
		
		public CalcHrs(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? SetupTicks,
			int? RunTicks) CalcHrsSp(
			string pOperSched,
			decimal? PEfficiency,
			decimal? pQtyReleased,
			decimal? pQtyScrapped,
			decimal? pQtyComplete,
			decimal? pRunHrsTLbr,
			decimal? pSetupHrsT,
			decimal? pRunTicksLbr,
			decimal? pSchedTicks,
			decimal? pSetupTicks,
			string pSchedDriver,
			decimal? pRunHrsTMch,
			decimal? pRunTicksMch,
			int? SetupTicks,
			int? RunTicks)
		{
			ListHoursPiecesType _pOperSched = pOperSched;
			EfficiencyType _PEfficiency = PEfficiency;
			QtyUnitType _pQtyReleased = pQtyReleased;
			QtyUnitType _pQtyScrapped = pQtyScrapped;
			QtyUnitType _pQtyComplete = pQtyComplete;
			TotalHoursType _pRunHrsTLbr = pRunHrsTLbr;
			TotalHoursType _pSetupHrsT = pSetupHrsT;
			RunTicksType _pRunTicksLbr = pRunTicksLbr;
			TicksType _pSchedTicks = pSchedTicks;
			TicksType _pSetupTicks = pSetupTicks;
			SchedDriverType _pSchedDriver = pSchedDriver;
			TotalHoursType _pRunHrsTMch = pRunHrsTMch;
			RunTicksType _pRunTicksMch = pRunTicksMch;
			GenericNoType _SetupTicks = SetupTicks;
			GenericNoType _RunTicks = RunTicks;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CalcHrsSp";
				
				appDB.AddCommandParameter(cmd, "pOperSched", _pOperSched, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEfficiency", _PEfficiency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyReleased", _pQtyReleased, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyScrapped", _pQtyScrapped, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pQtyComplete", _pQtyComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunHrsTLbr", _pRunHrsTLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSetupHrsT", _pSetupHrsT, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunTicksLbr", _pRunTicksLbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSchedTicks", _pSchedTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSetupTicks", _pSetupTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSchedDriver", _pSchedDriver, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunHrsTMch", _pRunHrsTMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRunTicksMch", _pRunTicksMch, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupTicks", _SetupTicks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunTicks", _RunTicks, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SetupTicks = _SetupTicks;
				RunTicks = _RunTicks;
				
				return (Severity, SetupTicks, RunTicks);
			}
		}

		public decimal? CalcHrsFn(
			string pType,
			string pEmpNum,
			int? pSeq)
		{
			PrtrxdTypeType _pType = pType;
			EmpNumType _pEmpNum = pEmpNum;
			PrtrxSeqType _pSeq = pSeq;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CalcHrs](@pType, @pEmpNum, @pSeq)";

				appDB.AddCommandParameter(cmd, "pType", _pType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpNum", _pEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeq", _pSeq, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<decimal?>(cmd);

				return Output;
			}
		}
	}
}
