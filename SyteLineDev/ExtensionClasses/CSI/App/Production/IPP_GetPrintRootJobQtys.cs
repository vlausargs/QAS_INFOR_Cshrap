//PROJECT NAME: Production
//CLASS NAME: IPP_GetPrintRootJobQtys.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPP_GetPrintRootJobQtys
	{
		(int? ReturnCode, decimal? JobQtyReleased,
		decimal? PPJobMinSheetCount,
		string Infobar) PP_GetPrintRootJobQtysSp(string Job,
		int? Suffix,
		decimal? JobQtyReleased,
		decimal? PPJobMinSheetCount,
		string Infobar);
	}
}

