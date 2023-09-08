//PROJECT NAME: Logistics
//CLASS NAME: GetVendExchRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVendExchRate : IGetVendExchRate
	{
		readonly IApplicationDB appDB;
		
		
		public GetVendExchRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? ExchRate,
		string Infobar) GetVendExchRateSp(string VendNum,
		DateTime? CheckDate,
		string CurrCode,
		decimal? ExchRate,
		string Infobar,
		int? UseBuyRate = 0)
		{
			VendNumType _VendNum = VendNum;
			DateType _CheckDate = CheckDate;
			CurrCodeType _CurrCode = CurrCode;
			ExchRateType _ExchRate = ExchRate;
			Infobar _Infobar = Infobar;
			IntType _UseBuyRate = UseBuyRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendExchRateSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckDate", _CheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseBuyRate", _UseBuyRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExchRate = _ExchRate;
				Infobar = _Infobar;
				
				return (Severity, ExchRate, Infobar);
			}
		}
	}
}
