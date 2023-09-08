//PROJECT NAME: Production
//CLASS NAME: ApsItemLeadTime.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsItemLeadTime : IApsItemLeadTime
	{
		readonly IApplicationDB appDB;
		
		public ApsItemLeadTime(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsItemLeadTimeFn(
			string pItem)
		{
			ItemType _pItem = pItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsItemLeadTime](@pItem)";
				
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
