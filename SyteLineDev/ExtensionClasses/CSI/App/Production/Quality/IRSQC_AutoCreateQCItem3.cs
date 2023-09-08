//PROJECT NAME: Production
//CLASS NAME: IRSQC_AutoCreateQCItem3.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_AutoCreateQCItem3
	{
		(int? ReturnCode,
			string Infobar) RSQC_AutoCreateQCItem3Sp(
			string i_po,
			int? i_line,
			string Infobar);
	}
}

