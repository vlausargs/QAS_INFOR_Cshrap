//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIDefaultCardSystemID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface IPortal_CCIDefaultCardSystemID
	{
		int Portal_CCIDefaultCardSystemIDSp(string CustNum,
		                                    ref string CardSystemId);
	}
	
	public class Portal_CCIDefaultCardSystemID : IPortal_CCIDefaultCardSystemID
	{
		readonly IApplicationDB appDB;
		
		public Portal_CCIDefaultCardSystemID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int Portal_CCIDefaultCardSystemIDSp(string CustNum,
		                                           ref string CardSystemId)
		{
			CustNumType _CustNum = CustNum;
			CCICardSystemIDType _CardSystemId = CardSystemId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Portal_CCIDefaultCardSystemIDSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CardSystemId", _CardSystemId, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CardSystemId = _CardSystemId;
				
				return Severity;
			}
		}
	}
}
