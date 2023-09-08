//PROJECT NAME: Data
//CLASS NAME: INextRma.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextRma
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextRmaSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

