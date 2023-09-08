//PROJECT NAME: Data
//CLASS NAME: IEXTSSSCCIInvPosting.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSCCIInvPosting
	{
		(int? ReturnCode,
			string Infobar) EXTSSSCCIInvPostingSp(
			string InvNum,
			string Infobar);
	}
}

