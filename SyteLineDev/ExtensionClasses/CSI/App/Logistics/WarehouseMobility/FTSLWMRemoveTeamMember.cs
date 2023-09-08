//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLWMRemoveTeamMember.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLWMRemoveTeamMember
	{
		int FTSLWMRemoveTeamMemberSp(ref string EmployeeNumber,
		                             ref string ReturnSLEmpShift,
		                             ref string InfoBar);
	}
	
	public class FTSLWMRemoveTeamMember : IFTSLWMRemoveTeamMember
	{
		readonly IApplicationDB appDB;
		
		public FTSLWMRemoveTeamMember(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTSLWMRemoveTeamMemberSp(ref string EmployeeNumber,
		                                    ref string ReturnSLEmpShift,
		                                    ref string InfoBar)
		{
			EmpNumType _EmployeeNumber = EmployeeNumber;
			ShiftType _ReturnSLEmpShift = ReturnSLEmpShift;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLWMRemoveTeamMemberSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeNumber", _EmployeeNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReturnSLEmpShift", _ReturnSLEmpShift, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EmployeeNumber = _EmployeeNumber;
				ReturnSLEmpShift = _ReturnSLEmpShift;
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
