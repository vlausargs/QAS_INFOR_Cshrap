//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIPOSPaymentAmtValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIPOSPaymentAmtValid
	{
		(int? ReturnCode,
			decimal? Amount,
			string Infobar) EXTSSSCCIPOSPaymentAmtValidSp(
			decimal? GatewayTransNum,
			decimal? Amount,
			string Infobar);
	}
}

