//PROJECT NAME: Logistics
//CLASS NAME: ICLM_LastStagePipeline.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_LastStagePipeline
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LastStagePipelineSp();
	}
}

