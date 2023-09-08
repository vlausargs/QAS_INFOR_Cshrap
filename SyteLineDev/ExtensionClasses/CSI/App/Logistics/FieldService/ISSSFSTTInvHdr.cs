//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTTInvHdr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTTInvHdr
	{
		ICollectionLoadResponse SSSFSTTInvHdrFn();
	}
}

