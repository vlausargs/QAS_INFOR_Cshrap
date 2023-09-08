//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPATTSaveEvent.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPATTSaveEvent
	{
		(int? ReturnCode,
			string Infobar) SSSFSPATTSaveEventSp(
			Guid? MsgRowPointer,
			string FormName,
			string SentTo,
			string CC,
			string BCC,
			string Subject,
			string Body,
			string ATTList,
			string Infobar);
	}
}

