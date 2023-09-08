//PROJECT NAME: Production
//CLASS NAME: PP_ProcessPrintingEstWB_CopyPrintData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_ProcessPrintingEstWB_CopyPrintData : IPP_ProcessPrintingEstWB_CopyPrintData
	{
		readonly IApplicationDB appDB;
		
		public PP_ProcessPrintingEstWB_CopyPrintData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PP_ProcessPrintingEstWB_CopyPrintDataSp(
			string QuoteType,
			string SourceJob,
			int? SourceSuffix,
			string TargetJob,
			int? TargetSuffix,
			string Infobar)
		{
			StringType _QuoteType = QuoteType;
			JobType _SourceJob = SourceJob;
			SuffixType _SourceSuffix = SourceSuffix;
			JobType _TargetJob = TargetJob;
			SuffixType _TargetSuffix = TargetSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ProcessPrintingEstWB_CopyPrintDataSp";
				
				appDB.AddCommandParameter(cmd, "QuoteType", _QuoteType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceJob", _SourceJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSuffix", _SourceSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetJob", _TargetJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TargetSuffix", _TargetSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
