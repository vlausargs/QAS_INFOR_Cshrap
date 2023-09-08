//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIDefaultCardSystemID_1_ForOrderCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCIDefaultCardSystemID_1_ForOrderCurr
	{
		int Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp(string CustNum,
		                                                   string RefType,
		                                                   string RefNum,
		                                                   ref string CardSystemId);
	}
	
	public class Portal_CCIDefaultCardSystemID_1_ForOrderCurr : IPortal_CCIDefaultCardSystemID_1_ForOrderCurr
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCIDefaultCardSystemID_1_ForOrderCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp(string CustNum,
		                                                          string RefType,
		                                                          string RefNum,
		                                                          ref string CardSystemId)
		{
			CustNumType _CustNum = CustNum;
			CCITransRefTypeType _RefType = RefType;
			InvNumType _RefNum = RefNum;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCIDefaultCardSystemID_1_ForOrderCurrSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CardSystemId = _CardSystemId;
				
				return Severity;
			}
		}
	}
}
