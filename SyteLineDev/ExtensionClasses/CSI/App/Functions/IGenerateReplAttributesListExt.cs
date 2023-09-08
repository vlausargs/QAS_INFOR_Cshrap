//PROJECT NAME: Data
//CLASS NAME: IGenerateReplAttributesListExt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenerateReplAttributesListExt
	{
		string GenerateReplAttributesListExtFn(
			string BODNoun,
			string BODVerb,
			string DocumentID,
			int? NodeID);
	}
}

