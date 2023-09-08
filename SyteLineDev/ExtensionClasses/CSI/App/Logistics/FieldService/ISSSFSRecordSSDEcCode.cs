//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSRecordSSDEcCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSRecordSSDEcCode
	{
		(int? ReturnCode,
			string Infobar) SSSFSRecordSSDEcCodeSp(
			Guid? iRowPointer,
			int? iLineTrans,
			string iMode,
			string Infobar);
	}
}

