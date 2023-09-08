//PROJECT NAME: Logistics
//CLASS NAME: IClearAppmtChecksToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IClearAppmtChecksToPrintPost
	{
		int? ClearAppmtChecksToPrintPostSp(Guid? PSessionID = null);
	}
}

