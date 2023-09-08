//PROJECT NAME: Data
//CLASS NAME: IItemChkLow.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemChkLow
	{
		(int? ReturnCode,
			string Infobar) ItemChkLowSp(
			string ChkItem,
			string Infobar);
	}
}

