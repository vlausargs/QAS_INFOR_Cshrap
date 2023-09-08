//PROJECT NAME: Data
//CLASS NAME: INextCust.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextCust
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextCustSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

