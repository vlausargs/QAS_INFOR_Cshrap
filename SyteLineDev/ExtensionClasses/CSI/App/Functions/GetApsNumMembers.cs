//PROJECT NAME: Data
//CLASS NAME: GetApsNumMembers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetApsNumMembers : IGetApsNumMembers
	{
		readonly IApplicationDB appDB;
		
		public GetApsNumMembers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetApsNumMembersFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetApsNumMembers]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
