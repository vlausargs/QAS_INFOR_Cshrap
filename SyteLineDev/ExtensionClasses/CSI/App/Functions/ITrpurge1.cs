//PROJECT NAME: Data
//CLASS NAME: ITrpurge1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrpurge1
	{
		(int? ReturnCode,
			int? Counter,
			string Infobar) Trpurge1Sp(
			string BegTrnNum,
			string EndTrnNum,
			string BegFromWhse,
			string EndFromWhse,
			string BegToWhse,
			string EndToWhse,
			string Site,
			int? Counter,
			DateTime? OrderDateStarting,
			DateTime? OrderDateEnding,
			string Infobar);
	}
}

