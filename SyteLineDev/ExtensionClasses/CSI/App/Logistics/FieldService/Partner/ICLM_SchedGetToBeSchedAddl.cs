//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SchedGetToBeSchedAddl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Partner
{
	public interface ICLM_SchedGetToBeSchedAddl
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SchedGetToBeSchedAddlSp(string SroNum = null,
		int? SroLine = null,
		int? SroOper = null,
		int? TransNum = null,
		string IncNum = null);
	}
}

