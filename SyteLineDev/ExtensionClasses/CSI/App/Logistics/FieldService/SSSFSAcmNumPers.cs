//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmNumPers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSAcmNumPers : ISSSFSAcmNumPers
	{
		readonly IApplicationDB appDB;
		
		public SSSFSAcmNumPers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? NumPeriods,
			string Infobar) SSSFSAcmNumPersSp(
			DateTime? StartDate,
			DateTime? EndDate,
			int? NumPeriods,
			string Infobar)
		{
			DateType _StartDate = StartDate;
			DateType _EndDate = EndDate;
			GenericIntType _NumPeriods = NumPeriods;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSAcmNumPersSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumPeriods", _NumPeriods, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NumPeriods = _NumPeriods;
				Infobar = _Infobar;
				
				return (Severity, NumPeriods, Infobar);
			}
		}
	}
}
