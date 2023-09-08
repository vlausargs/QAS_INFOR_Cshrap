//PROJECT NAME: Production
//CLASS NAME: DateConvert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IDateConvert
	{
		(int? ReturnCode, DateTime? DateToChange,
		DateTime? ConvertedDate) DateConvertSp(string DatePart,
		int? Number,
		DateTime? DateToChange,
		DateTime? ConvertedDate);
	}
	
	public class DateConvert : IDateConvert
	{
		readonly IApplicationDB appDB;
		
		public DateConvert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? DateToChange,
		DateTime? ConvertedDate) DateConvertSp(string DatePart,
		int? Number,
		DateTime? DateToChange,
		DateTime? ConvertedDate)
		{
			StringType _DatePart = DatePart;
			GenericNoType _Number = Number;
			GenericDateType _DateToChange = DateToChange;
			GenericDateType _ConvertedDate = ConvertedDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DateConvertSp";
				
				appDB.AddCommandParameter(cmd, "DatePart", _DatePart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Number", _Number, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateToChange", _DateToChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConvertedDate", _ConvertedDate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DateToChange = _DateToChange;
				ConvertedDate = _ConvertedDate;
				
				return (Severity, DateToChange, ConvertedDate);
			}
		}
	}
}
