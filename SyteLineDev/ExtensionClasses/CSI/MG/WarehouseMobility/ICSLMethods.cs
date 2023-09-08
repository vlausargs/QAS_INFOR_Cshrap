//PROJECT NAME: MG
//CLASS NAME: ICSLMethods.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.WarehouseMobility;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.WarehouseMobility
{
	[IDOExtensionClass("ICSLMethods")]
	public class ICSLMethods : CSIExtensionClassBase, IExtFTICSLMethods
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ICUpdateUserInitialSp(string UserInitial,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

				var iICUpdateUserInitialExt = new ICUpdateUserInitialFactory().Create(appDb);

				var result = iICUpdateUserInitialExt.ICUpdateUserInitialSp(UserInitial,
				Infobar);

				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int NextTrnSp(string Context,
		string Prefix,
		int? KeyLength,
		ref string Key,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iNextTrnExt = new NextTrnFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iNextTrnExt.NextTrnSp(Context,
				Prefix,
				KeyLength,
				Key,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Key = result.Key;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TransAddSp(string PTrnNum,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		string PToRefType,
		string PToRefNum,
		int? PToRefLineSuf,
		int? PToRefRelease,
		int? PFromMrpFirm,
		string PRcptsRefNum,
		ref string CurTrnNum,
		ref int? CurTrnLine,
		string TrnLoc,
		string FOBSite,
		ref int? ItemLocQuestionAsked,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? CreateTransitLoc)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTransAddExt = new TransAddFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTransAddExt.TransAddSp(PTrnNum,
				PItem,
				PFromSite,
				PFromWhse,
				PToSite,
				PToWhse,
				PQtyOrdered,
				PDueDate,
				PToRefType,
				PToRefNum,
				PToRefLineSuf,
				PToRefRelease,
				PFromMrpFirm,
				PRcptsRefNum,
				CurTrnNum,
				CurTrnLine,
				TrnLoc,
				FOBSite,
				ItemLocQuestionAsked,
				PromptMsg,
				PromptButtons,
				Infobar,
				CreateTransitLoc);
				
				int Severity = result.ReturnCode.Value;
				CurTrnNum = result.CurTrnNum;
				CurTrnLine = result.CurTrnLine;
				ItemLocQuestionAsked = result.ItemLocQuestionAsked;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ICCreateOrUpdatePoSp(ref string PPoNum,
		ref int? PPoLine,
		string PVendNum,
		string PItem,
		decimal? PQty,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iICCreateOrUpdatePoExt = new ICCreateOrUpdatePoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iICCreateOrUpdatePoExt.ICCreateOrUpdatePoSp(PPoNum,
				PPoLine,
				PVendNum,
				PItem,
				PQty,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PPoNum = result.PPoNum;
				PPoLine = result.PPoLine;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ICCreateOrUpdateBlanketPoSp(ref string PPoNum,
		ref int? PPoLine,
		ref int? PPoLineRelease,
		string PVendNum,
		string PItem,
		decimal? PQty,
		ref string Infobar)
		{
			var iICCreateOrUpdateBlanketPoExt = new ICCreateOrUpdateBlanketPoFactory().Create(this, true);
			
			var result = iICCreateOrUpdateBlanketPoExt.ICCreateOrUpdateBlanketPoSp(PPoNum,
			PPoLine,
			PPoLineRelease,
			PVendNum,
			PItem,
			PQty,
			Infobar);
			
			int Severity = result.ReturnCode.Value;
			PPoNum = result.PPoNum;
			PPoLine = result.PPoLine;
			PPoLineRelease = result.PPoLineRelease;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
