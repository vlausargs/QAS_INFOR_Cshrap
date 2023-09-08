//PROJECT NAME: Logistics
//CLASS NAME: IEftFileCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IEftFileCreate
	{
		(int? ReturnCode, Guid? GUID,
		string Infobar) EftFileCreateSp(string EFTFile,
		string NoteDesc,
		byte[] NoteContentFile,
		int? Status,
		Guid? GUID,
		string Infobar);
	}
}

