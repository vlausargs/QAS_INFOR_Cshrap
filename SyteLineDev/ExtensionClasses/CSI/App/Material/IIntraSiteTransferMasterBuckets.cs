//PROJECT NAME: Material
//CLASS NAME: IIntraSiteTransferMasterBuckets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IIntraSiteTransferMasterBuckets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) IntraSiteTransferMasterBucketsSp(string Whse,
		string Item,
		string FilterString = null);
	}
}

