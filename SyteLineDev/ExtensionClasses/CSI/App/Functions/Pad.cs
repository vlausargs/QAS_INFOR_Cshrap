//PROJECT NAME: Data
//CLASS NAME: Pad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Pad : IPad
	{
		readonly IApplicationDB appDB;
		
		public Pad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string PadFn(
			int? l,
			string s)
		{
			IntType _l = l;
			InfobarType _s = s;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Pad](@l, @s)";
				
				appDB.AddCommandParameter(cmd, "l", _l, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "s", _s, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
