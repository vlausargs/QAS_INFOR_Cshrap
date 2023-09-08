//PROJECT NAME: Production
//CLASS NAME: IProcessBOMImportBuilder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IProcessBOMImportBuilder
	{
		(int? ReturnCode, string PrJob,
		int? PrSuffix,
		string PrItem,
		string Infobar) ProcessBOMImportBuilderSp(Guid? ProcessId,
		string ParentItem,
		string ParentItemDescription,
		string ParentUM,
		string ParentRevision,
		string ParentSource,
		string ParentProductCode,
		string ParentMatlType,
		string PrCategory,
		string PrJob,
		int? PrSuffix,
		string PrSchedId,
		string PrItem,
		DateTime? PrRelease,
		string Infobar,
		string PrAlternateID);
	}
}

