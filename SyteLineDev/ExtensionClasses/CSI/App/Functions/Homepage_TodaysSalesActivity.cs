//PROJECT NAME: Data
//CLASS NAME: Homepage_TodaysSalesActivity.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Homepage_TodaysSalesActivity : IHomepage_TodaysSalesActivity
	{
		readonly IApplicationDB appDB;
		
		public Homepage_TodaysSalesActivity(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? InteractionCount,
			decimal? CloseAmt,
			decimal? OrdersEntered,
			DateTime? Date) Homepage_TodaysSalesActivitySp(
			decimal? InteractionCount,
			decimal? CloseAmt,
			decimal? OrdersEntered,
			DateTime? Date)
		{
			AmountType _InteractionCount = InteractionCount;
			AmountType _CloseAmt = CloseAmt;
			AmountType _OrdersEntered = OrdersEntered;
			DateType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Homepage_TodaysSalesActivitySp";
				
				appDB.AddCommandParameter(cmd, "InteractionCount", _InteractionCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CloseAmt", _CloseAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrdersEntered", _OrdersEntered, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InteractionCount = _InteractionCount;
				CloseAmt = _CloseAmt;
				OrdersEntered = _OrdersEntered;
				Date = _Date;
				
				return (Severity, InteractionCount, CloseAmt, OrdersEntered, Date);
			}
		}
	}
}
