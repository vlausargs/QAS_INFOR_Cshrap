//PROJECT NAME: Data
//CLASS NAME: INextArImportMap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextArImportMap
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextArImportMapSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

