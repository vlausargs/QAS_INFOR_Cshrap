//PROJECT NAME: Data
//CLASS NAME: IFirmJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFirmJob
	{
		(int? ReturnCode,
			string Infobar,
			int? CheckInsertPermission) FirmJobSp(
			string Item,
			string Job,
			int? Suffix,
			string RefNum,
			int? FromWorkbench,
			DateTime? ReleaseDate = null,
			DateTime? DueDate = null,
			decimal? ReqdQty = 0,
			string RefType = null,
			int? RefLineSuf = 0,
			int? RefRelease = 0,
			int? RefSeq = 0,
			string Whse = null,
			int? CopyCurrentBOM = 0,
			int? CopyIndentedBOM = 0,
			Guid? SessionID = null,
			string Infobar = null,
			int? CheckInsertPermission = null);
	}
}

