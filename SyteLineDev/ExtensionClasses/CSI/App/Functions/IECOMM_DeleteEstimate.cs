//PROJECT NAME: Data
//CLASS NAME: IECOMM_DeleteEstimate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IECOMM_DeleteEstimate
	{
		int? ECOMM_DeleteEstimateSp(
			string CoNum);
	}
}

