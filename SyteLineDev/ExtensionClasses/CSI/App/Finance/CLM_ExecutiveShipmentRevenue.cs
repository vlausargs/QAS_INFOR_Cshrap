//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveShipmentRevenue.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Logistics.Vendor;
using CSI.DataCollection;

namespace CSI.Finance
{
	public class CLM_ExecutiveShipmentRevenue : ICLM_ExecutiveShipmentRevenue
	{
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IDateTimeUtil dateTimeUtil;
		readonly IStringUtil stringUtil;
		readonly IRaiseError raiseError;
		readonly IHighDate iHighDate;
		readonly IDayEndOf iDayEndOf;
		readonly ICurrCnvt iCurrCnvt;
		readonly ILowDate iLowDate;
		readonly IGetumcf iGetumcf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ExecutiveShipmentRevenueCRUD iCLM_ExecutiveShipmentRevenueCRUD;

		public CLM_ExecutiveShipmentRevenue(IBunchedLoadCollection bunchedLoadCollection,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IDateTimeUtil dateTimeUtil,
			IStringUtil stringUtil,
			IRaiseError raiseError,
			IHighDate iHighDate,
			IDayEndOf iDayEndOf,
			ICurrCnvt iCurrCnvt,
			ILowDate iLowDate,
			IGetumcf iGetumcf,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ExecutiveShipmentRevenueCRUD iCLM_ExecutiveShipmentRevenueCRUD)
		{
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.dateTimeUtil = dateTimeUtil;
			this.stringUtil = stringUtil;
			this.raiseError = raiseError;
			this.iHighDate = iHighDate;
			this.iDayEndOf = iDayEndOf;
			this.iCurrCnvt = iCurrCnvt;
			this.iLowDate = iLowDate;
			this.iGetumcf = iGetumcf;
			this.sQLUtil = sQLUtil;
			this.iCLM_ExecutiveShipmentRevenueCRUD = iCLM_ExecutiveShipmentRevenueCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ExecutiveShipmentRevenueSp(
			string View,
			string SiteGroup,
			DateTime? DateStarting,
			DateTime? DateEnding,
			string FilterString = null)
		{

			if (bunchedLoadCollection != null)
				bunchedLoadCollection.StartBunching();

			try
			{

				ICollectionLoadResponse Data = null;

				string ALTGEN_SpName = null;
				int? ALTGEN_Severity = null;
				int? rowCount = null;
				decimal? coitem_price_conv = null;
				string coitem_ship_site = null;
				string CoCurrCode = null;
				decimal? TRate = null;
				string Infobar = null;
				string DomCurrCode = null;
				decimal? UomConvFactor = null;
				string coitem_item = null;
				string coitem_u_m = null;
				string co_cust_num = null;
				int? seq = null;
				int? Severity = null;
				string Site = null;
				IList<string> SiteList = null;
				DateTime? ShipDate = null;
				string PrevCurrCode = null;
				DateTime? PrevShipDate = null;
				int? DomCurrencyPlaces = null;
				int? DomCurrencyPlacesCp = null;
				int? InvparmsPlacesQtyUnit = null;
				ICollectionLoadResponse site_group_crsLoadResponse = null;
				string WhereStr = null;
				if (this.iCLM_ExecutiveShipmentRevenueCRUD.Optional_ModuleForExists())
				{
					//this temp table is a table variable in old stored procedure version.
					this.iCLM_ExecutiveShipmentRevenueCRUD.DeclareAltgenTable();

					this.iCLM_ExecutiveShipmentRevenueCRUD.InsertOptional_Module();

					while (this.iCLM_ExecutiveShipmentRevenueCRUD.Tv_ALTGENForExists())
					{
						(ALTGEN_SpName, rowCount) = this.iCLM_ExecutiveShipmentRevenueCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
						var ALTGEN = this.iCLM_ExecutiveShipmentRevenueCRUD.AltExtGen_CLM_ExecutiveShipmentRevenueSp(ALTGEN_SpName,
							View,
							SiteGroup,
							DateStarting,
							DateEnding,
							FilterString);
						ALTGEN_Severity = ALTGEN.ReturnCode;

						if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
						{
							return (ALTGEN.Data, ALTGEN_Severity);

						}

						this.iCLM_ExecutiveShipmentRevenueCRUD.DeleteTv_ALTGEN(ALTGEN_SpName);
					}

				}
				if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ExecutiveShipmentRevenueSp") != null)
				{
					var EXTGEN = this.iCLM_ExecutiveShipmentRevenueCRUD.AltExtGen_CLM_ExecutiveShipmentRevenueSp("dbo.EXTGEN_CLM_ExecutiveShipmentRevenueSp",
						View,
						SiteGroup,
						DateStarting,
						DateEnding,
						FilterString);
					int? EXTGEN_Severity = EXTGEN.ReturnCode;

					if (EXTGEN_Severity != 1)
					{
						return (EXTGEN.Data, EXTGEN_Severity);
					}
				}

				//this.iCLM_ExecutiveShipmentRevenueCRUD.SetIsolationLevel();
				Severity = 0;
				DateStarting = convertToUtil.ToDateTime(stringUtil.IsNull(
					DateStarting,
					this.iLowDate.LowDateFn()));
				DateEnding = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(stringUtil.IsNull(
						DateEnding,
						this.iHighDate.HighDateFn())));

				#region Cursor Statement
				site_group_crsLoadResponse = this.iCLM_ExecutiveShipmentRevenueCRUD.SelectSite_Group(SiteGroup);
				SiteList = this.iCLM_ExecutiveShipmentRevenueCRUD.InsertSite_Group(site_group_crsLoadResponse);
				//Not all site has DomCurrCode, choose the last one which has DomCurrCode
				if(SiteList?.Count > 0)
                {
					for (int idx = SiteList.Count - 1; idx >= 0; idx--)
					{
						Site = SiteList[idx];
						(DomCurrCode, rowCount) = this.iCLM_ExecutiveShipmentRevenueCRUD.LoadCurrparms_All(Site, DomCurrCode);
						if (DomCurrCode != null) break;
					}
				}
				
				#endregion Cursor Statement

				(DomCurrencyPlaces, DomCurrencyPlacesCp, rowCount) = this.iCLM_ExecutiveShipmentRevenueCRUD.LoadCurrency(DomCurrCode, DomCurrencyPlaces, DomCurrencyPlacesCp);
				(InvparmsPlacesQtyUnit, rowCount) = this.iCLM_ExecutiveShipmentRevenueCRUD.LoadInvparms(InvparmsPlacesQtyUnit);

				this.iCLM_ExecutiveShipmentRevenueCRUD.CreateTempCoitem();

				this.iCLM_ExecutiveShipmentRevenueCRUD.CreateTempCoitemSum();

				//this temp table is a table variable in old stored procedure version.
				this.iCLM_ExecutiveShipmentRevenueCRUD.CreateTempTableTv_um();

				WhereStr = stringUtil.Concat("WHERE ", FilterString);
				this.iCLM_ExecutiveShipmentRevenueCRUD.InsertTempCoitem(SiteList, DateStarting, DateEnding, DomCurrCode);

				PrevShipDate = null;
				PrevCurrCode = "";
				using (IRecordStream tempCoitemRecordStream = this.iCLM_ExecutiveShipmentRevenueCRUD.SelectTempCoitem(DomCurrCode, bunchedLoadCollection.LoadType))
				{
					while (tempCoitemRecordStream.Read())
					{
						IRecordReadOnly tempCoitemRow = tempCoitemRecordStream.Current;
						CoCurrCode = tempCoitemRow.GetValue<string>(0);
						coitem_price_conv = tempCoitemRow.GetValue<decimal?>(1);
						seq = tempCoitemRow.GetValue<int?>(2);
						coitem_ship_site = tempCoitemRow.GetValue<string>(3);
						ShipDate = tempCoitemRow.GetValue<DateTime?>(4);

						if (PrevShipDate == null || sQLUtil.SQLNotEqual(dateTimeUtil.DateDiff("Day", PrevShipDate, ShipDate), 0) == true || sQLUtil.SQLNotEqual(PrevCurrCode, CoCurrCode) == true)
						{
							TRate = null;
						}

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: CurrCnvtSp
						var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
							CurrCode: CoCurrCode,
							FromDomestic: 0,
							UseBuyRate: 0,
							RoundResult: 1,
							Date: ShipDate,
							RoundPlaces: DomCurrencyPlacesCp,
							UseCustomsAndExciseRates: null,
							ForceRate: null,
							FindTTFixed: null,
							TRate: TRate,
							Infobar: Infobar,
							Amount1: coitem_price_conv,
							Result1: coitem_price_conv,
							Site: coitem_ship_site,
							DomCurrCode: DomCurrCode);
						Severity = CurrCnvt.ReturnCode;
						TRate = CurrCnvt.TRate;
						Infobar = CurrCnvt.Infobar;
						coitem_price_conv = CurrCnvt.Result1;

						#endregion ExecuteMethodCall

						if (sQLUtil.SQLNotEqual(Severity, 0) == true)
						{

							break;

						}
						this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempCoitemByCoitemPriceConv(seq, coitem_price_conv);
						PrevShipDate = convertToUtil.ToDateTime(ShipDate);
						PrevCurrCode = CoCurrCode;

					}
				}
				//Deallocate Cursor currCrs
				this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateDiscountPriceForTempCoitem(DomCurrencyPlacesCp);
				this.iCLM_ExecutiveShipmentRevenueCRUD.InsertTempTvUm();

				using (IRecordStream tempUmRecordStream = this.iCLM_ExecutiveShipmentRevenueCRUD.SelectTempTvUm(bunchedLoadCollection.LoadType))
				{
					while (tempUmRecordStream.Read())
					{
						var tempUmItem = tempUmRecordStream.Current;
						coitem_u_m = tempUmItem.GetValue<string>(0);
						coitem_item = tempUmItem.GetValue<string>(1);
						co_cust_num = tempUmItem.GetValue<string>(2);
						coitem_ship_site = tempUmItem.GetValue<string>(3);

						#region CRUD ExecuteMethodCall

						//Please Generate the bounce for this stored procedure: GetumcfSp
						var Getumcf = this.iGetumcf.GetumcfSp(
							OtherUM: coitem_u_m,
							Item: coitem_item,
							VendNum: co_cust_num,
							Area: "C",
							ConvFactor: UomConvFactor,
							Infobar: Infobar,
							Site: coitem_ship_site);
						Severity = Getumcf.ReturnCode;
						UomConvFactor = Getumcf.ConvFactor;
						Infobar = Getumcf.Infobar;

						#endregion ExecuteMethodCall

						this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempTvUm(UomConvFactor, coitem_ship_site, coitem_item, coitem_u_m, co_cust_num);

					}
				}
				//Deallocate Cursor umCrs
				var Coitem3LoadResponse = this.iCLM_ExecutiveShipmentRevenueCRUD.SelectTempCoitemForUpdate();
				this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempCoitem(DomCurrencyPlacesCp, InvparmsPlacesQtyUnit, Coitem3LoadResponse);

				this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempCoitemByDomCurrencyPlaces(DomCurrencyPlaces);
				this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempCoitem();

				if (sQLUtil.SQLGreaterThan(stringUtil.CharIndex(
						View,
						"SPI"), 0) == true)
				{
					if (sQLUtil.SQLEqual(View, "S") == true)
					{
						this.iCLM_ExecutiveShipmentRevenueCRUD.InsertTempCoitemsumForViewS();
					}
					if (sQLUtil.SQLEqual(View, "P") == true)
					{
						this.iCLM_ExecutiveShipmentRevenueCRUD.InsertTempCoitemsumForViewP();
					}
					if (sQLUtil.SQLEqual(View, "I") == true)
					{
						this.iCLM_ExecutiveShipmentRevenueCRUD.InsertTempCoitemsumForViewI();
					}

					this.iCLM_ExecutiveShipmentRevenueCRUD.UpdateTempCoitemsumByDomCurrCode(DomCurrCode);

					Data = this.iCLM_ExecutiveShipmentRevenueCRUD.GetResultFromTempCoitemSum(bunchedLoadCollection.LoadType, bunchedLoadCollection.RecordCap);

				}
				else
				{

					this.iCLM_ExecutiveShipmentRevenueCRUD.CreateTempCoitem2();
					Data = this.iCLM_ExecutiveShipmentRevenueCRUD.GetResultFromTempCoitem2(bunchedLoadCollection.LoadType, bunchedLoadCollection.RecordCap);

				}

				return (Data, Severity);

			}
			finally
			{
				if (bunchedLoadCollection != null)
					bunchedLoadCollection.EndBunching();
			}
		}

	}
}
