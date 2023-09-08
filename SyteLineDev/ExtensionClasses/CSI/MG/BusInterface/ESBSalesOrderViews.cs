//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBSalesOrderViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBSalesOrderViews")]
	public class ESBSalesOrderViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBDistributedChargeSp(string ConfirmationRef,
		                                      short? CoLine,
		                                      decimal? ChargeAmt,
		                                      decimal? ChargePct,
		                                      string ReasonCode,
		                                      ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBDistributedChargeExt = new LoadESBDistributedChargeFactory().Create(appDb);
				
				int Severity = iLoadESBDistributedChargeExt.LoadESBDistributedChargeSp(ConfirmationRef,
				                                                                       CoLine,
				                                                                       ChargeAmt,
				                                                                       ChargePct,
				                                                                       ReasonCode,
				                                                                       ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBSalesOrderSp(string CoNum,
		[Optional] string PricingRequiredIndicator)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBSalesOrderExt = new CLM_ESBSalesOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBSalesOrderExt.CLM_ESBSalesOrderSp(CoNum,
				PricingRequiredIndicator);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadProcessSalesOrderSp(string pCoNum,
		string pActionCode,
		string pOrderType,
		string pStat,
		string pCustNum,
		DateTime? pOrderDate,
		string pContact,
		string pPhone,
		string pWhse,
		string pShipCode,
		string pTermsCode,
		string pSlsman,
		string pCustPo,
		string pConfirmationRef,
		string pShipPartial,
		string pShipEarly,
		string pUseSyteLinePrice,
		string pEstNum,
		string pMerchantID,
		decimal? pTotalAmt,
		string pGatewayStoredToken,
		string pLast4,
		string pCardType,
		decimal? pGatewayTransNum,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadProcessSalesOrderExt = new LoadProcessSalesOrderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadProcessSalesOrderExt.LoadProcessSalesOrderSp(pCoNum,
				pActionCode,
				pOrderType,
				pStat,
				pCustNum,
				pOrderDate,
				pContact,
				pPhone,
				pWhse,
				pShipCode,
				pTermsCode,
				pSlsman,
				pCustPo,
				pConfirmationRef,
				pShipPartial,
				pShipEarly,
				pUseSyteLinePrice,
				pEstNum,
				pMerchantID,
				pTotalAmt,
				pGatewayStoredToken,
				pLast4,
				pCardType,
				pGatewayTransNum,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
