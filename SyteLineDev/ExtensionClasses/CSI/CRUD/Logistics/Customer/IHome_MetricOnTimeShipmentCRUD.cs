//PROJECT NAME: Logistics
//CLASS NAME: IHome_MetricOnTimeShipmentCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHome_MetricOnTimeShipmentCRUD
	{
		bool Optional_ModuleForExists();
		ICollectionLoadResponse Optional_Module1Select();
		void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
		bool Tv_ALTGENForExists();
		(string ALTGEN_SpName, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName);
		ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
		void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
		(string Site, int? rowCount) ParmsLoad(string Site);
		ICollectionLoadResponse NontableSelect(string Site);
		void NontableInsert(ICollectionLoadResponse nonTableLoadResponse);
		ICollectionLoadResponse SitesSelect(string SiteGroup);
		void SitesInsert(ICollectionLoadResponse sitesLoadResponse);
		ICollectionLoadResponse Tv_CoitemSelect(DateTime? Today, DateTime? PerStart, DateTime? PerEnd);
		void Tv_CoitemInsert(ICollectionLoadResponse tv_coitemLoadResponse);
		(decimal? PeriodTotal1,
			 decimal? PeriodOnTime1,
			 decimal? PeriodTotal2,
			 decimal? PeriodOnTime2,
			 decimal? PeriodTotal3,
			 decimal? PeriodOnTime3,
			 decimal? PeriodTotal4,
			 decimal? PeriodOnTime4,
			 decimal? PeriodTotal5,
			 decimal? PeriodOnTime5,
			 decimal? PeriodTotal6,
			 decimal? PeriodOnTime6,
			 decimal? PeriodTotal7,
			 decimal? PeriodOnTime7,
			 decimal? PeriodTotal8,
			 decimal? PeriodOnTime8,
			 decimal? PeriodTotal9,
			 decimal? PeriodOnTime9,
			 decimal? PeriodTotal10,
			 decimal? PeriodOnTime10, int? rowCount) Tv_Coitem1Load(DateTime? PeriodStart1, DateTime? PeriodEnd1, DateTime? PeriodStart2, DateTime? PeriodEnd2, DateTime? PeriodStart3, DateTime? PeriodEnd3, DateTime? PeriodStart4, DateTime? PeriodEnd4, DateTime? PeriodStart5, DateTime? PeriodEnd5, DateTime? PeriodStart6, DateTime? PeriodEnd6, DateTime? PeriodStart7, DateTime? PeriodEnd7, DateTime? PeriodStart8, DateTime? PeriodEnd8, DateTime? PeriodStart9, DateTime? PeriodEnd9, DateTime? PeriodStart10, DateTime? PeriodEnd10, decimal? PeriodTotal1, decimal? PeriodTotal2, decimal? PeriodTotal3, decimal? PeriodTotal4, decimal? PeriodTotal5, decimal? PeriodTotal6, decimal? PeriodTotal7, decimal? PeriodTotal8, decimal? PeriodTotal9, decimal? PeriodTotal10, decimal? PeriodOnTime1, decimal? PeriodOnTime2, decimal? PeriodOnTime3, decimal? PeriodOnTime4, decimal? PeriodOnTime5, decimal? PeriodOnTime6, decimal? PeriodOnTime7, decimal? PeriodOnTime8, decimal? PeriodOnTime9, decimal? PeriodOnTime10);
		ICollectionLoadResponse Nontable1Select(decimal? PeriodOnTime1, decimal? PeriodTotal1, DateTime? PeriodEnd1);
		void Nontable1Insert(ICollectionLoadResponse nonTable1LoadResponse);
		ICollectionLoadResponse Nontable2Select(decimal? PeriodOnTime2, decimal? PeriodTotal2, DateTime? PeriodEnd2);
		void Nontable2Insert(ICollectionLoadResponse nonTable2LoadResponse);
		ICollectionLoadResponse Nontable3Select(decimal? PeriodOnTime3, decimal? PeriodTotal3, DateTime? PeriodEnd3);
		void Nontable3Insert(ICollectionLoadResponse nonTable3LoadResponse);
		ICollectionLoadResponse Nontable4Select(decimal? PeriodOnTime4, decimal? PeriodTotal4, DateTime? PeriodEnd4);
		void Nontable4Insert(ICollectionLoadResponse nonTable4LoadResponse);
		ICollectionLoadResponse Nontable5Select(decimal? PeriodOnTime5, decimal? PeriodTotal5, DateTime? PeriodEnd5);
		void Nontable5Insert(ICollectionLoadResponse nonTable5LoadResponse);
		ICollectionLoadResponse Nontable6Select(decimal? PeriodOnTime6, decimal? PeriodTotal6, DateTime? PeriodEnd6);
		void Nontable6Insert(ICollectionLoadResponse nonTable6LoadResponse);
		ICollectionLoadResponse Nontable7Select(decimal? PeriodOnTime7, decimal? PeriodTotal7, DateTime? PeriodEnd7);
		void Nontable7Insert(ICollectionLoadResponse nonTable7LoadResponse);
		ICollectionLoadResponse Nontable8Select(decimal? PeriodOnTime8, decimal? PeriodTotal8, DateTime? PeriodEnd8);
		void Nontable8Insert(ICollectionLoadResponse nonTable8LoadResponse);
		ICollectionLoadResponse Nontable9Select(decimal? PeriodOnTime9, decimal? PeriodTotal9, DateTime? PeriodEnd9);
		void Nontable9Insert(ICollectionLoadResponse nonTable9LoadResponse);
		ICollectionLoadResponse Nontable10Select(decimal? PeriodOnTime10, decimal? PeriodTotal10, DateTime? PeriodEnd10);
		void Nontable10Insert(ICollectionLoadResponse nonTable10LoadResponse);
		ICollectionLoadResponse Tv_ResultsSelect();
		(ICollectionLoadResponse Data, int? ReturnCode) AltExtGen_Home_MetricOnTimeShipmentSp(string AltExtGenSp, int? Count, int? MultipleSites, string SiteGroup);
	}
}

