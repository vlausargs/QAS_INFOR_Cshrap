//PROJECT NAME: Data
//CLASS NAME: IsFixed_All.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsFixed_All : IIsFixed_All
	{
		readonly IApplicationDB appDB;
		
		public IsFixed_All(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsFixed_AllFn(
			string CurrCode,
			string Site = null)
		{
			CurrCodeType _CurrCode = CurrCode;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsFixed_All](@CurrCode, @Site)";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
