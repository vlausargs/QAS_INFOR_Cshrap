//PROJECT NAME: Data
//CLASS NAME: ITHAPCGetVendorCurr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAPCGetVendorCurr
	{
		(int? ReturnCode,
			string curr_code,
			decimal? exch_rate) THAPCGetVendorCurrSp(
			string vend_num,
			string curr_code,
			decimal? exch_rate);
	}
}

