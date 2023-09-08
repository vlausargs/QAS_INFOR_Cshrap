//PROJECT NAME: Data
//CLASS NAME: GetGMTDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetGMTDate : IGetGMTDate
	{
		readonly IApplicationDB appDB;
		
		public GetGMTDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			DateTime? Result1,
			DateTime? Result2,
			DateTime? Result3,
			DateTime? Result4,
			DateTime? Result5,
			DateTime? Result6,
			DateTime? Result7,
			DateTime? Result8,
			DateTime? Result9,
			DateTime? Result10) GetGMTDateSp(
			string Infobar,
			DateTime? Date1,
			DateTime? Result1,
			DateTime? Date2 = null,
			DateTime? Result2 = null,
			DateTime? Date3 = null,
			DateTime? Result3 = null,
			DateTime? Date4 = null,
			DateTime? Result4 = null,
			DateTime? Date5 = null,
			DateTime? Result5 = null,
			DateTime? Date6 = null,
			DateTime? Result6 = null,
			DateTime? Date7 = null,
			DateTime? Result7 = null,
			DateTime? Date8 = null,
			DateTime? Result8 = null,
			DateTime? Date9 = null,
			DateTime? Result9 = null,
			DateTime? Date10 = null,
			DateTime? Result10 = null)
		{
			Infobar _Infobar = Infobar;
			DateTimeType _Date1 = Date1;
			DateTimeType _Result1 = Result1;
			DateTimeType _Date2 = Date2;
			DateTimeType _Result2 = Result2;
			DateTimeType _Date3 = Date3;
			DateTimeType _Result3 = Result3;
			DateTimeType _Date4 = Date4;
			DateTimeType _Result4 = Result4;
			DateTimeType _Date5 = Date5;
			DateTimeType _Result5 = Result5;
			DateTimeType _Date6 = Date6;
			DateTimeType _Result6 = Result6;
			DateTimeType _Date7 = Date7;
			DateTimeType _Result7 = Result7;
			DateTimeType _Date8 = Date8;
			DateTimeType _Result8 = Result8;
			DateTimeType _Date9 = Date9;
			DateTimeType _Result9 = Result9;
			DateTimeType _Date10 = Date10;
			DateTimeType _Result10 = Result10;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetGMTDateSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date1", _Date1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result1", _Result1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date2", _Date2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result2", _Result2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date3", _Date3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result3", _Result3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date4", _Date4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result4", _Result4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date5", _Date5, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result5", _Result5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date6", _Date6, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result6", _Result6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date7", _Date7, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result7", _Result7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date8", _Date8, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result8", _Result8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date9", _Date9, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result9", _Result9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date10", _Date10, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Result10", _Result10, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Result1 = _Result1;
				Result2 = _Result2;
				Result3 = _Result3;
				Result4 = _Result4;
				Result5 = _Result5;
				Result6 = _Result6;
				Result7 = _Result7;
				Result8 = _Result8;
				Result9 = _Result9;
				Result10 = _Result10;
				
				return (Severity, Infobar, Result1, Result2, Result3, Result4, Result5, Result6, Result7, Result8, Result9, Result10);
			}
		}

		public DateTime? GetGMTDateFn(
			DateTime? Date)
		{
			CurrentDateType _Date = Date;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetGMTDate](@Date)";

				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<DateTime?>(cmd);

				return Output;
			}
		}
	}
}
