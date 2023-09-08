//PROJECT NAME: Data
//CLASS NAME: CanDo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CanDo : ICanDo
	{
		readonly IApplicationDB appDB;
		
		public CanDo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CanDoSp(
			string Type,
			string Interface)
		{
			LongList _Type = Type;
			LongList _Interface = Interface;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CanDoSp](@Type, @Interface)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Interface", _Interface, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
