//PROJECT NAME: THLOCExt
//CLASS NAME: THANonTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.THLOC;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.THLOC
{
	[IDOExtensionClass("THANonTrans")]
	public class THANonTrans : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TH_InventoryMonthEndProcessSp(DateTime? pDateStarting,
		DateTime? pDateEnding,
		string pItemStarting,
		string pItemEnding,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTH_InventoryMonthEndProcessExt = new TH_InventoryMonthEndProcessFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTH_InventoryMonthEndProcessExt.TH_InventoryMonthEndProcessSp(pDateStarting,
				pDateEnding,
				pItemStarting,
				pItemEnding,
				pWhseStarting,
				pWhseEnding,
				pLocStarting,
				pLocEnding,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int THACreateStockBalanceConsSp(DateTime? pStartDate,
		DateTime? pEndDate,
		string pStartItem,
		string pEndItem,
		string pWhseStarting,
		string pWhseEnding,
		string pLocStarting,
		string pLocEnding,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHACreateStockBalanceConsExt = new THACreateStockBalanceConsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHACreateStockBalanceConsExt.THACreateStockBalanceConsSp(pStartDate,
				pEndDate,
				pStartItem,
				pEndItem,
				pWhseStarting,
				pWhseEnding,
				pLocStarting,
				pLocEnding,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
