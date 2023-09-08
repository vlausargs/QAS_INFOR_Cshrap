//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIposmpaymentDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIposmpaymentDel
	{
		(int? ReturnCode,
			string Infobar) EXTSSSCCIposmpaymentDelSp(
			string POSNum,
			decimal? GatewayTransNum,
			string Infobar);
	}
}

