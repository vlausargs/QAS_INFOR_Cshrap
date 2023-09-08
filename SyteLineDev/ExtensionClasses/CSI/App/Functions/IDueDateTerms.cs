//PROJECT NAME: Data
//CLASS NAME: IDueDateTerms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDueDateTerms
	{
		DateTime? DueDateTermsFn(
			DateTime? DueDate,
			string TermsCode);
	}
}

