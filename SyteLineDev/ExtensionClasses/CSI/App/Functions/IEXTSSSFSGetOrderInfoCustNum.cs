//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSGetOrderInfoCustNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSGetOrderInfoCustNum
	{
		string EXTSSSFSGetOrderInfoCustNumFn(
			string OrdNum);
	}
}

