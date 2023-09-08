//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSRebalItemAllocToOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSRebalItemAllocToOrder
	{
		(int? ReturnCode,
			int? CoitemCount,
			string Infobar) EXTSSSFSRebalItemAllocToOrderSp(
			int? CoitemCount,
			string Infobar);
	}
}

