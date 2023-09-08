//PROJECT NAME: Data
//CLASS NAME: LeftPad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class LeftPad : ILeftPad
	{
		readonly IApplicationDB appDB;


		public LeftPad(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string LeftPadFn(string String,
		string Char,
		int? Size)
		{
			LongListType _String = String;
			StringType _Char = Char;
			IntType _Size = Size;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LeftPad](@String, @Char, @Size)";

				appDB.AddCommandParameter(cmd, "String", _String, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Char", _Char, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Size", _Size, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
