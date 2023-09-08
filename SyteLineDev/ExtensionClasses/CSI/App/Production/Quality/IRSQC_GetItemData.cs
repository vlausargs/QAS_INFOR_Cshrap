//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetItemData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetItemData
	{
		(int? ReturnCode, string o_UM,
		string o_revision,
		string o_drawing_nbr,
		string Infobar) RSQC_GetItemDataSp(string i_item,
		string o_UM,
		string o_revision,
		string o_drawing_nbr,
		string Infobar);
	}
}

