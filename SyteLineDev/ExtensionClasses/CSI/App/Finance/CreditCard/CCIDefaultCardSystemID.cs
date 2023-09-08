//PROJECT NAME: CSICCI
//CLASS NAME: CCIDefaultCardSystemID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ICCIDefaultCardSystemID
	{
		int CCIDefaultCardSystemIDSp(string CustNum,
		                             string RefType,
		                             string RefNum,
		                             ref string CardSystemId);
	}
	
	public class CCIDefaultCardSystemID : ICCIDefaultCardSystemID
	{
		readonly IApplicationDB appDB;
		
		public CCIDefaultCardSystemID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CCIDefaultCardSystemIDSp(string CustNum,
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
				cmd.CommandText = "CCIDefaultCardSystemIDSp";
				
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
