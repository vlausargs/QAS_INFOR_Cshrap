//PROJECT NAME: Employee
//CLASS NAME: ICLM_GetEmpManagerInfoCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_GetEmpManagerInfoCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string EmpNum, int? rowCount) EmployeeLoad(string UserName, string EmpNum);
		ICollectionLoadResponse Employee1Select(string EmpNum);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_CLM_GetEmpManagerInfoSp(string AltExtGenSp, string EmpNum, string UserName);
	}
}

