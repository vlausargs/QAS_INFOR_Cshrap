//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefFileName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefFileName
	{
		(int? ReturnCode,
			string RefType,
			string Name,
			string Infobar) SSSFSXrefFileNameSp(
			string RefType,
			string Name,
			string Infobar);
	}
}

