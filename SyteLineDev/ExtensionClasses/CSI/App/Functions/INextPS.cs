//PROJECT NAME: Data
//CLASS NAME: INextPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextPS
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextPSSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

