//PROJECT NAME: Data
//CLASS NAME: INextOpp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextOpp
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextOppSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

