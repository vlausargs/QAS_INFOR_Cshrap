//PROJECT NAME: Data
//CLASS NAME: IDomCrol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomCrol
	{
		int? DomCrolSp(
			Guid? InRecid,
			int? TUseStandard);
	}
}

