//PROJECT NAME: Data
//CLASS NAME: IJobValMixPhantom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobValMixPhantom
	{
		(int? ReturnCode,
			string Infobar) JobValMixPhantomSp(
			int? PCalcVarFromStd,
			int? PTotalize,
			decimal? PJobQtyReleased,
			string PJob,
			int? PSuffix,
			string PItem,
			decimal? PScrapFact,
			int? POperNum,
			string Infobar);
	}
}

