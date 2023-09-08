//PROJECT NAME: Data
//CLASS NAME: ICheckImportDocExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckImportDocExists
	{
		(int? ReturnCode,
			string Infobar) CheckImportDocExistsSp(
			string Item,
			string ImportDocId,
			string Infobar);
	}
}

