//PROJECT NAME: Data
//CLASS NAME: QuotedLiteral.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
	public class QuotedLiteral : IQuotedLiteral
	{
		readonly IApplicationDB appDB;


		public QuotedLiteral(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string QuotedLiteralFn(string Value)
		{
			VeryLongListType _Value = Value;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[QuotedLiteral](@Value)";

				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
