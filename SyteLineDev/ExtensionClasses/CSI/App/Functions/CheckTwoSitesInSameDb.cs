//PROJECT NAME: Data
//CLASS NAME: CheckTwoSitesInSameDb.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CheckTwoSitesInSameDb : ICheckTwoSitesInSameDb
	{
		readonly IApplicationDB appDB;
		
		public CheckTwoSitesInSameDb(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CheckTwoSitesInSameDbFn(
			string Site1,
			string Site2)
		{
			SiteType _Site1 = Site1;
			SiteType _Site2 = Site2;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CheckTwoSitesInSameDb](@Site1, @Site2)";
				
				appDB.AddCommandParameter(cmd, "Site1", _Site1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site2", _Site2, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
