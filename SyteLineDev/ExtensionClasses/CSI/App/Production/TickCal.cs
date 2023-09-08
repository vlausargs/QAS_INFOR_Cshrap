//PROJECT NAME: Production
//CLASS NAME: TickCal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class TickCal : ITickCal
	{
		readonly IApplicationDB appDB;
		
		
		public TickCal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TickCalSp(string StartCal,
		string EndCal = null,
		int? AltNo = null,
		DateTime? StartDate = null)
		{
			ApsShiftType _StartCal = StartCal;
			ApsShiftType _EndCal = EndCal;
			ApsAltNoType _AltNo = AltNo;
			DateType _StartDate = StartDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TickCalSp";
				
				appDB.AddCommandParameter(cmd, "StartCal", _StartCal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCal", _EndCal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNo", _AltNo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
