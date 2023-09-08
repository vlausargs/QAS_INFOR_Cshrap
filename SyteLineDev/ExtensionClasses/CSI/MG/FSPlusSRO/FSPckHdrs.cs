//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSPckHdrs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSPckHdrs")]
    public class FSPckHdrs : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSProfileSROPackSlipSp([Optional] int? BegPackNum,
		                                           [Optional] int? EndPackNum,
		                                           [Optional] int? BegPackSeq,
		                                           [Optional] int? EndPackSeq,
		                                           [Optional] string StartCustNum,
		                                           [Optional] string EndCustNum,
		                                           [Optional] DateTime? StartOpenDate,
		                                           [Optional] DateTime? EndOpenDate,
		                                           [Optional] DateTime? StartTransDate,
		                                           [Optional] DateTime? EndTransDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSProfileSROPackSlipExt = new SSSFSProfileSROPackSlipFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSProfileSROPackSlipExt.SSSFSProfileSROPackSlipSp(BegPackNum,
				                                                                   EndPackNum,
				                                                                   BegPackSeq,
				                                                                   EndPackSeq,
				                                                                   StartCustNum,
				                                                                   EndCustNum,
				                                                                   StartOpenDate,
				                                                                   EndOpenDate,
				                                                                   StartTransDate,
				                                                                   EndTransDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSROPackSlipHdr_LoadSp(int? PackNum,
		                                            DateTime? PackDate,
		                                            string InWhse,
		                                            string SRONum,
		                                            int? SROLine,
		                                            int? SROOper,
		                                            byte? TransPosted,
		                                            byte? AllShipTos,
		                                            string ShipToType,
		                                            string ShipToNum,
		                                            int? ShipToSeq,
		                                            [Optional] int? MinPackNum,
		                                            [Optional] int? MaxPackNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSFSSROPackSlipHdr_LoadExt = new SSSFSSROPackSlipHdr_LoadFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSFSSROPackSlipHdr_LoadExt.SSSFSSROPackSlipHdr_LoadSp(PackNum,
				                                                                     PackDate,
				                                                                     InWhse,
				                                                                     SRONum,
				                                                                     SROLine,
				                                                                     SROOper,
				                                                                     TransPosted,
				                                                                     AllShipTos,
				                                                                     ShipToType,
				                                                                     ShipToNum,
				                                                                     ShipToSeq,
				                                                                     MinPackNum,
				                                                                     MaxPackNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROPackSlipHdr_UpdSp(Guid? RowPointer,
		int? Selected,
		ref int? PackNum,
		string Whse,
		DateTime? PackDate,
		string CustNum,
		string DropType,
		string DropPartnerID,
		string DropCustNum,
		string DropUsrNum,
		string DropShipNo,
		int? DropCustSeq,
		int? DropUsrSeq,
		decimal? Weight,
		string ShipCode,
		int? QtyPackages)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSROPackSlipHdr_UpdExt = new SSSFSSROPackSlipHdr_UpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSROPackSlipHdr_UpdExt.SSSFSSROPackSlipHdr_UpdSp(RowPointer,
				Selected,
				PackNum,
				Whse,
				PackDate,
				CustNum,
				DropType,
				DropPartnerID,
				DropCustNum,
				DropUsrNum,
				DropShipNo,
				DropCustSeq,
				DropUsrSeq,
				Weight,
				ShipCode,
				QtyPackages);
				
				int Severity = result.ReturnCode.Value;
				PackNum = result.PackNum;
				return Severity;
			}
		}
    }
}
