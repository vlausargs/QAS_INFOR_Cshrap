//PROJECT NAME: Data
//CLASS NAME: INextContactID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextContactID
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextContactIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

