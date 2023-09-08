//PROJECT NAME: Data
//CLASS NAME: FTValidateSRO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FTValidateSRO : IFTValidateSRO
	{
		readonly IApplicationDB appDB;
		
		public FTValidateSRO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? FTValidateSROSp(
			string spEmpNum,
			DateTime? spreport_date = null,
			Guid? SessionID = null)
		{
			EmpNumType _spEmpNum = spEmpNum;
			DateTimeType _spreport_date = spreport_date;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTValidateSROSp";
				
				appDB.AddCommandParameter(cmd, "spEmpNum", _spEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "spreport_date", _spreport_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
