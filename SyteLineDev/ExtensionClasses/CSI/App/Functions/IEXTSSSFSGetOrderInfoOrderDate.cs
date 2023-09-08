//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSGetOrderInfoOrderDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSGetOrderInfoOrderDate
	{
		DateTime? EXTSSSFSGetOrderInfoOrderDateFn(
			string OrdNum);
	}
}

