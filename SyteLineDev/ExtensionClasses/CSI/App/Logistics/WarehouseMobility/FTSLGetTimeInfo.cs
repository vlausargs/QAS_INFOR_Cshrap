//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetTimeInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetTimeInfo
	{
		(int? ReturnCode, int? SLOperation,
		string Infobar) FTSLGetTimeInfoSp(string EmpNum,
		byte? TAImplement = (byte)0,
		string CallForm = null,
		string Job = null,
		short? Suffix = null,
		int? SLOperation = null,
		string Infobar = null);
	}
	
	public class FTSLGetTimeInfo : IFTSLGetTimeInfo
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetTimeInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? SLOperation,
		string Infobar) FTSLGetTimeInfoSp(string EmpNum,
		byte? TAImplement = (byte)0,
		string CallForm = null,
		string Job = null,
		short? Suffix = null,
		int? SLOperation = null,
		string Infobar = null)
		{
			EmpNumType _EmpNum = EmpNum;
			ListYesNoType _TAImplement = TAImplement;
			JobType _CallForm = CallForm;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _SLOperation = SLOperation;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetTimeInfoSp";
				
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TAImplement", _TAImplement, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CallForm", _CallForm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLOperation", _SLOperation, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SLOperation = _SLOperation;
				Infobar = _Infobar;
				
				return (Severity, SLOperation, Infobar);
			}
		}
	}
}
