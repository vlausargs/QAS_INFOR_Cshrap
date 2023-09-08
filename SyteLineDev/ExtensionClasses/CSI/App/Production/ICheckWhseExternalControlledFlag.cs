//PROJECT NAME: Production
//CLASS NAME: ICheckWhseExternalControlledFlag.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckWhseExternalControlledFlag
	{
		(int? ReturnCode,
			string Infobar) CheckWhseExternalControlledFlagSp(
			string PWhse,
			string PSite,
			string Infobar);
	}
}

