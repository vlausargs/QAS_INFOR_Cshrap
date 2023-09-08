//PROJECT NAME: MaterialExt
//CLASS NAME: SLMatltranAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Data.RecordSets;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Logistics.Vendor;
using CSI.Logistics.Customer;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLMatltranAlls")]
    public class SLMatltranAlls : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DeleteMatltranSp([Optional, DefaultParameterValue("P")] string PreviewOrCommit,
		[Optional] DateTime? FromTransDate,
		[Optional] DateTime? ToTransDate,
		[Optional] string TransType,
		[Optional] string RefType,
		[Optional] string FromItem,
		[Optional] string ToItem,
		[Optional] string FromLoc,
		[Optional] string ToLoc,
		[Optional] decimal? FromTransNum,
		[Optional] decimal? ToTransNum,
		ref string Infobar,
		[Optional] short? StartingTransDateOffset,
		[Optional] short? EndingTransDateOffset,
		[Optional, DefaultParameterValue((byte)1)] byte? List)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iDeleteMatltranExt = new DeleteMatltranFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iDeleteMatltranExt.DeleteMatltranSp(PreviewOrCommit,
				                                                 FromTransDate,
				                                                 ToTransDate,
				                                                 TransType,
				                                                 RefType,
				                                                 FromItem,
				                                                 ToItem,
				                                                 FromLoc,
				                                                 ToLoc,
				                                                 FromTransNum,
				                                                 ToTransNum,
				                                                 Infobar,
				                                                 StartingTransDateOffset,
				                                                 EndingTransDateOffset,
				                                                 List);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}









































		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemNotUsedSp(DateTime? CutoffDate,
		string PMTCodes,
		[Optional] string FilterString,
		string IncludedTypes,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ItemNotUsedExt = new CLM_ItemNotUsedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ItemNotUsedExt.CLM_ItemNotUsedSp(CutoffDate,
				PMTCodes,
				FilterString,
				IncludedTypes,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}






		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TransactionDetailMatTranSp(decimal? PMatlTransNum,
			string PSite,
			[Optional] string PRefNum)
		{
			var iCLM_TransactionDetailMatTranExt = new CLM_TransactionDetailMatTranFactory().Create(this, true);

			var result = iCLM_TransactionDetailMatTranExt.CLM_TransactionDetailMatTranSp(PMatlTransNum,
				PSite,
				PRefNum);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricCycleCountSp()
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iHome_MetricCycleCountExt = new Home_MetricCycleCountFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iHome_MetricCycleCountExt.Home_MetricCycleCountSp();
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}










		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TranferLineSummarySp(string Whse,
			string PMTCodes,
			[Optional] string FilterString,
			[Optional] string PSiteGroup)
		{
			var iCLM_TranferLineSummaryExt = new CLM_TranferLineSummaryFactory().Create(this, true);

			var result = iCLM_TranferLineSummaryExt.CLM_TranferLineSummarySp(Whse,
				PMTCodes,
				FilterString,
				PSiteGroup);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}





















		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_DomesticCurrencySp(string CurrCode,
		[Optional, DefaultParameterValue(0)] int? UseBuyRate,
		[Optional] decimal? TRate,
		[Optional] DateTime? PossibleDate,
		[Optional] decimal? Amount1,
		[Optional] decimal? Amount2,
		[Optional] decimal? Amount3,
		[Optional] decimal? Amount4,
		[Optional] decimal? Amount5,
		[Optional] decimal? Amount6,
		[Optional] decimal? Amount7,
		[Optional] decimal? Amount8,
		[Optional] decimal? Amount9,
		[Optional] decimal? Amount10,
		[Optional] decimal? Amount11,
		[Optional] decimal? Amount12,
		[Optional] decimal? Amount13,
		[Optional] decimal? Amount14,
		[Optional] decimal? Amount15,
		[Optional] decimal? Amount16,
		[Optional] decimal? Amount17,
		[Optional] decimal? Amount18,
		[Optional] decimal? Amount19,
		[Optional] decimal? Amount20,
		[Optional] decimal? Amount21,
		[Optional] decimal? Amount22,
		[Optional] decimal? Amount23,
		[Optional] decimal? Amount24,
		[Optional] decimal? Amount25,
		[Optional] decimal? Amount26,
		[Optional] decimal? Amount27,
		[Optional] decimal? Amount28,
		[Optional] decimal? Amount29,
		[Optional] decimal? Amount30,
		[Optional] decimal? Amount31,
		[Optional] decimal? Amount32,
		[Optional] decimal? Amount33,
		[Optional] decimal? Amount34,
		[Optional] decimal? Amount35,
		[Optional] decimal? Amount36,
		[Optional] decimal? Amount37,
		[Optional] decimal? Amount38,
		[Optional] decimal? Amount39,
		[Optional] decimal? Amount40)
		{
			var iCLM_DomesticCurrencyExt = new CLM_DomesticCurrencyFactory().Create(this, true);
				
			var result = iCLM_DomesticCurrencyExt.CLM_DomesticCurrencySp(CurrCode,
			UseBuyRate,
			TRate,
			PossibleDate,
			Amount1,
			Amount2,
			Amount3,
			Amount4,
			Amount5,
			Amount6,
			Amount7,
			Amount8,
			Amount9,
			Amount10,
			Amount11,
			Amount12,
			Amount13,
			Amount14,
			Amount15,
			Amount16,
			Amount17,
			Amount18,
			Amount19,
			Amount20,
			Amount21,
			Amount22,
			Amount23,
			Amount24,
			Amount25,
			Amount26,
			Amount27,
			Amount28,
			Amount29,
			Amount30,
			Amount31,
			Amount32,
			Amount33,
			Amount34,
			Amount35,
			Amount36,
			Amount37,
			Amount38,
			Amount39,
			Amount40);
				
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}
    }
}
