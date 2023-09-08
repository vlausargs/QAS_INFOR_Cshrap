//PROJECT NAME: Logistics
//CLASS NAME: GetOrderInfoExportType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderInfoExportType : IGetOrderInfoExportType
	{
		readonly IApplicationDB appDB;
		
		public GetOrderInfoExportType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetOrderInfoExportTypeFn(
			string OrdType,
			string OrdNum)
		{
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _OrdNum = OrdNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderInfoExportType](@OrdType, @OrdNum)";
				
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
