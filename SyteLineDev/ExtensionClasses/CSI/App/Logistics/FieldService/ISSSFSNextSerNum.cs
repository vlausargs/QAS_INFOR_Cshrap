//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextSerNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextSerNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextSerNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar,
			string Item = null,
			string Site = null);
	}
}

