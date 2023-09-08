//PROJECT NAME: Data
//CLASS NAME: GetSlsmanName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSlsmanName : IGetSlsmanName
	{
		readonly IApplicationDB appDB;
		
		public GetSlsmanName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetSlsmanNameSp(
			string Slsman)
		{
			SlsmanType _Slsman = Slsman;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetSlsmanNameSp](@Slsman)";
				
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
