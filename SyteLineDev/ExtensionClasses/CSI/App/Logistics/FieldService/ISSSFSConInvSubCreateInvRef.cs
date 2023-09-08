//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCreateInvRef.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCreateInvRef
	{
		int? SSSFSConInvSubCreateInvRefSp(
			string Contract,
			string InvNum);
	}
}

