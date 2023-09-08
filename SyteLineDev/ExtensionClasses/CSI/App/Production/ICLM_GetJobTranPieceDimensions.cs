//PROJECT NAME: Production
//CLASS NAME: ICLM_GetJobTranPieceDimensions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_GetJobTranPieceDimensions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetJobTranPieceDimensionsSp(string Job,
		int? Suffix = null,
		decimal? TransNum = null,
		string Whse = null,
		string Location = null,
		string Lot = null,
		string FilterString = null);
	}
}

