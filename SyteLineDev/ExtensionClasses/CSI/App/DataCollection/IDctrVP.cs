//PROJECT NAME: DataCollection
//CLASS NAME: IDctrVP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctrVP
	{
		(int? ReturnCode,
			decimal? TQtyHand,
			string Infobar) DctrVPSp(
			string PWhse,
			string PItem,
			string PLoc,
			string PLot,
			string PLocType,
			decimal? TQtyHand,
			string Infobar,
			string Site = null);
	}
}

