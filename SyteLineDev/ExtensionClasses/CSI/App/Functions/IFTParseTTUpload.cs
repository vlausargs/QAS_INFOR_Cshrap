//PROJECT NAME: Data
//CLASS NAME: IFTParseTTUpload.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTParseTTUpload
	{
		(int? ReturnCode,
			string Infobar) FTParseTTUploadSp(
			Guid? SessionID,
			string ERPString,
			string Infobar);
	}
}

