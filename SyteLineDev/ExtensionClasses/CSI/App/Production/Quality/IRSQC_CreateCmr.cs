//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateCmr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateCmr
	{
		(int? ReturnCode, string o_cmr,
		string Infobar) RSQC_CreateCmrSp(int? i_crcvr,
		string i_note,
		string o_cmr,
		string Infobar);
	}
}

