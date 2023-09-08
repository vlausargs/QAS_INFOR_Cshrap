//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSMultiSiteSroSubCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSMultiSiteSroSubCopy
	{
		(int? ReturnCode,
			string Infobar) SSSFSMultiSiteSroSubCopySp(
			string iFromSite,
			string iToSite,
			string iFromSroNum,
			string iToSroNum,
			int? iCloseSourceSro,
			int? iDeleteSourceSro,
			int? iCopyNotes,
			string iValSroType,
			string iValSlsman,
			string iValPartner,
			string iValOperCode,
			string Infobar);
	}
}

