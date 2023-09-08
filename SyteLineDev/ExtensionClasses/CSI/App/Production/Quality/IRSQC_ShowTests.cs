//PROJECT NAME: Production
//CLASS NAME: IRSQC_ShowTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ShowTests
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowTestsSp(
			string i_num);
	}
}

