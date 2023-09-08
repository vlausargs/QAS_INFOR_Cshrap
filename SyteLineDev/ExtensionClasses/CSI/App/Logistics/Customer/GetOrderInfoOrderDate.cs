//PROJECT NAME: Logistics
//CLASS NAME: GetOrderInfoOrderDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderInfoOrderDate : IGetOrderInfoOrderDate
	{
		readonly IApplicationDB appDB;
		
		public GetOrderInfoOrderDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetOrderInfoOrderDateFn(
			string OrdType,
			string OrdNum,
			int? OrdLine)
		{
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _OrdNum = OrdNum;
			CoProjTaskTrnLineType _OrdLine = OrdLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderInfoOrderDate](@OrdType, @OrdNum, @OrdLine)";
				
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLine", _OrdLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
