//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetVrmaValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetVrmaValues
	{
		(int? ReturnCode, string Infobar) RSQC_SetVrmaValuesSp(int? i_vrma,
		string i_type,
		decimal? i_qty,
		int? qcscrapadjust = 0,
		int? qcreturnadjust = 0,
		int? qcreceiveadjust = 0,
		string Infobar = null);
	}
}

