//PROJECT NAME: DataCollection
//CLASS NAME: IDcCycleSetDefaultLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcCycleSetDefaultLoc
	{
		(int? ReturnCode, string TLoc,
		string TLot,
		string Infobar) DcCycleSetDefaultLocSP(string Item,
		string Whse,
		string DCLot,
		string TLoc,
		string TLot,
		string Infobar);
	}
}

