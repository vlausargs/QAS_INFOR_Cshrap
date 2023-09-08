//PROJECT NAME: Codes
//CLASS NAME: ConvDateWithFormatNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class ConvDateWithFormatNumber : IConvDateWithFormatNumber
	{
		readonly IApplicationDB appDB;
		
		
		public ConvDateWithFormatNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? rDate) ConvDateWithFormatNumberSp(int? pDateFormatNumber,
		string pDate,
		DateTime? rDate)
		{
			ByteType _pDateFormatNumber = pDateFormatNumber;
			StringType _pDate = pDate;
			DateType _rDate = rDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ConvDateWithFormatNumberSp";
				
				appDB.AddCommandParameter(cmd, "pDateFormatNumber", _pDateFormatNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDate", _pDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rDate", _rDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rDate = _rDate;
				
				return (Severity, rDate);
			}
		}
		public string ConvDateWithFormatNumberFn(
			int? pDateFormatNumber,
			string pDate)
		{
			ByteType _pDateFormatNumber = pDateFormatNumber;
			StringType _pDate = pDate;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvDateWithFormatNumber](@pDateFormatNumber, @pDate)";

				appDB.AddCommandParameter(cmd, "pDateFormatNumber", _pDateFormatNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDate", _pDate, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}

	}
}
