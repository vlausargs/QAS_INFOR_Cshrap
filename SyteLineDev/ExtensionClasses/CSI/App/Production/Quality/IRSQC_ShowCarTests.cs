//PROJECT NAME: Production
//CLASS NAME: IRSQC_ShowCarTests.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_ShowCarTests
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RSQC_ShowCarTestsSp(
			string i_num);
	}
}

