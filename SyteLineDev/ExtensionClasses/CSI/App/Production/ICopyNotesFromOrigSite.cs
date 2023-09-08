//PROJECT NAME: Production
//CLASS NAME: ICopyNotesFromOrigSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyNotesFromOrigSite
	{
		(int? ReturnCode,
			string Infobar) CopyNotesFromOrigSiteSp(
			string CoNum,
			string CoType,
			string SourceSite,
			string Infobar);
	}
}

