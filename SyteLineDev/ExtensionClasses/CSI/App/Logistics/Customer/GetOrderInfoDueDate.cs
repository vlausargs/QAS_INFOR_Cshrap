//PROJECT NAME: Logistics
//CLASS NAME: GetOrderInfoDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetOrderInfoDueDate : IGetOrderInfoDueDate
	{
		readonly IApplicationDB appDB;
		
		public GetOrderInfoDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetOrderInfoDueDateFn(
			string OrdType,
			string OrdNum,
			int? OrdLine,
			int? OrdRelease,
			string Site = null)
		{
			RefTypeIKOTType _OrdType = OrdType;
			CoProjTrnNumType _OrdNum = OrdNum;
			CoProjTaskTrnLineType _OrdLine = OrdLine;
			CoReleaseType _OrdRelease = OrdRelease;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetOrderInfoDueDate](@OrdType, @OrdNum, @OrdLine, @OrdRelease, @Site)";
				
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdNum", _OrdNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdLine", _OrdLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdRelease", _OrdRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
