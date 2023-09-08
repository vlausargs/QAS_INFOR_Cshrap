//PROJECT NAME: Config
//CLASS NAME: ILoadProcessEQLinePost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ILoadProcessEQLinePost
	{
		(int? ReturnCode,
			string Infobar) LoadProcessEQLinePostSp(
			string ExternalConfirmationRef,
			string CEP,
			string Infobar);
	}
}

