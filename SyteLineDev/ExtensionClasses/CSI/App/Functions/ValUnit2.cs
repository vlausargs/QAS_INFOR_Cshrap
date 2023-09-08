//PROJECT NAME: Data
//CLASS NAME: ValUnit2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValUnit2 : IValUnit2
	{
		readonly IApplicationDB appDB;
		
		public ValUnit2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ValUnit2Fn(
			string Acct,
			string UnitCode2,
			string Site = null)
		{
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode2 = UnitCode2;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ValUnit2](@Acct, @UnitCode2, @Site)";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode2", _UnitCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
