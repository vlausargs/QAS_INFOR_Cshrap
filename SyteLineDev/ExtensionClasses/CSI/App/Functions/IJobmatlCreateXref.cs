//PROJECT NAME: Data
//CLASS NAME: IJobmatlCreateXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobmatlCreateXref
	{
		(int? ReturnCode,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string Infobar) JobmatlCreateXrefSp(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PPoChangeOrd,
			string PAction,
			string Infobar,
			string ExportType);
	}
}

