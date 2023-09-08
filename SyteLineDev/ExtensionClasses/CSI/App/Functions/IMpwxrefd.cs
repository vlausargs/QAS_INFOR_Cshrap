//PROJECT NAME: Data
//CLASS NAME: IMpwxrefd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMpwxrefd
	{
		(int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) MpwxrefdSp(
			string PReference,
			string PRefType,
			string PItem,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PRefSeq,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

