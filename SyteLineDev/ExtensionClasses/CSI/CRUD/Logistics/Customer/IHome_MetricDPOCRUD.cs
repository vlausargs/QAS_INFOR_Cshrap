//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricDPOCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricDPOCRUD
	{
		bool Optional_ModuleForExists();
		void Optional_Module1Insert();
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(string ALTGEN_SpName);
		(string Site, int? rowCount) ParmsLoad(string Site);
		void NontableInsert(string Site);
		(string DomCurrCode, int? rowCount) CurrparmsLoad(string DomCurrCode);
		void SitesInsert(string SiteGroup);
		(string DomCurrCode, int? rowCount) Currparms_AllLoad(string DomCurrCode);
		void VendsitevarInsert();
        ICollectionLoadResponse Nontable1Select(DateTime? PerStart, DateTime? PerEnd, int? i, int? PerDays);
        void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
        bool Tv_PeriodsForExists();
		ICollectionLoadResponse Tv_Periods1Select();
		(DateTime? LastDate, int? rowCount) Tv_Periods2Load(DateTime? LastDate);
		void Voucher1Insert(DateTime? CutoffDate, DateTime? LastDate, DateTime? LowDate);
		void Exchrates1Insert();
		ICollectionLoadResponse Exchrates2Select();
		void Exchrates3Update(string ExchRateCurrCode, string ExchRateSite, decimal? ExchRate);
		void Voucher2Update();
		(decimal? APAmt, int? rowCount) Voucher3Load(DateTime? LowDate, decimal? APAmt);
		void Tv_Periods3Update();
		ICollectionLoadResponse Tv_Periods4Select(decimal? APAmt);
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricDPOSp(string AltExtGenSp, int? MultipleSites, string SiteGroup, int? NumPeriods);
	}
}

