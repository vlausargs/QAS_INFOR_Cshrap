//PROJECT NAME: Reporting
//CLASS NAME: ISSSFSRpt_SROInspection.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ISSSFSRpt_SROInspection
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_SROInspectionSp(string StartSroNum = null,
		string EndSroNum = null,
		int? StartSroLine = null,
		int? EndSroLine = null,
		string StartInspectType = null,
		string EndInspectType = null,
		string StartLineSerNum = null,
		string EndLineSerNum = null,
		string StartLineItem = null,
		string EndLineItem = null,
		string StartSerNum = null,
		string EndSerNum = null,
		string StartItem = null,
		string EndItem = null,
		string StartPartner = null,
		string EndPartner = null,
		DateTime? StartInspDate = null,
		DateTime? EndInspDate = null,
		int? PrintSRONotes = 0,
		int? PrintSROLineNotes = 0,
		int? PrintInspNotes = 0,
		int? PrintInternalNotes = 0,
		int? PrintExternalNotes = 0,
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

