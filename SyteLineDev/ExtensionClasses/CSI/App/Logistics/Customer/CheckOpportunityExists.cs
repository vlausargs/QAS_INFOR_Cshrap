//PROJECT NAME: Logistics
//CLASS NAME: CheckOpportunityExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckOpportunityExists : ICheckOpportunityExists
	{
		readonly IApplicationDB appDB;
		
		
		public CheckOpportunityExists(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) CheckOpportunityExistsSp(string OppId,
		string Infobar)
		{
			OpportunityIDType _OppId = OppId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckOpportunityExistsSp";
				
				appDB.AddCommandParameter(cmd, "OppId", _OppId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
