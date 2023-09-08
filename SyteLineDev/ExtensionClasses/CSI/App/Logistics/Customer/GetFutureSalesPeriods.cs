//PROJECT NAME: Logistics
//CLASS NAME: GetFutureSalesPeriods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetFutureSalesPeriods : IGetFutureSalesPeriods
	{
		readonly IApplicationDB appDB;
		
		
		public GetFutureSalesPeriods(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, DateTime? FirstPeriodEnd,
		DateTime? SecondPeriodEnd,
		DateTime? ThirdPeriodEnd,
		DateTime? FourthPeriodEnd,
		DateTime? FifthPeriodEnd,
		DateTime? SixthPeriodEnd,
		DateTime? InitialPeriodStart,
		DateTime? SixthPeriodStart) GetFutureSalesPeriodsSp(DateTime? StartDate,
		DateTime? FirstPeriodEnd = null,
		DateTime? SecondPeriodEnd = null,
		DateTime? ThirdPeriodEnd = null,
		DateTime? FourthPeriodEnd = null,
		DateTime? FifthPeriodEnd = null,
		DateTime? SixthPeriodEnd = null,
		DateTime? InitialPeriodStart = null,
		DateTime? SixthPeriodStart = null)
		{
			DateType _StartDate = StartDate;
			DateType _FirstPeriodEnd = FirstPeriodEnd;
			DateType _SecondPeriodEnd = SecondPeriodEnd;
			DateType _ThirdPeriodEnd = ThirdPeriodEnd;
			DateType _FourthPeriodEnd = FourthPeriodEnd;
			DateType _FifthPeriodEnd = FifthPeriodEnd;
			DateType _SixthPeriodEnd = SixthPeriodEnd;
			DateType _InitialPeriodStart = InitialPeriodStart;
			DateType _SixthPeriodStart = SixthPeriodStart;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetFutureSalesPeriodsSp";
				
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstPeriodEnd", _FirstPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SecondPeriodEnd", _SecondPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ThirdPeriodEnd", _ThirdPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FourthPeriodEnd", _FourthPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FifthPeriodEnd", _FifthPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SixthPeriodEnd", _SixthPeriodEnd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InitialPeriodStart", _InitialPeriodStart, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SixthPeriodStart", _SixthPeriodStart, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstPeriodEnd = _FirstPeriodEnd;
				SecondPeriodEnd = _SecondPeriodEnd;
				ThirdPeriodEnd = _ThirdPeriodEnd;
				FourthPeriodEnd = _FourthPeriodEnd;
				FifthPeriodEnd = _FifthPeriodEnd;
				SixthPeriodEnd = _SixthPeriodEnd;
				InitialPeriodStart = _InitialPeriodStart;
				SixthPeriodStart = _SixthPeriodStart;
				
				return (Severity, FirstPeriodEnd, SecondPeriodEnd, ThirdPeriodEnd, FourthPeriodEnd, FifthPeriodEnd, SixthPeriodEnd, InitialPeriodStart, SixthPeriodStart);
			}
		}
	}
}
