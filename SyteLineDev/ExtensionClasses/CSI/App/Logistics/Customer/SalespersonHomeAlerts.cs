//PROJECT NAME: Logistics
//CLASS NAME: SalespersonHomeAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SalespersonHomeAlerts : ISalespersonHomeAlerts
	{
		readonly IApplicationDB appDB;
		
		
		public SalespersonHomeAlerts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PastDueOpps,
		int? PastDueOppTasks,
		int? EstimatesToExpire,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages) SalespersonHomeAlertsSp(string Slsman,
		int? PastDueOpps,
		int? PastDueOppTasks,
		int? EstimatesToExpire,
		int? NumberOfUserTasks,
		int? NumberOfEventMessages)
		{
			SlsmanType _Slsman = Slsman;
			NumberOfLinesType _PastDueOpps = PastDueOpps;
			NumberOfLinesType _PastDueOppTasks = PastDueOppTasks;
			NumberOfLinesType _EstimatesToExpire = EstimatesToExpire;
			NumberOfLinesType _NumberOfUserTasks = NumberOfUserTasks;
			NumberOfLinesType _NumberOfEventMessages = NumberOfEventMessages;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SalespersonHomeAlertsSp";
				
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PastDueOpps", _PastDueOpps, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PastDueOppTasks", _PastDueOppTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EstimatesToExpire", _EstimatesToExpire, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfUserTasks", _NumberOfUserTasks, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NumberOfEventMessages", _NumberOfEventMessages, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PastDueOpps = _PastDueOpps;
				PastDueOppTasks = _PastDueOppTasks;
				EstimatesToExpire = _EstimatesToExpire;
				NumberOfUserTasks = _NumberOfUserTasks;
				NumberOfEventMessages = _NumberOfEventMessages;
				
				return (Severity, PastDueOpps, PastDueOppTasks, EstimatesToExpire, NumberOfUserTasks, NumberOfEventMessages);
			}
		}
	}
}
