//PROJECT NAME: Data
//CLASS NAME: FTValidatejob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTValidatejob : IFTValidatejob
	{
		readonly IApplicationDB appDB;
		
		public FTValidatejob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTValidatejobSp(
			string spEmpNum,
			DateTime? spreport_date = null,
			int? hdr_processed = null,
			Guid? SessionID = null)
		{
			EmpNumType _spEmpNum = spEmpNum;
			DateTimeType _spreport_date = spreport_date;
			IntType _hdr_processed = hdr_processed;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTValidatejobSp";
				
				appDB.AddCommandParameter(cmd, "spEmpNum", _spEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "spreport_date", _spreport_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "hdr_processed", _hdr_processed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
