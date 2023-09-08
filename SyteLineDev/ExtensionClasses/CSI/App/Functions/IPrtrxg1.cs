//PROJECT NAME: Data
//CLASS NAME: IPrtrxg1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxg1
	{
		(int? ReturnCode,
			string Infobar) Prtrxg1Sp(
			string SDepartment,
			string EDepartment,
			string SEmployee,
			string EEmployee,
			string PIncPayFreq,
			int? PJobTrx,
			int? PProjTrx,
			int? PTimeAttend,
			int? PSumAttend,
			string PEmplType,
			int? PPrHrs,
			DateTime? PCheckDate,
			string PPrDelWhich,
			string Infobar,
			string PStartEmpCate = null,
			string PEndEmpCate = null,
			int? PPrServiceHours = null);
	}
}

