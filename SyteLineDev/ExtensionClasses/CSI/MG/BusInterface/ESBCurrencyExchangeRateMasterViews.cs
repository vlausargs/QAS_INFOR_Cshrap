//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBCurrencyExchangeRateMasterViews.cs

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
	[IDOExtensionClass("ESBCurrencyExchangeRateMasterViews")]
	public class ESBCurrencyExchangeRateMasterViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBCurrencyExchangeRateMasterSp([Optional] DateTime? EffDate,
		string ActionExpression,
		string ToCurrCode,
		string FromCurrCode,
		[Optional] decimal? DerBuyRate,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBCurrencyExchangeRateMasterExt = new LoadESBCurrencyExchangeRateMasterFactory().Create(appDb);
				
				var result = iLoadESBCurrencyExchangeRateMasterExt.LoadESBCurrencyExchangeRateMasterSp(EffDate,
				ActionExpression,
				ToCurrCode,
				FromCurrCode,
				DerBuyRate,
				Infobar);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBCurrencyExchangeRateMasterSp(Guid? ID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBCurrencyExchangeRateMasterExt = new CLM_ESBCurrencyExchangeRateMasterFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBCurrencyExchangeRateMasterExt.CLM_ESBCurrencyExchangeRateMasterSp(ID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
