//PROJECT NAME: CSIFinance
//CLASS NAME: LogVATReturnStamp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface ILogVATReturnStamp
	{
		int? LogVATReturnStampSp(DateTime? StartDate,
		                         DateTime? EndDate,
		                         string PeriodKey,
		                         string TaxJur,
		                         byte? TaxSystem = (byte)1);
	}
	
	public class LogVATReturnStamp : ILogVATReturnStamp
	{
		readonly IApplicationDB appDB;
		
		public LogVATReturnStamp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? LogVATReturnStampSp(DateTime? StartDate,
		                                DateTime? EndDate,
		                                string PeriodKey,
		                                string TaxJur,
		                                byte? TaxSystem = (byte)1)
		{
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			VATPeriodKeyType _PeriodKey = PeriodKey;
			TaxJurType _TaxJur = TaxJur;
			TaxSystemType _TaxSystem = TaxSystem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LogVATReturnStampSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodKey", _PeriodKey, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxJur", _TaxJur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
