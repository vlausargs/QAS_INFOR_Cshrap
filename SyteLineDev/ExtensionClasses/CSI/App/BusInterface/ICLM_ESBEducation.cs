//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBEducation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBEducation
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBEducationSp(
			string EmpNum);
	}
}

