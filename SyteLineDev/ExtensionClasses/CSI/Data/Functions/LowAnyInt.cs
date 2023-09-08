//PROJECT NAME: Data
//CLASS NAME: LowAnyInt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class LowAnyInt : ILowAnyInt
	{
		readonly IApplicationDB appDB;


		public LowAnyInt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public int? LowAnyIntFn(string Type)
		{
			StringType _Type = Type;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LowAnyInt](@Type)";

				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
