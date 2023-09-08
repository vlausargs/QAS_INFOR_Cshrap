//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContSROGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContSROGen
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SSSFSContSROGenSp(string StartContract,
		string EndContract,
		string StartCustNum,
		string EndCustNum,
		DateTime? ThroughDate,
		int? CreateSROs,
		int? ThroughDateOffset = null,
		string pSite = null);
	}
}

