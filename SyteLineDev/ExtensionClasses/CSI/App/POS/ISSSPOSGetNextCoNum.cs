//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetNextCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetNextCoNum
	{
		(int? ReturnCode,
			string NextCoNum,
			string Infobar) SSSPOSGetNextCoNumSp(
			string NextCoNum,
			string Infobar);
	}
}

