//PROJECT NAME: POS
//CLASS NAME: ISSSPOSRpt_PrintSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSRpt_PrintSerial
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSPOSRpt_PrintSerialSp(
			string PosNum,
			int? TransNum,
			string pSite = null);
	}
}

