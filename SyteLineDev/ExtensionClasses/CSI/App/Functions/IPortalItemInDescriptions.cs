//PROJECT NAME: Data
//CLASS NAME: IPortalItemInDescriptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPortalItemInDescriptions
	{
		int? PortalItemInDescriptionsFn(
			Guid? rp,
			string item);
	}
}

