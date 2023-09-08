//PROJECT NAME: Production
//CLASS NAME: ICLM_Resource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_Resource
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ResourceSp(string Job = null,
		int? Suffix = null,
		int? OperNum = null,
		int? AltNo = null,
		string FilterString = null,
		string Infobar = null);
	}
}

