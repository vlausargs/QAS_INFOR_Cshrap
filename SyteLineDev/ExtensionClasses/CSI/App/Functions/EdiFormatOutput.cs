//PROJECT NAME: Data
//CLASS NAME: EdiFormatOutput.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EdiFormatOutput : IEdiFormatOutput
	{
		readonly IApplicationDB appDB;
		
		public EdiFormatOutput(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string EdiFormatOutputFn(
			string Row,
			string String,
			int? Position,
			int? Length)
		{
			InfobarType _Row = Row;
			InfobarType _String = String;
			IntType _Position = Position;
			IntType _Length = Length;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EdiFormatOutput](@Row, @String, @Position, @Length)";
				
				appDB.AddCommandParameter(cmd, "Row", _Row, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "String", _String, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Position", _Position, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Length", _Length, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
