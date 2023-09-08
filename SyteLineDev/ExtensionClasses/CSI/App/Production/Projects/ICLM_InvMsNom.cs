//PROJECT NAME: Production
//CLASS NAME: ICLM_InvMsNom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface ICLM_InvMsNom
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_InvMsNomSp(
			DateTime? PActDate,
			DateTime? PPlanDate,
			string Filter);
	}
}

