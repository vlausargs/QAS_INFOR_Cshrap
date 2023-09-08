//PROJECT NAME: Production
//CLASS NAME: IAutonomInvMs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IAutonomInvMs
	{
		(int? ReturnCode, int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar) AutonomInvMsSp(string InProjNum,
		string InMsNum,
		int? CanBeNom,
		DateTime? NomDate,
		int? TReq,
		int? PNotProcess,
		string Infobar);
	}
}

