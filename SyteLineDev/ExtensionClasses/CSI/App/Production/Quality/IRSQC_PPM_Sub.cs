//PROJECT NAME: Production
//CLASS NAME: IRSQC_PPM_Sub.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_PPM_Sub
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_PPM_SubSp(
			string sortby,
			string begitem,
			string enditem,
			string begvend,
			string endvend,
			DateTime? firstbegdate,
			DateTime? lastenddate,
			DateTime? rptbegdate,
			DateTime? rptenddate);
	}
}

