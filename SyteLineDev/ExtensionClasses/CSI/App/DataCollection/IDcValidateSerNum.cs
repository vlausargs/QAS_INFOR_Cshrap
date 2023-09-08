//PROJECT NAME: DataCollection
//CLASS NAME: IDcValidateSerNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDcValidateSerNum
	{
		(int? ReturnCode, int? Completed,
		string Infobar) DcValidateSerNumSp(int? Connected,
		int? PInOut,
		string PType,
		string PWhseType,
		string PItem,
		string PLocation,
		string PLot,
		string PCurWhse,
		string PSerNum,
		decimal? PRsvdInv = 0,
		int? PDuplicate = null,
		int? Completed = null,
		string Infobar = null);
	}
}

