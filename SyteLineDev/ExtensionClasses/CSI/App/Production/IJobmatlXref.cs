//PROJECT NAME: Production
//CLASS NAME: IJobmatlXref.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobmatlXref
	{
		(int? ReturnCode, int? PAsk,
		string PRefNum,
		int? PRefLine,
		int? PRefRelease,
		decimal? POrderQty,
		string PPoType,
		string PCommand,
		string PromptMsg,
		string Buttons,
		string Infobar) JobmatlXrefSp(int? PAsk,
		string PRefType,
		string PJob,
		int? PSuffix,
		int? POperNum,
		int? PSeq,
		string PItem,
		string PRefNum,
		int? PRefLine,
		int? PRefRelease,
		decimal? POrderQty,
		string PPoType,
		string PCommand,
		string PromptMsg,
		string Buttons,
		string Infobar,
		string ExportType);
	}
}

