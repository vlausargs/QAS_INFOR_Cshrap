//PROJECT NAME: Data
//CLASS NAME: INextEst.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextEst
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextEstSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

