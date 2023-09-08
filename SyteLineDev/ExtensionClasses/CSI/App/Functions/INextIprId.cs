//PROJECT NAME: Data
//CLASS NAME: INextIprId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextIprId
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextIprIdSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

