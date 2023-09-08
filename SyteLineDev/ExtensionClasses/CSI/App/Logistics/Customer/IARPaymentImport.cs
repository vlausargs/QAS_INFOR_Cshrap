//PROJECT NAME: Logistics
//CLASS NAME: IARPaymentImport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IARPaymentImport
	{
		(int? ReturnCode, string Infobar) ARPaymentImportSp(string MapId,
		string Filename,
		string FileContent,
		int? TaskId,
		string Infobar);
	}
}

