//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSNextConsumerNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSNextConsumerNum
	{
		(int? ReturnCode,
			string Key,
			string Infobar) SSSFSNextConsumerNumSp(
			string Context,
			string Prefix,
			int? KeyLength,
			string Key,
			string Infobar);
	}
}

