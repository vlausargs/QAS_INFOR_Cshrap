//PROJECT NAME: DataCollection
//CLASS NAME: IDcwcSerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcwcSerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) DcwcSerialLoadSp(int? GenSer,
		string SerialLike,
		int? TransNum,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string Site = null);
	}
}

