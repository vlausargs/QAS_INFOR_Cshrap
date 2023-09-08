//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContactLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContactLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSContactLoadSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string ContactName);

		ICollectionLoadResponse SSSFSContactLoadFn(
			string CustNum,
			int? CustSeq,
			string UsrNum,
			int? UsrSeq,
			string ContactName);
	}
}

