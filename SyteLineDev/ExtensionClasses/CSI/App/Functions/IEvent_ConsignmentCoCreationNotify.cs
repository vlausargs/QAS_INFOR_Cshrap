//PROJECT NAME: Data
//CLASS NAME: IEvent_ConsignmentCoCreationNotify.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEvent_ConsignmentCoCreationNotify
	{
		(int? ReturnCode,
			string Infobar) Event_ConsignmentCoCreationNotifySp(
			string CoNum,
			string PortalUsername,
			string Infobar);
	}
}

