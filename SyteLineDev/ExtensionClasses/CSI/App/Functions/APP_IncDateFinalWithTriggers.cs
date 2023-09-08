//PROJECT NAME: Data
//CLASS NAME: APP_IncDateFinalWithTriggers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_IncDateFinalWithTriggers : IAPP_IncDateFinalWithTriggers
	{
		readonly IApplicationDB appDB;
		
		public APP_IncDateFinalWithTriggers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) APP_IncDateFinalWithTriggersSp(
			int? Days,
			int? Years,
			int? RecalcPertot,
			int? RecalcTick_Cal,
			int? RecalcMdayCal,
			int? RecalcTicks,
			string Status5,
			string Status6,
			string Status7,
			string Status8,
			string Status9,
			string InfoBar)
		{
			IntType _Days = Days;
			IntType _Years = Years;
			IntType _RecalcPertot = RecalcPertot;
			IntType _RecalcTick_Cal = RecalcTick_Cal;
			IntType _RecalcMdayCal = RecalcMdayCal;
			IntType _RecalcTicks = RecalcTicks;
			VeryLongListType _Status5 = Status5;
			VeryLongListType _Status6 = Status6;
			VeryLongListType _Status7 = Status7;
			VeryLongListType _Status8 = Status8;
			VeryLongListType _Status9 = Status9;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_IncDateFinalWithTriggersSp";
				
				appDB.AddCommandParameter(cmd, "Days", _Days, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Years", _Years, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecalcPertot", _RecalcPertot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecalcTick_Cal", _RecalcTick_Cal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecalcMdayCal", _RecalcMdayCal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecalcTicks", _RecalcTicks, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status5", _Status5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status6", _Status6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status7", _Status7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status8", _Status8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status9", _Status9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
