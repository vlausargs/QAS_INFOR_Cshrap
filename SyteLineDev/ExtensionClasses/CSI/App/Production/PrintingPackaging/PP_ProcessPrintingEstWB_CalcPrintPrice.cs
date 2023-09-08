//PROJECT NAME: Production
//CLASS NAME: PP_ProcessPrintingEstWB_CalcPrintPrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_ProcessPrintingEstWB_CalcPrintPrice : IPP_ProcessPrintingEstWB_CalcPrintPrice
	{
		readonly IApplicationDB appDB;
		
		public PP_ProcessPrintingEstWB_CalcPrintPrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PP_ProcessPrintingEstWB_CalcPrintPriceSp(
			string RootJob,
			int? RootSuffix,
			string Infobar)
		{
			JobType _RootJob = RootJob;
			SuffixType _RootSuffix = RootSuffix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_ProcessPrintingEstWB_CalcPrintPriceSp";
				
				appDB.AddCommandParameter(cmd, "RootJob", _RootJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RootSuffix", _RootSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
