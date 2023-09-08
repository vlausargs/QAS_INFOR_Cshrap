//PROJECT NAME: Production
//CLASS NAME: IRSQC_CalculateCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CalculateCost
	{
		int? RSQC_CalculateCostSp(
			string i_num);
	}
}

