//PROJECT NAME: Admin
//CLASS NAME: ICLM_GDPRData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICLM_GDPRData
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GDPRDataSP(Guid? ProcessId,
		string Name,
		string Country,
		string DataGroupList);
	}
}

