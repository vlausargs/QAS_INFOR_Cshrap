//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIPOSReverse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIPOSReverse
	{
		(int? ReturnCode,
			string Infobar) EXTSSSCCIPOSReverseSp(
			string POSNum,
			string InvNum,
			string Infobar);
	}
}

