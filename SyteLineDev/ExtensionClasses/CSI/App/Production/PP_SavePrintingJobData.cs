//PROJECT NAME: Production
//CLASS NAME: PP_SavePrintingJobData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_SavePrintingJobData : IPP_SavePrintingJobData
	{
		readonly IApplicationDB appDB;
		
		
		public PP_SavePrintingJobData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_SavePrintingJobDataSp(string Job,
		int? Suffix,
		decimal? MinSheetCount,
		decimal? PrintQuotePrice,
		int? Up,
		int? Out,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			PP_SheetCountType _MinSheetCount = MinSheetCount;
			CostPrcType _PrintQuotePrice = PrintQuotePrice;
			PP_UpNumberType _Up = Up;
			PP_OutNumberType _Out = Out;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_SavePrintingJobDataSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MinSheetCount", _MinSheetCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintQuotePrice", _PrintQuotePrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Up", _Up, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Out", _Out, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
