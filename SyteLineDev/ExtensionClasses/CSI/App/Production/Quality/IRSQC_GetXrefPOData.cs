//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefPOData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefPOData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefPODataSp(string i_po,
		string o_desc,
		string Infobar);
	}
}

