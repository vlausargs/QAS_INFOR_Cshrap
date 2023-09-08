//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextContract.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextContract
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextContractSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

