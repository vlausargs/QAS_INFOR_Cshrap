//PROJECT NAME: Production
//CLASS NAME: IRSQC_CustInspShowDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CustInspShowDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_CustInspShowDetailSp(
			string i_conum,
			int? i_coline,
			int? i_corel);
	}
}

