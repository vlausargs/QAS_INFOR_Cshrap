//PROJECT NAME: Production
//CLASS NAME: IRSQC_ItemData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ItemData
	{
		(int? ReturnCode, string i_Description,
		string i_UM,
		int? i_LotTracked,
		int? i_SerialTracked,
		string Infobar) RSQC_ItemDataSp(string i_Item,
		string i_Description,
		string i_UM,
		int? i_LotTracked,
		int? i_SerialTracked,
		string Infobar);
	}
}

