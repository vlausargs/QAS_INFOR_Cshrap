//PROJECT NAME: Material
//CLASS NAME: IDeleteTaxFreeExports.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IDeleteTaxFreeExports
	{
		(int? ReturnCode, string Infobar) DeleteTaxFreeExportsSp(string StartingExportDocId,
		string EndingExportDocId,
		DateTime? CutoffDate,
		int? CutoffDateOffset,
		string Infobar);
	}
}

