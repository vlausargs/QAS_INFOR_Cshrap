//PROJECT NAME: Data
//CLASS NAME: INextCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextCo
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextCoSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

