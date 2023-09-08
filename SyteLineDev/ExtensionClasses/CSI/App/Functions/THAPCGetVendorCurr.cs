//PROJECT NAME: Data
//CLASS NAME: THAPCGetVendorCurr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class THAPCGetVendorCurr : ITHAPCGetVendorCurr
	{
		readonly IApplicationDB appDB;
		
		public THAPCGetVendorCurr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string curr_code,
			decimal? exch_rate) THAPCGetVendorCurrSp(
			string vend_num,
			string curr_code,
			decimal? exch_rate)
		{
			VendNumType _vend_num = vend_num;
			CurrCodeType _curr_code = curr_code;
			ExchRateType _exch_rate = exch_rate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "THAPCGetVendorCurr";
				
				appDB.AddCommandParameter(cmd, "vend_num", _vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "curr_code", _curr_code, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "exch_rate", _exch_rate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				curr_code = _curr_code;
				exch_rate = _exch_rate;
				
				return (Severity, curr_code, exch_rate);
			}
		}
	}
}
