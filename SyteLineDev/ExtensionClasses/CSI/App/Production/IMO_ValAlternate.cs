//PROJECT NAME: Production
//CLASS NAME: IMO_ValAlternate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IMO_ValAlternate
	{
		(int? ReturnCode, string AlternateDescription,
		int? JobSuffix,
		string Infobar) MO_ValAlternateSp(string JobItem,
		string AlternateID,
		string AlternateDescription,
		int? JobSuffix,
		string Infobar);
	}
}

