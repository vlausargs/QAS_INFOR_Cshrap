//PROJECT NAME: Logistics
//CLASS NAME: UpdateOrderExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateOrderExchRate : IUpdateOrderExchRate
	{
		readonly IApplicationDB appDB;
		
		
		public UpdateOrderExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
		string Infobar) UpdateOrderExchRateSp(string CurrCode,
		DateTime? OrderDate,
		decimal? ExchRate,
		string Infobar)
		{
			CurrCodeType _CurrCode = CurrCode;
			DateType _OrderDate = OrderDate;
			ExchRateType _ExchRate = ExchRate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateOrderExchRateSp";
				
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderDate", _OrderDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}
	}
}
