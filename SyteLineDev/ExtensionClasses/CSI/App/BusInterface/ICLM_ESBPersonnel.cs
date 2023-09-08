//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPersonnel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPersonnel
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPersonnelSp(string EmpNum);
	}
}

