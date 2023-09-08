//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBWorkExperiance.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBWorkExperiance
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBWorkExperianceSp(
			string EmpNum);
	}
}

