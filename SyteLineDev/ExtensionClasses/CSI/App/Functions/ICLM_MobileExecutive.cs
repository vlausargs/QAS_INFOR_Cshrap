//PROJECT NAME: Data
//CLASS NAME: ICLM_MobileExecutive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_MobileExecutive
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_MobileExecutiveSp(
			int? Position);
	}
}

