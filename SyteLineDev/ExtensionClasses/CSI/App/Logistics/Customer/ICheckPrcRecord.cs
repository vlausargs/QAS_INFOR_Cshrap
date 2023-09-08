//PROJECT NAME: Logistics
//CLASS NAME: ICheckPrcRecord.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckPrcRecord
	{
		(int? ReturnCode, string Infobar) CheckPrcRecordSp(string item,
		string Infobar);
	}
}

