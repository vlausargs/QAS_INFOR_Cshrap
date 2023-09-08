//PROJECT NAME: CodesExt
//CLASS NAME: SLDistAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLDistAccts")]
	public class SLDistAccts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_PerTotSp()
        {
            var iCLM_PerTotExt = new CLM_PerTotFactory().Create(this, true);

            var result = iCLM_PerTotExt.CLM_PerTotSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
		public int InventoryBalLabelsSp(ref DateTime? FirstPeriodEnd,
		                                ref DateTime? SecondPeriodEnd,
		                                ref DateTime? ThirdPeriodEnd,
		                                ref DateTime? FourthPeriodEnd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInventoryBalLabelsExt = new InventoryBalLabelsFactory().Create(appDb);
				
				int Severity = iInventoryBalLabelsExt.InventoryBalLabelsSp(ref FirstPeriodEnd,
				                                                           ref SecondPeriodEnd,
				                                                           ref ThirdPeriodEnd,
				                                                           ref FourthPeriodEnd);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DistacctTransferAccountsSp(Guid? DistacctRowPointer,
		int? TransferInv,
		int? TransferLbr,
		int? TransferFovhd,
		int? TransferVovhd,
		int? TransferOut,
		int? TransferInvInproc,
		int? TransferLbrInproc,
		int? TransferFovhdInproc,
		int? TransferVovhdInproc,
		int? TransferOutInproc,
		string LocType,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDistacctTransferAccountsExt = new DistacctTransferAccountsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDistacctTransferAccountsExt.DistacctTransferAccountsSp(DistacctRowPointer,
				TransferInv,
				TransferLbr,
				TransferFovhd,
				TransferVovhd,
				TransferOut,
				TransferInvInproc,
				TransferLbrInproc,
				TransferFovhdInproc,
				TransferVovhdInproc,
				TransferOutInproc,
				LocType,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable DistacctWhereUsedSp(string ProductCode,
		string Whse,
		string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDistacctWhereUsedExt = new DistacctWhereUsedFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDistacctWhereUsedExt.DistacctWhereUsedSp(ProductCode,
				Whse,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_MetricProdcodeValueSp()
		{
			var iHome_MetricProdcodeValueExt = new Home_MetricProdcodeValueFactory().Create(this, true);

			var result = iHome_MetricProdcodeValueExt.Home_MetricProdcodeValueSp();

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_PerTotByProdcodeSp([Optional] string FilterString,
        [Optional] string SiteGroup)
        {
            var iCLM_PerTotByProdcodeExt = new CLM_PerTotByProdcodeFactory().Create(this, true);

            var result = iCLM_PerTotByProdcodeExt.CLM_PerTotByProdcodeSp(FilterString,
            SiteGroup);

            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
            return dt;
        }
    }
}
