//PROJECT NAME: Logistics
//CLASS NAME: GetCCPApproved.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCCPApproved : IGetCCPApproved
	{
		readonly IApplicationDB appDB;
		
		
		public GetCCPApproved(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Approved,
		string Infobar) GetCCPApprovedSp(string CoNum,
		int? Approved,
		string Infobar)
		{
			CoNumType _CoNum = CoNum;
			ListYesNoType _Approved = Approved;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCCPApprovedSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Approved", _Approved, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Approved = _Approved;
				Infobar = _Infobar;
				
				return (Severity, Approved, Infobar);
			}
		}
	}
}
