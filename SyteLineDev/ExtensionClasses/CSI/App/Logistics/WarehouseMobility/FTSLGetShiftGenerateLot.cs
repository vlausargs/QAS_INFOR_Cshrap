//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetShiftGenerateLot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetShiftGenerateLot
	{
		(int? ReturnCode, byte? GenerateLot,
		string Shift) FTSLGetShiftGenerateLotSp(string CallForm,
		short? TAImplement = 0,
		string EmpNum = null,
		byte? GenerateLot = (byte)0,
		string Shift = null);
	}
	
	public class FTSLGetShiftGenerateLot : IFTSLGetShiftGenerateLot
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetShiftGenerateLot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? GenerateLot,
		string Shift) FTSLGetShiftGenerateLotSp(string CallForm,
		short? TAImplement = 0,
		string EmpNum = null,
		byte? GenerateLot = (byte)0,
		string Shift = null)
		{
			JobType _CallForm = CallForm;
			CoLineType _TAImplement = TAImplement;
			EmpNumType _EmpNum = EmpNum;
			ListYesNoType _GenerateLot = GenerateLot;
			ShiftType _Shift = Shift;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetShiftGenerateLotSp";
				
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAImplement", _TAImplement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GenerateLot", _GenerateLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				GenerateLot = _GenerateLot;
				Shift = _Shift;
				
				return (Severity, GenerateLot, Shift);
			}
		}
	}
}
