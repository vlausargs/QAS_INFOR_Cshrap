//PROJECT NAME: Admin
//CLASS NAME: ICreatePrivacyUtilityEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface ICreatePrivacyUtilityEsig
	{
		int? CreatePrivacyUtilityEsigSp(Guid? TmpGDPRDataRowpointer,
		string ProcessType);
	}
}

