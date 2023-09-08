//PROJECT NAME: MaterialExt
//CLASS NAME: SLItempiecesAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLItempiecesAlls")]
	public class SLItempiecesAlls : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForItemPiecesAllSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		int? Change,
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
		[Optional] string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iInsertOverrideForItemPiecesAllExt = new InsertOverrideForItemPiecesAllFactory().Create(appDb);
				
				var result = iInsertOverrideForItemPiecesAllExt.InsertOverrideForItemPiecesAllSp(Item,
				Whse,
				Loc,
				Lot,
				Change,
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
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOverrideForItemPiecesAllSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		[Optional] string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOverrideForItemPiecesAllExt = new UpdateOverrideForItemPiecesAllFactory().Create(appDb);
				
				var result = iUpdateOverrideForItemPiecesAllExt.UpdateOverrideForItemPiecesAllSp(ItempieceRowPointer,
				Change,
				NewWhse,
				NewLoc,
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_GetItemPieceDimensionsSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		[Optional] string SiteRef,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_GetItemPieceDimensionsExt = new CLM_GetItemPieceDimensionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_GetItemPieceDimensionsExt.CLM_GetItemPieceDimensionsSp(Item,
				Whse,
				Loc,
				Lot,
				SiteRef,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
