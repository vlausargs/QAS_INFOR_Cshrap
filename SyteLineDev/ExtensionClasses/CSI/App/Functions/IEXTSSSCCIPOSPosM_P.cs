//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIPOSPosM_P.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIPOSPosM_P
	{
		(int? ReturnCode,
			string Infobar) EXTSSSCCIPOSPosM_PSp(
			string POSNum,
			string InvNum,
			string Infobar);
	}
}

