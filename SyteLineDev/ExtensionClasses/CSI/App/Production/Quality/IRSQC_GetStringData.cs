//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetStringData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetStringData
	{
		(int? ReturnCode,
			string o_text) RSQC_GetStringDataSp(
			string i_string,
			string o_text);
	}
}

