//PROJECT NAME: Production
//CLASS NAME: PutAltSched.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PutAltSched : IPutAltSched
	{
		readonly IApplicationDB appDB;
		
		
		public PutAltSched(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PutAltSchedSp(int? pAltNo,
		DateTime? pStartDate,
		DateTime? pEndDate)
		{
			ApsAltNoType _pAltNo = pAltNo;
			DateTimeType _pStartDate = pStartDate;
			DateTimeType _pEndDate = pEndDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PutAltSchedSp";
				
				appDB.AddCommandParameter(cmd, "pAltNo", _pAltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
