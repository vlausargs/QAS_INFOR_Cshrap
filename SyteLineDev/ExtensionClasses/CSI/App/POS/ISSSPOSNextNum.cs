//PROJECT NAME: POS
//CLASS NAME: ISSSPOSNextNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSNextNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSPOSNextNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

