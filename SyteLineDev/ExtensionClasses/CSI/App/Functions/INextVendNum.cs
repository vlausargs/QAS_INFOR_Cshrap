//PROJECT NAME: Data
//CLASS NAME: INextVendNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextVendNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextVendNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

