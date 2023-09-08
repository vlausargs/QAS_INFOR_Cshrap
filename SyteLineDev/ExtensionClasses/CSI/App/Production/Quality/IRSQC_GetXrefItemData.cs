//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefItemData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefItemData
	{
		(int? ReturnCode,
		string o_desc,
		string Infobar) RSQC_GetXrefItemDataSp(
			string i_item,
			string o_desc,
			string Infobar);
	}
}

