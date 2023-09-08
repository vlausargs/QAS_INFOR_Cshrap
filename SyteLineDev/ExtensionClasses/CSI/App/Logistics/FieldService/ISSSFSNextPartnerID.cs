//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextPartnerID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextPartnerID
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextPartnerIDSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

