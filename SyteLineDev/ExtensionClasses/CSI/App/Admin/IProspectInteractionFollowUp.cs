//PROJECT NAME: Admin
//CLASS NAME: IProspectInteractionFollowUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IProspectInteractionFollowUp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProspectInteractionFollowUpSp(DateTime? StartDate,
		DateTime? EndDate,
		string ProspectID,
		string Slsman,
		string SiteRef);
	}
}

