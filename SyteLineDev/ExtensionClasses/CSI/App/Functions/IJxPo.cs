//PROJECT NAME: Data
//CLASS NAME: IJxPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJxPo
	{
		(int? ReturnCode,
			string PAction,
			string Infobar) JxPoSp(
			string PPoNum,
			int? PPoLine,
			int? PPoRelease,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			int? PPoChangeOrd,
			string PAction,
			string Infobar,
			string ExportType);
	}
}

