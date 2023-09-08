//PROJECT NAME: Logistics
//CLASS NAME: IGenerateTHAWHTFile.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGenerateTHAWHTFile
	{
		(int? ReturnCode, string WHTFileName,
		string WHTContent,
		string WHTExportLogicalFolder,
		string Infobar) GenerateTHAWHTFileSp(string THAWHTList,
		string THAWHTSeqList,
		DateTime? LastWHTDate,
		string WHTType,
		string WHTFileName = null,
		string WHTContent = null,
		string WHTExportLogicalFolder = null,
		string Infobar = null);
	}
}

