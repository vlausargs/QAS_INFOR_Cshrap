//PROJECT NAME: Data
//CLASS NAME: IChkDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChkDate
	{
		(int? ReturnCode,
			string PromptMsg,
			string PromptButtons,
			string Infobar) ChkDateSp(
			DateTime? PTransDate,
			string Site,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

