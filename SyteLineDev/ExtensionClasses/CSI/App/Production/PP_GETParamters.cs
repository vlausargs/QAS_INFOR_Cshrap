//PROJECT NAME: CSIProduct
//CLASS NAME: PP_GETParamters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IPP_GETParamters
	{
		int PP_GETParamtersSp(ref int? NumberOfManualHandling_steps,
		                      ref int? NumberOfSidesToPrint);
	}
	
	public class PP_GETParamters : IPP_GETParamters
	{
		readonly IApplicationDB appDB;
		
		public PP_GETParamters(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PP_GETParamtersSp(ref int? NumberOfManualHandling_steps,
		                             ref int? NumberOfSidesToPrint)
		{
			PP_NumberOfManualHandlingStepsType _NumberOfManualHandling_steps = NumberOfManualHandling_steps;
			PP_NumberOfSidesToPrintType _NumberOfSidesToPrint = NumberOfSidesToPrint;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GETParamtersSp";
				
				appDB.AddCommandParameter(cmd, "NumberOfManualHandling_steps", _NumberOfManualHandling_steps, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfSidesToPrint", _NumberOfSidesToPrint, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NumberOfManualHandling_steps = _NumberOfManualHandling_steps;
				NumberOfSidesToPrint = _NumberOfSidesToPrint;
				
				return Severity;
			}
		}
	}
}
