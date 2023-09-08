//PROJECT NAME: Data
//CLASS NAME: DerSlsmanName.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class DerSlsmanName : IDerSlsmanName
	{
		readonly IApplicationDB appDB;

		public DerSlsmanName(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string DerSlsmanNameFn(
			string Slsman)
		{
			SlsmanType _Slsman = Slsman;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DerSlsmanName](@Slsman)";

				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
