//PROJECT NAME: Data
//CLASS NAME: IGetItemLotTrack.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetItemLotTrack
	{
		(int? ReturnCode,
			int? TLotTracked,
			string Infobar) GetItemLotTrackSp(
			string PItem,
			string PSite,
			int? TLotTracked,
			string Infobar);
	}
}

