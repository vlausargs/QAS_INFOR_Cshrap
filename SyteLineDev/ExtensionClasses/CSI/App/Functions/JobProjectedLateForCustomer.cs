//PROJECT NAME: Data
//CLASS NAME: JobProjectedLateForCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobProjectedLateForCustomer : IJobProjectedLateForCustomer
	{
		readonly IApplicationDB appDB;
		
		public JobProjectedLateForCustomer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) JobProjectedLateForCustomerSp(
			string AJob,
			int? ASuffix,
			DateTime? AEndDate,
			DateTime? ACompDate,
			string ACustNum,
			string AOrdNum,
			string Infobar)
		{
			JobType _AJob = AJob;
			SuffixType _ASuffix = ASuffix;
			DateType _AEndDate = AEndDate;
			DateType _ACompDate = ACompDate;
			CustNumType _ACustNum = ACustNum;
			CoProjTrnNumType _AOrdNum = AOrdNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobProjectedLateForCustomerSp";
				
				appDB.AddCommandParameter(cmd, "AJob", _AJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ASuffix", _ASuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AEndDate", _AEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ACompDate", _ACompDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ACustNum", _ACustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AOrdNum", _AOrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
