//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQLoadHdrVendors.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQLoadHdrVendors
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSRFQLoadHdrVendorsSp(string RfqNum);
	}
}

