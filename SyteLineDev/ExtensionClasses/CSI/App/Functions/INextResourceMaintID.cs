//PROJECT NAME: Data
//CLASS NAME: INextResourceMaintID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INextResourceMaintID
	{
		(int? ReturnCode,
			string Key,
			string Infobar) NextResourceMaintIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar,
			string RESID = null);
	}
}

