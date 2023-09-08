//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextSRONum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextSRONum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextSRONumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

