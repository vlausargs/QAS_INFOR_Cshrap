//PROJECT NAME: Logistics
//CLASS NAME: GetNextDraftNumberWrapper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetNextDraftNumberWrapper : IGetNextDraftNumberWrapper
	{
		readonly IApplicationDB appDB;
		
		
		public GetNextDraftNumberWrapper(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextDraftNumber) GetNextDraftNumberWrapperSp(string Type,
		int? NextDraftNumber)
		{
			ArpmtTypeType _Type = Type;
			DraftNumType _NextDraftNumber = NextDraftNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetNextDraftNumberWrapperSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextDraftNumber", _NextDraftNumber, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextDraftNumber = _NextDraftNumber;
				
				return (Severity, NextDraftNumber);
			}
		}
	}
}
