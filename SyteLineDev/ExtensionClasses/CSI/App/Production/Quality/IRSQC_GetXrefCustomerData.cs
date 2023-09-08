//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetXrefCustomerData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetXrefCustomerData
	{
		(int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefCustomerDataSp(string i_custnum,
		int? i_custseq,
		string o_desc,
		string Infobar);
	}
}

