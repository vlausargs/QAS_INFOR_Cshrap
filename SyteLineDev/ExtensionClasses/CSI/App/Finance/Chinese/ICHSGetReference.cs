//PROJECT NAME: Finance
//CLASS NAME: ICHSGetReference.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSGetReference
	{
		string CHSGetReferenceFn(
			string Ref);
	}
}

