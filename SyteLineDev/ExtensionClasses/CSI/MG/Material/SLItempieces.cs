//PROJECT NAME: MaterialExt
//CLASS NAME: SLItempieces.cs

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
    [IDOExtensionClass("SLItempieces")]
    public class SLItempieces : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AttributesQueryTabSearchSp(string AttrGroupClass,
                                              string SearchStr,
                                              string CriteriaSepa,
                                              ref string RowPointerStr,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAttributesQueryTabSearchExt = new AttributesQueryTabSearchFactory().Create(appDb);

                StringType oRowPointerStr = RowPointerStr;
                InfobarType oInfobar = Infobar;

                int Severity = iAttributesQueryTabSearchExt.AttributesQueryTabSearchSp(AttrGroupClass,
                                                                           SearchStr,
                                                                           CriteriaSepa,
                                                                           ref oRowPointerStr,
                                                                           ref oInfobar);

                RowPointerStr = oRowPointerStr;
                Infobar = oInfobar;


                return Severity;
            }
        }








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOverrideForAttributesExt = new UpdateOverrideForAttributesFactory().Create(appDb);
				
				var result = iUpdateOverrideForAttributesExt.UpdateOverrideForAttributesSp(ValColName,
				Value,
				Type,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpateItemPiecesForPurchaseOrderReveicingSp(string RefNum,
		int? RefLineSuffix,
		int? RefRelease,
		Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpateItemPiecesForPurchaseOrderReveicingExt = new UpateItemPiecesForPurchaseOrderReveicingFactory().Create(appDb);
				
				var result = iUpateItemPiecesForPurchaseOrderReveicingExt.UpateItemPiecesForPurchaseOrderReveicingSp(RefNum,
				RefLineSuffix,
				RefRelease,
				ItempieceRowPointer,
				Change,
				NewWhse,
				NewLoc,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateOverrideForItemPiecesSp(Guid? ItempieceRowPointer,
		int? Change,
		string NewWhse,
		string NewLoc,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? ExitImmediately,
		[Optional, DefaultParameterValue(0)] int? CurrentPieceCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateOverrideForItemPiecesExt = new UpdateOverrideForItemPiecesFactory().Create(appDb);
				
				var result = iUpdateOverrideForItemPiecesExt.UpdateOverrideForItemPiecesSp(ItempieceRowPointer,
				Change,
				NewWhse,
				NewLoc,
				Infobar,
				ExitImmediately,
				CurrentPieceCount);
				
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

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAttributeLabelsSp([Optional] string PAttrGroupClass,
		[Optional] string PAttrGroup,
		ref string PDeciAttr1Label,
		ref string PDeciAttr2Label,
		ref string PDeciAttr3Label,
		ref string PDeciAttr4Label,
		ref string PDeciAttr5Label,
		ref string PDeciAttr6Label,
		ref string PDeciAttr7Label,
		ref string PDeciAttr8Label,
		ref string PDeciAttr9Label,
		ref string PDeciAttr10Label,
		ref string PCharAttr1Label,
		ref string PCharAttr2Label,
		ref string PCharAttr3Label,
		ref string PCharAttr4Label,
		ref string PCharAttr5Label,
		ref string PCharAttr6Label,
		ref string PCharAttr7Label,
		ref string PCharAttr8Label,
		ref string PCharAttr9Label,
		ref string PCharAttr10Label,
		ref string PLogiAttrLabel,
		[Optional] string PSiteRef)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetAttributeLabelsExt = new GetAttributeLabelsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetAttributeLabelsExt.GetAttributeLabelsSp(PAttrGroupClass,
				PAttrGroup,
				PDeciAttr1Label,
				PDeciAttr2Label,
				PDeciAttr3Label,
				PDeciAttr4Label,
				PDeciAttr5Label,
				PDeciAttr6Label,
				PDeciAttr7Label,
				PDeciAttr8Label,
				PDeciAttr9Label,
				PDeciAttr10Label,
				PCharAttr1Label,
				PCharAttr2Label,
				PCharAttr3Label,
				PCharAttr4Label,
				PCharAttr5Label,
				PCharAttr6Label,
				PCharAttr7Label,
				PCharAttr8Label,
				PCharAttr9Label,
				PCharAttr10Label,
				PLogiAttrLabel,
				PSiteRef);
				
				int Severity = result.ReturnCode.Value;
				PDeciAttr1Label = result.PDeciAttr1Label;
				PDeciAttr2Label = result.PDeciAttr2Label;
				PDeciAttr3Label = result.PDeciAttr3Label;
				PDeciAttr4Label = result.PDeciAttr4Label;
				PDeciAttr5Label = result.PDeciAttr5Label;
				PDeciAttr6Label = result.PDeciAttr6Label;
				PDeciAttr7Label = result.PDeciAttr7Label;
				PDeciAttr8Label = result.PDeciAttr8Label;
				PDeciAttr9Label = result.PDeciAttr9Label;
				PDeciAttr10Label = result.PDeciAttr10Label;
				PCharAttr1Label = result.PCharAttr1Label;
				PCharAttr2Label = result.PCharAttr2Label;
				PCharAttr3Label = result.PCharAttr3Label;
				PCharAttr4Label = result.PCharAttr4Label;
				PCharAttr5Label = result.PCharAttr5Label;
				PCharAttr6Label = result.PCharAttr6Label;
				PCharAttr7Label = result.PCharAttr7Label;
				PCharAttr8Label = result.PCharAttr8Label;
				PCharAttr9Label = result.PCharAttr9Label;
				PCharAttr10Label = result.PCharAttr10Label;
				PLogiAttrLabel = result.PLogiAttrLabel;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertItemPiecesForPurchaseOrderReveicingSp(string RefNum,
		int? RefLineSuffix,
		int? RefRelease,
		string Item,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertItemPiecesForPurchaseOrderReveicingExt = new InsertItemPiecesForPurchaseOrderReveicingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertItemPiecesForPurchaseOrderReveicingExt.InsertItemPiecesForPurchaseOrderReveicingSp(RefNum,
				RefLineSuffix,
				RefRelease,
				Item,
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
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOrUpdateForItemPiecesMvSp(Guid? FromPiecesRowPointer,
		string Item,
		string Whse,
		string FromLoc,
		string ToLoc,
		string FromLot,
		string ToLot,
		int? PieceCount,
		int? Adjustment,
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
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOrUpdateForItemPiecesMvExt = new InsertOrUpdateForItemPiecesMvFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOrUpdateForItemPiecesMvExt.InsertOrUpdateForItemPiecesMvSp(FromPiecesRowPointer,
				Item,
				Whse,
				FromLoc,
				ToLoc,
				FromLot,
				ToLot,
				PieceCount,
				Adjustment,
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
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForAttributesSp(string ValColName,
		string Value,
		string Type,
		Guid? RefRowPointer,
		ref Guid? RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOverrideForAttributesExt = new InsertOverrideForAttributesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOverrideForAttributesExt.InsertOverrideForAttributesSp(ValColName,
				Value,
				Type,
				RefRowPointer,
				RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RowPointer = result.RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForItemPiecesSp(string Item,
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
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? ExitImmediately,
		[Optional] ref Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOverrideForItemPiecesExt = new InsertOverrideForItemPiecesFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOverrideForItemPiecesExt.InsertOverrideForItemPiecesSp(Item,
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
				Infobar,
				ExitImmediately,
				RowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				RowPointer = result.RowPointer;
				return Severity;
			}
		}
    }
}
