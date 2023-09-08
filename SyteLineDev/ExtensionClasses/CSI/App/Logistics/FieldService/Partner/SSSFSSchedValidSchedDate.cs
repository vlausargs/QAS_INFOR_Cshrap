//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedValidSchedDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedValidSchedDate : ISSSFSSchedValidSchedDate
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSSchedValidSchedDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSSchedValidSchedDateSp(DateTime? SchedDate,
		string PartnerId = null,
		string Infobar = null)
		{
			DateType _SchedDate = SchedDate;
			FSPartnerType _PartnerId = PartnerId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSchedValidSchedDateSp";
				
				appDB.AddCommandParameter(cmd, "SchedDate", _SchedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PartnerId", _PartnerId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
