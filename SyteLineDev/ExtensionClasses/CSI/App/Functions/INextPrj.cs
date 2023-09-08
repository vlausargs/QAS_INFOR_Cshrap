//PROJECT NAME: Data
//CLASS NAME: INextPrj.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextPrj
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextPrjSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

