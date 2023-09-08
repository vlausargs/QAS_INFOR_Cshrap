//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_Opportunity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_Opportunity
	{
		(int? ReturnCode, int? OppCount, int? OppAmount) Homepage_OpportunitySp(int? DaysBefore = 30,
		string CustNumProspectId = null,
		string Type = "Customer",
		int? OppCount = null,
		int? OppAmount = null);
	}
	
	public class Homepage_Opportunity : IHomepage_Opportunity
	{
		readonly IApplicationDB appDB;
		
		public Homepage_Opportunity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? OppCount, int? OppAmount) Homepage_OpportunitySp(int? DaysBefore = 30,
		string CustNumProspectId = null,
		string Type = "Customer",
		int? OppCount = null,
		int? OppAmount = null)
		{
			IntType _DaysBefore = DaysBefore;
			CustNumType _CustNumProspectId = CustNumProspectId;
			StringType _Type = Type;
			IntType _OppCount = OppCount;
			IntType _OppAmount = OppAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_OpportunitySp";
				
				appDB.AddCommandParameter(cmd, "DaysBefore", _DaysBefore, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNumProspectId", _CustNumProspectId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OppCount", _OppCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OppAmount", _OppAmount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OppCount = _OppCount;
				OppAmount = _OppAmount;
				
				return (Severity, OppCount, OppAmount);
			}
		}
	}
}
