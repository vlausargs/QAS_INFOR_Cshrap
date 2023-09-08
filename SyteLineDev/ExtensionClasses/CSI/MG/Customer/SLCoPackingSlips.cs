//PROJECT NAME: CustomerExt
//CLASS NAME: SLCoPackingSlips.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLCoPackingSlips")]
    public class SLCoPackingSlips : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckForSkippedPackingSlipsSp(int? COTypeA,
                                                 int? CoTypeB,
                                                 string CoStatus,
                                                 string StartingOrder,
                                                 string EndingOrder,
                                                 string StartingCustomer,
                                                 string EndingCustomer,
                                                 DateTime? StartingOrderDate,
                                                 DateTime? EndingOrderDate,
                                                 string ParmSite,
                                                 string CoLineStatus,
                                                 string Whse,
                                                 short? StartingLine,
                                                 short? EndingLine,
                                                 short? StartingRelease,
                                                 short? EndingRelease,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckForSkippedPackingSlipsExt = new CheckForSkippedPackingSlipsFactory().Create(appDb);

                int Severity = iCheckForSkippedPackingSlipsExt.CheckForSkippedPackingSlipsSp(COTypeA,
                                                                                             CoTypeB,
                                                                                             CoStatus,
                                                                                             StartingOrder,
                                                                                             EndingOrder,
                                                                                             StartingCustomer,
                                                                                             EndingCustomer,
                                                                                             StartingOrderDate,
                                                                                             EndingOrderDate,
                                                                                             ParmSite,
                                                                                             CoLineStatus,
                                                                                             Whse,
                                                                                             StartingLine,
                                                                                             EndingLine,
                                                                                             StartingRelease,
                                                                                             EndingRelease,
                                                                                             ref Infobar);

                return Severity;
            }
        }





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VerifyPackedNumSp(string OrderNum,
		int? OrderLine,
		int? OrderRelease,
		decimal? OrderQty,
		ref int? Flag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVerifyPackedNumExt = new VerifyPackedNumFactory().Create(appDb);
				
				var result = iVerifyPackedNumExt.VerifyPackedNumSp(OrderNum,
				OrderLine,
				OrderRelease,
				OrderQty,
				Flag);
				
				int Severity = result.ReturnCode.Value;
				Flag = result.Flag;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateCoPckHeaderSp(string TPckCall,
		string CoNum,
		string CustNum,
		int? CustSeq,
		string CoitemCustNum,
		int? CoitemCustSeq,
		string ShipCode,
		int? QtyPackages,
		decimal? Weight,
		DateTime? PackDate,
		string Whse,
		int? DoLines,
		int? FromCoLine,
		int? ToCoLine,
		int? FromCoRelease,
		int? ToCoRelease,
		DateTime? FromDate,
		DateTime? ToDate,
		string CoLineStat,
		string ProcessId,
		ref int? PackNum,
		ref string Infobar,
		[Optional] int? BatchId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateCoPckHeaderExt = new CreateCoPckHeaderFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateCoPckHeaderExt.CreateCoPckHeaderSp(TPckCall,
				CoNum,
				CustNum,
				CustSeq,
				CoitemCustNum,
				CoitemCustSeq,
				ShipCode,
				QtyPackages,
				Weight,
				PackDate,
				Whse,
				DoLines,
				FromCoLine,
				ToCoLine,
				FromCoRelease,
				ToCoRelease,
				FromDate,
				ToDate,
				CoLineStat,
				ProcessId,
				PackNum,
				Infobar,
				BatchId);
				
				int Severity = result.ReturnCode.Value;
				PackNum = result.PackNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ProfilePackingSlipSp(string CustNum,
		int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iProfilePackingSlipExt = new ProfilePackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iProfilePackingSlipExt.ProfilePackingSlipSp(CustNum,
				CustSeq);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
