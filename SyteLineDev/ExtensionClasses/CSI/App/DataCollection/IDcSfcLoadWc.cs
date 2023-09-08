//PROJECT NAME: DataCollection
//CLASS NAME: IDcSfcLoadWc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcSfcLoadWc
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcSfcLoadWcSp();
	}
}

