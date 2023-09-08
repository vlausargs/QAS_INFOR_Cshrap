//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_TotalWIPValueByAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_TotalWIPValueByAccount
	{
		ICollectionLoadResponse EXTSSSFSRpt_TotalWIPValueByAccountFn(
			string ExBegproductcode,
			string ExEndProductcode,
			string ExBegItem,
			string ExEndItem,
			string SRONumBeg,
			string SRONumEnd,
			string SROOperStatus);
	}
}

