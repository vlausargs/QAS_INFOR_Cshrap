//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTmpSROReimbCleanUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSTmpSROReimbCleanUp
	{
		int? SSSFSTmpSROReimbCleanUpSp(Guid? SessionID);
	}
}

