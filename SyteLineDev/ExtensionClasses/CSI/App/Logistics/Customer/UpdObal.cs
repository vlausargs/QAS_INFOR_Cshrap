//PROJECT NAME: Logistics
//CLASS NAME: UpdObal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdObal : IUpdObal
	{
		readonly IApplicationDB appDB;
		
		
		public UpdObal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UpdObalSp(string CustNum,
		decimal? Adjust)
		{
			CustNumType _CustNum = CustNum;
			AmountType _Adjust = Adjust;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdObalSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adjust", _Adjust, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
