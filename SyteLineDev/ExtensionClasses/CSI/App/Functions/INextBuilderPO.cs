//PROJECT NAME: Data
//CLASS NAME: INextBuilderPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextBuilderPO
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextBuilderPOSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

