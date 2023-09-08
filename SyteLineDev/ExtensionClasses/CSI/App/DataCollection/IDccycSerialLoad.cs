//PROJECT NAME: DataCollection
//CLASS NAME: IDccycSerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDccycSerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DccycSerialLoadSp(int? GenSer,
		string SerialLike,
		int? TransNum,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null);
	}
}

