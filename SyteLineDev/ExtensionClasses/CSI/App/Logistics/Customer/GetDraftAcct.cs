//PROJECT NAME: CSICustomer
//CLASS NAME: GetDraftAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetDraftAcct
	{
		int GetDraftAcctSp(ref string DraftRecvAcct,
		                   ref string DraftRecvUnit1,
		                   ref string DraftRecvUnit2,
		                   ref string DraftRecvUnit3,
		                   ref string DraftRecvUnit4,
		                   ref string DraftRecvDesc);
	}
	
	public class GetDraftAcct : IGetDraftAcct
	{
		readonly IApplicationDB appDB;
		
		public GetDraftAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetDraftAcctSp(ref string DraftRecvAcct,
		                          ref string DraftRecvUnit1,
		                          ref string DraftRecvUnit2,
		                          ref string DraftRecvUnit3,
		                          ref string DraftRecvUnit4,
		                          ref string DraftRecvDesc)
		{
			AcctType _DraftRecvAcct = DraftRecvAcct;
			UnitCode1Type _DraftRecvUnit1 = DraftRecvUnit1;
			UnitCode2Type _DraftRecvUnit2 = DraftRecvUnit2;
			UnitCode3Type _DraftRecvUnit3 = DraftRecvUnit3;
			UnitCode4Type _DraftRecvUnit4 = DraftRecvUnit4;
			DescriptionType _DraftRecvDesc = DraftRecvDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetDraftAcctSp";
				
				appDB.AddCommandParameter(cmd, "DraftRecvAcct", _DraftRecvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DraftRecvUnit1", _DraftRecvUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DraftRecvUnit2", _DraftRecvUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DraftRecvUnit3", _DraftRecvUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DraftRecvUnit4", _DraftRecvUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DraftRecvDesc", _DraftRecvDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DraftRecvAcct = _DraftRecvAcct;
				DraftRecvUnit1 = _DraftRecvUnit1;
				DraftRecvUnit2 = _DraftRecvUnit2;
				DraftRecvUnit3 = _DraftRecvUnit3;
				DraftRecvUnit4 = _DraftRecvUnit4;
				DraftRecvDesc = _DraftRecvDesc;
				
				return Severity;
			}
		}
	}
}
