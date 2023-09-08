//PROJECT NAME: Reporting
//CLASS NAME: ITHARpt_Attachment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ITHARpt_Attachment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) THARpt_AttachmentSp(string pSite = null);
	}
}

