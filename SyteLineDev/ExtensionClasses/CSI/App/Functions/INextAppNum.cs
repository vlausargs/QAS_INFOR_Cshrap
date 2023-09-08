//PROJECT NAME: Data
//CLASS NAME: INextAppNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextAppNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextAppNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

