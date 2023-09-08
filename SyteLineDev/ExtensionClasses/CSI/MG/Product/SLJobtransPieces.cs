//PROJECT NAME: ProductExt
//CLASS NAME: SLJobtransPieces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
	[IDOExtensionClass("SLJobtransPieces")]
	public class SLJobtransPieces : ExtensionClassBase
	{




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOverrideForJobTranPiecesSp(Guid? JobTranPieceRowPointer,
		int? CompletedPieceCount,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOverrideForJobTranPiecesExt = new UpdateOverrideForJobTranPiecesFactory().Create(appDb);
				
				var result = iUpdateOverrideForJobTranPiecesExt.UpdateOverrideForJobTranPiecesSp(JobTranPieceRowPointer,
				CompletedPieceCount,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetJobTranPieceDimensionsSp(string Job,
		[Optional] int? Suffix,
		[Optional] decimal? TransNum,
		string Whse,
		string Location,
		[Optional] string Lot,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetJobTranPieceDimensionsExt = new CLM_GetJobTranPieceDimensionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetJobTranPieceDimensionsExt.CLM_GetJobTranPieceDimensionsSp(Job,
				Suffix,
				TransNum,
				Whse,
				Location,
				Lot,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteJobTransactionItemPiecesSp(decimal? PTransNum,
		[Optional] string PItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteJobTransactionItemPiecesExt = new DeleteJobTransactionItemPiecesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteJobTransactionItemPiecesExt.DeleteJobTransactionItemPiecesSp(PTransNum,
				PItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForJobTranPiecesSp(decimal? TransNum,
		int? PieceCount,
		int? CompletedPieceCount,
		string Item,
		decimal? DeciDimension1,
		decimal? DeciDimension2,
		decimal? DeciDimension3,
		decimal? DeciDimension4,
		decimal? DeciDimension5,
		decimal? DeciDimension6,
		decimal? DeciDimension7,
		decimal? DeciDimension8,
		decimal? DeciDimension9,
		decimal? DeciDimension10,
		string CharDimension1,
		string CharDimension2,
		string CharDimension3,
		string CharDimension4,
		string CharDimension5,
		string CharDimension6,
		string CharDimension7,
		string CharDimension8,
		string CharDimension9,
		string CharDimension10,
		int? LogiDimension,
		Guid? JobTranPieceRowPointer,
		ref string Infobar,
		[Optional] Guid? JobtranRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOverrideForJobTranPiecesExt = new InsertOverrideForJobTranPiecesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOverrideForJobTranPiecesExt.InsertOverrideForJobTranPiecesSp(TransNum,
				PieceCount,
				CompletedPieceCount,
				Item,
				DeciDimension1,
				DeciDimension2,
				DeciDimension3,
				DeciDimension4,
				DeciDimension5,
				DeciDimension6,
				DeciDimension7,
				DeciDimension8,
				DeciDimension9,
				DeciDimension10,
				CharDimension1,
				CharDimension2,
				CharDimension3,
				CharDimension4,
				CharDimension5,
				CharDimension6,
				CharDimension7,
				CharDimension8,
				CharDimension9,
				CharDimension10,
				LogiDimension,
				JobTranPieceRowPointer,
				Infobar,
				JobtranRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
