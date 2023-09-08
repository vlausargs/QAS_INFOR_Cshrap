//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefProjectData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefProjectData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefProjectDataSp(string i_proj,
		string o_desc,
		string Infobar);
	}
}

