//PROJECT NAME: DataCollection
//CLASS NAME: IDcmovePost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcmovePost
	{
		(int? ReturnCode, string Infobar) DcmovePostSp(string PType = "M",
		decimal? PQty = null,
		string PItem = null,
		string FromWhse = null,
		string FromLoc = null,
		string FromLot = null,
		string ToWhse = null,
		string ToLoc = null,
		string ToLot = null,
		string SerNumList = null,
		string Infobar = null);
	}
}

