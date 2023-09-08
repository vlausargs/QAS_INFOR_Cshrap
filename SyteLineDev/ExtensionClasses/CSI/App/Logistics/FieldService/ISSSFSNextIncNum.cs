//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextIncNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextIncNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextIncNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

