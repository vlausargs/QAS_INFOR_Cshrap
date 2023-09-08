//PROJECT NAME: POS
//CLASS NAME: ISSSPOSSerialClear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSSerialClear
	{
		int? SSSPOSSerialClearSp(string POSNum,
		int? TransNum,
		string Item);
	}
}

