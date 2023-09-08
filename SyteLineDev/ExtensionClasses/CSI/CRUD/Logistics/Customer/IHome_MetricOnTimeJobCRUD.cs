//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricOnTimeJobCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricOnTimeJobCRUD
	{
		bool Optional_ModuleForExists();
		void Optional_Module1Insert();
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(string ALTGEN_SpName);
		(string Site, int? rowCount) ParmsLoad(string Site);
		(decimal? PeriodTotal, int? rowCount) JobLoad(DateTime? PeriodStart, DateTime? PeriodEnd, decimal? PeriodTotal);
        (decimal? PeriodOnTime, int? rowCount) Job2Load(DateTime? PeriodStart, DateTime? PeriodEnd, decimal? PeriodOnTime);
		void NontableInsert(decimal? PeriodOnTime1, decimal? PeriodTotal1, DateTime? PeriodEnd1);
		ICollectionLoadResponse Tv_ResultsSelect();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricOnTimeJobSp(string AltExtGenSp, int? Count);
	}
}

