//PROJECT NAME: Data
//CLASS NAME: SarbRed.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SarbRed : ISarbRed
	{
		readonly IApplicationDB appDB;
		
		public SarbRed(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TPrice,
			decimal? TcQttTotals,
			int? TBkt) SarbRedSp(
			string SaleSumItem,
			DateTime? TDate,
			decimal? TPrice,
			decimal? TcQttTotals,
			int? TBkt,
			DateTime? SaleSumRefDate,
			int? SaleSumRefBkt)
		{
			ItemType _SaleSumItem = SaleSumItem;
			CurrentDateType _TDate = TDate;
			AmountType _TPrice = TPrice;
			AmountType _TcQttTotals = TcQttTotals;
			IntType _TBkt = TBkt;
			DateType _SaleSumRefDate = SaleSumRefDate;
			IntType _SaleSumRefBkt = SaleSumRefBkt;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SarbRedSp";
				
				appDB.AddCommandParameter(cmd, "SaleSumItem", _SaleSumItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TDate", _TDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TPrice", _TPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TcQttTotals", _TcQttTotals, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TBkt", _TBkt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SaleSumRefDate", _SaleSumRefDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SaleSumRefBkt", _SaleSumRefBkt, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TPrice = _TPrice;
				TcQttTotals = _TcQttTotals;
				TBkt = _TBkt;
				
				return (Severity, TPrice, TcQttTotals, TBkt);
			}
		}
	}
}
