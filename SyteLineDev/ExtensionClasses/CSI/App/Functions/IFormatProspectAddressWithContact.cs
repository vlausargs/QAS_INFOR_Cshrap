//PROJECT NAME: Data
//CLASS NAME: IFormatProspectAddressWithContact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFormatProspectAddressWithContact
	{
		string FormatProspectAddressWithContactFn(
			string ProspectId,
			string Contact = null);
	}
}

