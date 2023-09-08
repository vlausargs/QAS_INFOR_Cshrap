//PROJECT NAME: Material
//CLASS NAME: IValidateRestrictedTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IValidateRestrictedTrans
	{
		(int? ReturnCode, string Infobar) ValidateRestrictedTransSp(string Item = null,
		string Lot = null,
		string SerialNums = null,
		string MatlTransType = null,
		string Infobar = null,
		decimal? RefId = 0,
		string RefType = null,
		Guid? ProcessId = null,
		string Site = null);
	}
}

