//PROJECT NAME: Data
//CLASS NAME: IJxTrn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJxTrn
	{
		(int? ReturnCode,
			int? PAsk,
			string PTrnNum,
			int? PTrnLine,
			decimal? POrderQty,
			string PCommand,
			string PromptMsg,
			string Buttons,
			string Infobar) JxTrnSp(
			int? PAsk,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PTrnNum,
			int? PTrnLine,
			decimal? POrderQty,
			string PCommand,
			string PromptMsg,
			string Buttons,
			string Infobar,
			string ExportType);
	}
}

