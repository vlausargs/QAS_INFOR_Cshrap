//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBCertification.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBCertification
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBCertificationSp(
			string EmpNum);
	}
}

