//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetNextSRONum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetNextSRONum
	{
		(int? ReturnCode,
			string NextSRONum,
			string Infobar) SSSPOSGetNextSRONumSp(
			string NextSRONum,
			string Infobar);
	}
}

