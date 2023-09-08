//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBPerson.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBPerson
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBPersonSp(string slsman);
	}
}

