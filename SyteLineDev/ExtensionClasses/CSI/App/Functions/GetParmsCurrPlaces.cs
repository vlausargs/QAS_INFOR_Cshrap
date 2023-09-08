//PROJECT NAME: Data
//CLASS NAME: GetParmsCurrPlaces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetParmsCurrPlaces : IGetParmsCurrPlaces
	{
		readonly IApplicationDB appDB;
		
		public GetParmsCurrPlaces(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetParmsCurrPlacesSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetParmsCurrPlacesSp]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
