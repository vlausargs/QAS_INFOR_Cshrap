//PROJECT NAME: Production
//CLASS NAME: IRSQC_COCTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_COCTests
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_COCTestsSp(
			int? i_num);
	}
}

