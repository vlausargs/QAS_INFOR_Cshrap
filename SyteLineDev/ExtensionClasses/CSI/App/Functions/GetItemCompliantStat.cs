//PROJECT NAME: Data
//CLASS NAME: GetItemCompliantStat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetItemCompliantStat : IGetItemCompliantStat
	{
		readonly IApplicationDB appDB;
		
		public GetItemCompliantStat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetItemCompliantStatFn(
			string item,
			string ComplianceProgramId)
		{
			ItemType _item = item;
			ComplianceProgramIdType _ComplianceProgramId = ComplianceProgramId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetItemCompliantStat](@item, @ComplianceProgramId)";
				
				appDB.AddCommandParameter(cmd, "item", _item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ComplianceProgramId", _ComplianceProgramId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
