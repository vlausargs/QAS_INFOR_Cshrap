//PROJECT NAME: DataCollection
//CLASS NAME: IDctsVP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctsVP
	{
		(int? ReturnCode,
			string Infobar) DctsVPSp(
			Guid? PRecid,
			decimal? PQty,
			string PLot,
			int? PCanAdd,
			string PWhse,
			string PWhseType,
			int? PIssue,
			string PTranType,
			string Infobar,
			string Site = null);
	}
}

