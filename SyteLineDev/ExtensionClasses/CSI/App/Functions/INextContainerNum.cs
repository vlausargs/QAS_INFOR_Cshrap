//PROJECT NAME: Data
//CLASS NAME: INextContainerNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextContainerNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextContainerNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

