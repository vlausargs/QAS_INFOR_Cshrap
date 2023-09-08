//PROJECT NAME: APSExt
//CLASS NAME: SLEXRCPTnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLEXRCPTnnns")]
    public class SLEXRCPTnnns : ExtensionClassBase
    {




		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetEXRCPTSp(short? AltNo,
		                                    [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetEXRCPTExt = new CLM_ApsGetEXRCPTFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetEXRCPTExt.CLM_ApsGetEXRCPTSp(AltNo,
				                                                     FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WhatIfExpectedReceiptsItemChgSp(int? AltNo,
		string Item,
		ref string Description)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWhatIfExpectedReceiptsItemChgExt = new WhatIfExpectedReceiptsItemChgFactory().Create(appDb);
				
				var result = iWhatIfExpectedReceiptsItemChgExt.WhatIfExpectedReceiptsItemChgSp(AltNo,
				Item,
				Description);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WhatIfExpectedReceiptsPOChgSp(int? AltNo,
		[Optional] string PONum,
		ref DateTime? DueDate,
		ref string QtyOrdered)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWhatIfExpectedReceiptsPOChgExt = new WhatIfExpectedReceiptsPOChgFactory().Create(appDb);
				
				var result = iWhatIfExpectedReceiptsPOChgExt.WhatIfExpectedReceiptsPOChgSp(AltNo,
				PONum,
				DueDate,
				QtyOrdered);
				
				int Severity = result.ReturnCode.Value;
				DueDate = result.DueDate;
				QtyOrdered = result.QtyOrdered;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsEXRCPTDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsEXRCPTDelExt = new ApsEXRCPTDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsEXRCPTDelExt.ApsEXRCPTDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsEXRCPTSaveSp(int? InsertFlag,
		int? AltNo,
		string ORDERID,
		string MATERIALID,
		DateTime? EXRCPTDATE,
		DateTime? PROJDATE,
		decimal? PROJQTY,
		string MATLDELVID,
		decimal? RESERVEDQTY,
		Guid? SLREF)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsEXRCPTSaveExt = new ApsEXRCPTSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsEXRCPTSaveExt.ApsEXRCPTSaveSp(InsertFlag,
				AltNo,
				ORDERID,
				MATERIALID,
				EXRCPTDATE,
				PROJDATE,
				PROJQTY,
				MATLDELVID,
				RESERVEDQTY,
				SLREF);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
