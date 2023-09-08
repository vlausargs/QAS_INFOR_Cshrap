//PROJECT NAME: Data
//CLASS NAME: IDomSrol.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomSrol
	{
		int? DomSrolSp(
			Guid? InRecid);
	}
}

