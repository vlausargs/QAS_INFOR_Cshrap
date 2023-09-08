//PROJECT NAME: Data
//CLASS NAME: FormatDecimalAsString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatDecimalAsString : IFormatDecimalAsString
	{
		readonly IApplicationDB appDB;
		
		public FormatDecimalAsString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatDecimalAsStringFn(
			decimal? DecimalAmount,
			int? DecimalPlaces)
		{
			DecimalType _DecimalAmount = DecimalAmount;
			DecimalPlacesType _DecimalPlaces = DecimalPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatDecimalAsString](@DecimalAmount, @DecimalPlaces)";
				
				appDB.AddCommandParameter(cmd, "DecimalAmount", _DecimalAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecimalPlaces", _DecimalPlaces, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
