//PROJECT NAME: Production
//CLASS NAME: IRSQC_Deletetmpser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_Deletetmpser
	{
		(int? ReturnCode, string Infobar) RSQC_DeletetmpserSp(string Infobar);
	}
}

