//PROJECT NAME: Data
//CLASS NAME: GetKPICategories.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetKPICategories : IGetKPICategories
	{
		readonly IApplicationDB appDB;
		
		public GetKPICategories(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetKPICategoriesFn(
			int? KPINum)
		{
			WBKPINumType _KPINum = KPINum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetKPICategories](@KPINum)";
				
				appDB.AddCommandParameter(cmd, "KPINum", _KPINum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
