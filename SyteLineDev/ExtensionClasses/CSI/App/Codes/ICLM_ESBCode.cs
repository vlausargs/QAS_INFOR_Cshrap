//PROJECT NAME: Codes
//CLASS NAME: ICLM_ESBCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_ESBCode
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBCodeSp(string ListID,
		string CodeValue);
	}
}

