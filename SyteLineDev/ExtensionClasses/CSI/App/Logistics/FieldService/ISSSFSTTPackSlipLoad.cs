//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSTTPackSlipLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSTTPackSlipLoad
	{
		ICollectionLoadResponse SSSFSTTPackSlipLoadFn();
	}
}

