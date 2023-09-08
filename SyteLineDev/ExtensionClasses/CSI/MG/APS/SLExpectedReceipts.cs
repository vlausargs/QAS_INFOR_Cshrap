//PROJECT NAME: APSExt
//CLASS NAME: SLExpectedReceipts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.Material;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.APS
{
	[IDOExtensionClass("SLExpectedReceipts")]
	public class SLExpectedReceipts : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpectedReceiptsAPSItemChgSp(string Item,
			ref string Description)
		{
			var iExpectedReceiptsAPSItemChgExt = this.GetService<IExpectedReceiptsAPSItemChg>();
			
			var result = iExpectedReceiptsAPSItemChgExt.ExpectedReceiptsAPSItemChgSp(Item,
				Description);
			
			Description = result.Description;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpectedReceiptsAPSPOChgSp(string PONum,
		                                      short? POLine,
		                                      short? PORelease,
		                                      ref DateTime? DueDate,
		                                      ref decimal? QtyOrdered)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iExpectedReceiptsAPSPOChgExt = new ExpectedReceiptsAPSPOChgFactory().Create(appDb);
				
				int Severity = iExpectedReceiptsAPSPOChgExt.ExpectedReceiptsAPSPOChgSp(PONum,
				                                                                       POLine,
				                                                                       PORelease,
				                                                                       ref DueDate,
				                                                                       ref QtyOrdered);
				
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateExpRecDemandSp(string DemandType, string DemandNum, ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                IExpandKyByTypeFactory expandKyByTypeFactory = new ExpandKyByTypeFactory();
                var iValidateExpRecDemandExt = new ValidateExpRecDemandFactory(expandKyByTypeFactory).Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);

                var result = iValidateExpRecDemandExt.ValidateExpRecDemandSp(DemandType,
					DemandNum,
					Infobar);

                Infobar = result.Infobar;

                return result.ReturnCode.Value;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidatePurchasedItemsSp(string ItemNum, ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidatePurchasedItemsExt = new ValidatePurchasedItemsFactory().Create(appDb,
					mgInvoker,
					new CSI.Data.SQL.SQLParameterProvider(),
					true);
				
				var result = iValidatePurchasedItemsExt.ValidatePurchasedItemsSp(ItemNum, Infobar);
				
				Infobar = result.Infobar;
				
				return result.ReturnCode.Value;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExpRecDemandSp(int? Pos,
		string DemandType,
		[Optional] string DemandNum,
		[Optional, DefaultParameterValue(0)] int? DemandLineSuf)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExpRecDemandExt = new CLM_ExpRecDemandFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExpRecDemandExt.CLM_ExpRecDemandSp(Pos,
				DemandType,
				DemandNum,
				DemandLineSuf);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ExpRecPOSp(string ItemID,
		int? Pos,
		[Optional] string PONum,
		[Optional, DefaultParameterValue(0)] int? POLine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ExpRecPOExt = new CLM_ExpRecPOFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ExpRecPOExt.CLM_ExpRecPOSp(ItemID,
				Pos,
				PONum,
				POLine);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
