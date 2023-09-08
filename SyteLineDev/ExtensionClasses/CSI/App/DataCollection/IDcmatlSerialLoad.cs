//PROJECT NAME: DataCollection
//CLASS NAME: IDcmatlSerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmatlSerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcmatlSerialLoadSp(int? GenSer,
		string TransType,
		decimal? GenQty,
		string SerialPrefix,
		string SerialLike,
		int? TransNum,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null);
	}
}

