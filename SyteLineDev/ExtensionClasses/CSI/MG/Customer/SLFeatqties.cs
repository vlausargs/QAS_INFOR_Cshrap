//PROJECT NAME: CustomerExt
//CLASS NAME: SLFeatqties.cs

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
	[IDOExtensionClass("SLFeatqties")]
	public class SLFeatqties : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int FeatQtySaveSp(string CoNum,
		int? CoLine,
		string Feature,
		string OptCode,
		decimal? MatlQtyConv,
		string UM,
		string Item,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iFeatQtySaveExt = new FeatQtySaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iFeatQtySaveExt.FeatQtySaveSp(CoNum,
				CoLine,
				Feature,
				OptCode,
				MatlQtyConv,
				UM,
				Item,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemCreateFromFeatStrSp(string FeatStr,
		string Item,
		string CurrCode,
		decimal? ContractPrice,
		string CoNum,
		int? CoLine,
		decimal? IncPrice,
		ref string NewItem,
		ref string Infobar,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemCreateFromFeatStrExt = new ItemCreateFromFeatStrFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemCreateFromFeatStrExt.ItemCreateFromFeatStrSp(FeatStr,
				Item,
				CurrCode,
				ContractPrice,
				CoNum,
				CoLine,
				IncPrice,
				NewItem,
				Infobar,
				Site);
				
				int Severity = result.ReturnCode.Value;
				NewItem = result.NewItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemFeatureCheckSp(string FeatStr,
		string PlanningItem,
		string FeatQtys,
		ref string NewItem,
		ref string InvparmsCreateFeat,
		ref string CreateItemMsg,
		ref string CreateItemButtons,
		ref string Infobar,
		ref string ItemDesc,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemFeatureCheckExt = new ItemFeatureCheckFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemFeatureCheckExt.ItemFeatureCheckSp(FeatStr,
				PlanningItem,
				FeatQtys,
				NewItem,
				InvparmsCreateFeat,
				CreateItemMsg,
				CreateItemButtons,
				Infobar,
				ItemDesc,
				Site);
				
				int Severity = result.ReturnCode.Value;
				NewItem = result.NewItem;
				InvparmsCreateFeat = result.InvparmsCreateFeat;
				CreateItemMsg = result.CreateItemMsg;
				CreateItemButtons = result.CreateItemButtons;
				Infobar = result.Infobar;
				ItemDesc = result.ItemDesc;
				return Severity;
			}
		}
	}
}
