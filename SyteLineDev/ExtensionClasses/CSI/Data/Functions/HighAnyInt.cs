//PROJECT NAME: Data
//CLASS NAME: HighAnyInt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class HighAnyInt : IHighAnyInt
	{
		readonly IApplicationDB appDB;


		public HighAnyInt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? HighAnyIntFn(string Type)
		{
			StringType _Type = Type;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[HighAnyInt](@Type)";

				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
