//PROJECT NAME: Production
//CLASS NAME: ISaveBomIBJobmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISaveBomIBJobmatl
	{
		int? SaveBomIBJobmatlSp(Guid? ProcessId,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		int? Create,
		int? BomSeq,
		string Item,
		string ItemDescription,
		string Revision,
		string ProductCode,
		decimal? MatlQty,
		string UM,
		string Units,
		string PMTCode,
		string MatlType);
	}
}

