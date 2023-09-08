//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBQuoteViews.cs

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
	[IDOExtensionClass("ESBQuoteViews")]
	public class ESBQuoteViews : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBQuoteSp(string DocumentID,
		string DocumentIDNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBQuoteExt = new CLM_ESBQuoteFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBQuoteExt.CLM_ESBQuoteSp(DocumentID,
				DocumentIDNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadProcessQuoteSp(string pCoNum,
		string pActionCode,
		string pStat,
		string pCustNum,
		string pShipToID,
		DateTime? pQuoteDate,
		string pContact,
		string pPhone,
		string pShipCode,
		string pTermsCode,
		string pSlsman,
		string pCustQuote,
		string pConfirmationRef,
		string pShipPartial,
		string pShipEarly,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iLoadProcessQuoteExt = new LoadProcessQuoteFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iLoadProcessQuoteExt.LoadProcessQuoteSp(pCoNum,
				pActionCode,
				pStat,
				pCustNum,
				pShipToID,
				pQuoteDate,
				pContact,
				pPhone,
				pShipCode,
				pTermsCode,
				pSlsman,
				pCustQuote,
				pConfirmationRef,
				pShipPartial,
				pShipEarly,
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
