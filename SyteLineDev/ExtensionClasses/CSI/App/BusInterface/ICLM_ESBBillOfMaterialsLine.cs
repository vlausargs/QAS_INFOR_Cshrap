//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBBillOfMaterialsLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBBillOfMaterialsLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBBillOfMaterialsLineSp(string Job,
		int? Suffix);
	}
}

