//PROJECT NAME: Data
//CLASS NAME: IItemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemValid
	{
		(int? ReturnCode,
			string ItemDesc,
			string Infobar,
			int? Kit) ItemValidSp(
			string Item,
			string Whse,
			string ItemDesc,
			string Infobar,
			string Site = null,
			int? Kit = null);
	}
}

