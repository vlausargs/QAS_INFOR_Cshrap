//PROJECT NAME: Data
//CLASS NAME: ITHA_apptcChecksToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHA_apptcChecksToPrintPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THA_apptcChecksToPrintPostSp(
			Guid? PSessionID = null);
	}
}

