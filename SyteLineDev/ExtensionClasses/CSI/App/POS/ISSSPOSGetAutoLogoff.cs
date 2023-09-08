//PROJECT NAME: POS
//CLASS NAME: ISSSPOSGetAutoLogoff.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSGetAutoLogoff
	{
		(int? ReturnCode,
		int? AutoLogoff) SSSPOSGetAutoLogoffSp(
			int? AutoLogoff);
	}
}

