//PROJECT NAME: Material
//CLASS NAME: IPhyinvLotV1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPhyinvLotV1
	{
		(int? ReturnCode, int? LotEnable,
		string Infobar,
		string Revision) PhyinvLotV1Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		int? LotEnable,
		string Infobar,
		string Revision = null);
	}
}

