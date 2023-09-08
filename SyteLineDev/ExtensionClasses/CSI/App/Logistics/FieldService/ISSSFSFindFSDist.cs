//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSFindFSDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSFindFSDist
	{
		Guid? SSSFSFindFSDistFn(
			string ProductCode,
			string Whse);
	}
}

