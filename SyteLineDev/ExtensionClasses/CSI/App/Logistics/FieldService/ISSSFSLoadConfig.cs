//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSLoadConfig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSLoadConfig
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSLoadConfigSp(int? CompId);
	}
}

