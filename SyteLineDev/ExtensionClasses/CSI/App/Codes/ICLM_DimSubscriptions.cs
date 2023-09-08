//PROJECT NAME: Codes
//CLASS NAME: ICLM_DimSubscriptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_DimSubscriptions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimSubscriptionsSp(string ObjectName);
	}
}

