//PROJECT NAME: Employee
//CLASS NAME: IGetApplicantData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IGetApplicantData
	{
		(int? ReturnCode, string app_num,
		string lname,
		string fname,
		string mi,
		string sname,
		string addr_1,
		string addr_2,
		string addr_3,
		string addr_4,
		string city,
		string state,
		string zip,
		string phone,
		string marital_stat,
		string sex,
		DateTime? birth_date,
		string ssn,
		string ethnic_id,
		int? citizen,
		int? handicap,
		string nationality,
		string work_stat,
		string military,
		DateTime? HireDate,
		DateTime? ADate,
		string Infobar) GetApplicantDataSp(string AppNum,
		string app_num,
		string lname,
		string fname,
		string mi,
		string sname,
		string addr_1,
		string addr_2,
		string addr_3,
		string addr_4,
		string city,
		string state,
		string zip,
		string phone,
		string marital_stat,
		string sex,
		DateTime? birth_date,
		string ssn,
		string ethnic_id,
		int? citizen,
		int? handicap,
		string nationality,
		string work_stat,
		string military,
		DateTime? HireDate,
		DateTime? ADate,
		string Infobar);
	}
}

