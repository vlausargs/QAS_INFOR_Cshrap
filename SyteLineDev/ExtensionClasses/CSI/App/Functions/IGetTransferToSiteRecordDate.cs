//PROJECT NAME: Data
//CLASS NAME: IGetTransferToSiteRecordDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTransferToSiteRecordDate
	{
		(ICollectionLoadResponse Data, int? ReturnCode) GetTransferToSiteRecordDateSp(
			string TrnNum,
			int? TrnLine);
	}
}

