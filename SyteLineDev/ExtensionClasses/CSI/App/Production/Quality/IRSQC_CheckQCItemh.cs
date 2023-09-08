//PROJECT NAME: Production
//CLASS NAME: IRSQC_CheckQCItemh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CheckQCItemh
	{
		(int? ReturnCode, int? Status,
		string Infobar) RSQC_CheckQCItemhSp(string Item,
		string RefType,
		string Entity,
		int? TestSeq,
		int? Status,
		string Infobar);
	}
}

