//PROJECT NAME: MaterialExt
//CLASS NAME: SLLotAlls.cs

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
    [IDOExtensionClass("SLLotAlls")]
    public class SLLotAlls : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTransRestrictionCodeSp(string Site,
		                                     string Item,
		                                     string Lot,
		                                     ref string TransRestrictionCode,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetTransRestrictionCodeExt = new GetTransRestrictionCodeFactory().Create(appDb);
				
				var result = iGetTransRestrictionCodeExt.GetTransRestrictionCodeSp(Site,
				                                                                   Item,
				                                                                   Lot,
				                                                                   TransRestrictionCode,
				                                                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				TransRestrictionCode = result.TransRestrictionCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertOverrideForItemLotAttrAllSp(string Item,
		string Lot,
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
		string LotAttrGroup,
		string SiteRef,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertOverrideForItemLotAttrAllExt = new InsertOverrideForItemLotAttrAllFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertOverrideForItemLotAttrAllExt.InsertOverrideForItemLotAttrAllSp(Item,
				Lot,
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
				LotAttrGroup,
				SiteRef,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
