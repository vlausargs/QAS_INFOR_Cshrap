//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConInvSubSelContract.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubSelContract : ISSSFSConInvSubSelContract
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSConInvSubSelContract(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConInvSubSelContractSp(Guid? SessionId,
		string StartContract,
		string EndContract,
		int? StartContLine,
		int? EndContLine,
		string StartCustNum,
		string EndCustNum,
		string StartServType = null,
		string EndServType = null,
		DateTime? RenewByDate = null,
		string BillingFreq = "ASQBMOE")
		{
			RowPointerType _SessionId = SessionId;
			FSContractType _StartContract = StartContract;
			FSContractType _EndContract = EndContract;
			FSContLineType _StartContLine = StartContLine;
			FSContLineType _EndContLine = EndContLine;
			CustNumType _StartCustNum = StartCustNum;
			CustNumType _EndCustNum = EndCustNum;
			FSContServTypeType _StartServType = StartServType;
			FSContServTypeType _EndServType = EndServType;
			DateType _RenewByDate = RenewByDate;
			InfobarType _BillingFreq = BillingFreq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConInvSubSelContractSp";
				
				appDB.AddCommandParameter(cmd, "SessionId", _SessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartContract", _StartContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContract", _EndContract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartContLine", _StartContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndContLine", _EndContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartServType", _StartServType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndServType", _EndServType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RenewByDate", _RenewByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingFreq", _BillingFreq, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
