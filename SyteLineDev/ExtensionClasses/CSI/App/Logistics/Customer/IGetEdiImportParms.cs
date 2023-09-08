//PROJECT NAME: Logistics
//CLASS NAME: IGetEdiImportParms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetEdiImportParms
	{
		(int? ReturnCode, string SupTpCode,
		string SupIbDataDir,
		string SupIbArchiveDir,
		string SupEdiLogDir,
		string TpCode,
		string IbDataDir,
		string IbArchiveDir,
		string EdiLogDir,
		string ArchiveFileExt) GetEdiImportParmsSp(string SupTpCode,
		string SupIbDataDir,
		string SupIbArchiveDir,
		string SupEdiLogDir,
		string TpCode,
		string IbDataDir,
		string IbArchiveDir,
		string EdiLogDir,
		string ArchiveFileExt);
	}
}

