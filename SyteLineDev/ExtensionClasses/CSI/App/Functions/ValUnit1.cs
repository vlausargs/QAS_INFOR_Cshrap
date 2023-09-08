//PROJECT NAME: Data
//CLASS NAME: ValUnit1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValUnit1 : IValUnit1
	{
		readonly IApplicationDB appDB;
		
		public ValUnit1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ValUnit1Fn(
			string Acct,
			string UnitCode1,
			string Site = null)
		{
			AcctType _Acct = Acct;
			UnitCode1Type _UnitCode1 = UnitCode1;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ValUnit1](@Acct, @UnitCode1, @Site)";
				
				appDB.AddCommandParameter(cmd, "Acct", _Acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCode1", _UnitCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
