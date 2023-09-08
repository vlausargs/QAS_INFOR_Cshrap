//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface ICopyBomLeaveToJob
	{
		int CopyBomLeaveToJobSp(byte? CopyBom,
		                        string Job,
		                        short? Suffix,
		                        ref int? AfterOper,
		                        ref byte? AfterOperED,
		                        ref string OptionType,
		                        ref byte? OptionED,
		                        ref string Infobar);
	}
	
	public class CopyBomLeaveToJob : ICopyBomLeaveToJob
	{
		readonly IApplicationDB appDB;
		
		public CopyBomLeaveToJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CopyBomLeaveToJobSp(byte? CopyBom,
		                               string Job,
		                               short? Suffix,
		                               ref int? AfterOper,
		                               ref byte? AfterOperED,
		                               ref string OptionType,
		                               ref byte? OptionED,
		                               ref string Infobar)
		{
			ListYesNoType _CopyBom = CopyBom;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _AfterOper = AfterOper;
			ListYesNoType _AfterOperED = AfterOperED;
			StringType _OptionType = OptionType;
			ListYesNoType _OptionED = OptionED;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CopyBomLeaveToJobSp";
				
				appDB.AddCommandParameter(cmd, "CopyBom", _CopyBom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AfterOper", _AfterOper, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AfterOperED", _AfterOperED, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OptionType", _OptionType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OptionED", _OptionED, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AfterOper = _AfterOper;
				AfterOperED = _AfterOperED;
				OptionType = _OptionType;
				OptionED = _OptionED;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
