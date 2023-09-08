//PROJECT NAME: Admin
//CLASS NAME: ISumJourFix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ISumJourFix
	{
		(int? ReturnCode, string Infobar) SumJourFixSp(string Id,
		DateTime? PSDate = null,
		DateTime? PEDate = null,
		string Infobar = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null);
	}
}

