//PROJECT NAME: Data
//CLASS NAME: INextLcn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextLcn
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextLcnSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

