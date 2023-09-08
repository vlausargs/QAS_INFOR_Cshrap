//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitCopy
	{
		int? SSSFSUnitCopySp(
			string iCopyToSerNum,
			string iCopyFromSerNum,
			int? iAppend = 0,
			int? iParentID = null,
			string iCopyFromItem = null,
			string iCopyToItem = null,
			DateTime? iInstallDate = null);
	}
}

