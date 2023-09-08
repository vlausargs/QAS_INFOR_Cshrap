//PROJECT NAME: DataCollection
//CLASS NAME: IDcsfcSerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcsfcSerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcsfcSerialLoadSp(int? GenSer,
		decimal? GenQty,
		string SerialLike,
		int? TransNum,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null);
	}
}

