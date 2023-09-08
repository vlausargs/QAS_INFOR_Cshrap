//PROJECT NAME: Logistics
//CLASS NAME: GetNextDraftNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetNextDraftNumber : IGetNextDraftNumber
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextDraftNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextDraftNumber) GetNextDraftNumberSp(int? NextDraftNumber)
		{
			DraftNumType _NextDraftNumber = NextDraftNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextDraftNumberSp";
				
				appDB.AddCommandParameter(cmd, "NextDraftNumber", _NextDraftNumber, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextDraftNumber = _NextDraftNumber;
				
				return (Severity, NextDraftNumber);
			}
		}
	}
}
