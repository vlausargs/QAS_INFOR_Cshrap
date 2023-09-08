//PROJECT NAME: Data
//CLASS NAME: GetApsOrderType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetApsOrderType : IGetApsOrderType
	{
		readonly IApplicationDB appDB;
		
		public GetApsOrderType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetApsOrderTypeFn(
			string ORDERID)
		{
			StringType _ORDERID = ORDERID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetApsOrderType](@ORDERID)";
				
				appDB.AddCommandParameter(cmd, "ORDERID", _ORDERID, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
