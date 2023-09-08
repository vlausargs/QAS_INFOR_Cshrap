//PROJECT NAME: Finance
//CLASS NAME: IHome_MetricPaymentComparisonCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IHome_MetricPaymentComparisonCRUD
	{
		bool Optional_ModuleForExists();
        void Optional_ModuleInsertSelect();
        bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(string ALTGEN_SpName);
		ICollectionLoadResponse Site_GroupSelect(string SiteGroup);
		(string DomCurrCode, int? rowCount) Currparms_AllLoad(string Site, string DomCurrCode);
		(string Site, int? rowCount) ParmsLoad(string Site);
		void Artran1Insert(DateTime? PerStart, DateTime? PerEnd, string SiteList);
		ICollectionLoadResponse Artran2Select(string DomCurrCode);
		void Artran3Update(int? Seq, decimal? Amount);
		void Aptrxp1Insert(DateTime? PerStart, DateTime? PerEnd, string SiteList);
		ICollectionLoadResponse Aptrxp2Select(string DomCurrCode);
		void Aptrxp3Update(int? Seq, decimal? Amount);
		(decimal? PeriodPaymentIn1,
			 decimal? PeriodPaymentIn2,
			 decimal? PeriodPaymentIn3,
			 decimal? PeriodPaymentIn4,
			 decimal? PeriodPaymentIn5,
			 decimal? PeriodPaymentIn6, int? rowCount) Artran4Load(DateTime? PeriodStart1, DateTime? PeriodEnd1, DateTime? PeriodStart2, DateTime? PeriodEnd2, DateTime? PeriodStart3, DateTime? PeriodEnd3, DateTime? PeriodStart4, DateTime? PeriodEnd4, DateTime? PeriodStart5, DateTime? PeriodEnd5, DateTime? PeriodStart6, DateTime? PeriodEnd6, decimal? PeriodPaymentIn1, decimal? PeriodPaymentIn2, decimal? PeriodPaymentIn3, decimal? PeriodPaymentIn4, decimal? PeriodPaymentIn5, decimal? PeriodPaymentIn6);
		(decimal? PeriodPaymentOut1,
			 decimal? PeriodPaymentOut2,
			 decimal? PeriodPaymentOut3,
			 decimal? PeriodPaymentOut4,
			 decimal? PeriodPaymentOut5,
			 decimal? PeriodPaymentOut6, int? rowCount) Aptrxp4Load(DateTime? PeriodStart1, DateTime? PeriodEnd1, DateTime? PeriodStart2, DateTime? PeriodEnd2, DateTime? PeriodStart3, DateTime? PeriodEnd3, DateTime? PeriodStart4, DateTime? PeriodEnd4, DateTime? PeriodStart5, DateTime? PeriodEnd5, DateTime? PeriodStart6, DateTime? PeriodEnd6, decimal? PeriodPaymentOut1, decimal? PeriodPaymentOut2, decimal? PeriodPaymentOut3, decimal? PeriodPaymentOut4, decimal? PeriodPaymentOut5, decimal? PeriodPaymentOut6);
		void NontableInsert(decimal? PeriodPaymentIn, decimal? PeriodPaymentOut, DateTime? PeriodEnd);
		ICollectionLoadResponse Tv_ResultsSelect();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricPaymentComparisonSp(string AltExtGenSp, string SiteGroup);
	}
}

