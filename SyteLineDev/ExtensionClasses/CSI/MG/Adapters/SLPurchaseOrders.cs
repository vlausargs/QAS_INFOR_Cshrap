//PROJECT NAME: AdaptersExt
//CLASS NAME: SLPurchaseOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Material;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Adapters;
using CSI.Data.RecordSets;

namespace CSI.MG.Adapters
{
    [IDOExtensionClass("SLPurchaseOrders")]
    public class SLPurchaseOrders : ExtensionClassBase, IExtFTSLPurchaseOrders
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CfgLinkGIDToIDSp(string pItem,
		string pCoType,
		string pCoNum,
		int? pCoLine,
		int? pCoRelease,
		string pConfigGID,
		ref string rConfigId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCfgLinkGIDToIDExt = new CfgLinkGIDToIDFactory().Create(appDb);
				
				var result = iCfgLinkGIDToIDExt.CfgLinkGIDToIDSp(pItem,
				pCoType,
				pCoNum,
				pCoLine,
				pCoRelease,
				pConfigGID,
				rConfigId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				rConfigId = result.rConfigId;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ExpandKyByTypeSp(string DataType,
		string Key,
		[Optional, DefaultParameterValue(null)] string Site,
		ref string Result)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iExpandKyByTypeExt = new ExpandKyByTypeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iExpandKyByTypeExt.ExpandKyByTypeSp(DataType,
				Key,
				Site,
				Result);
				
				int Severity = result.ReturnCode.Value;
				Result = result.Result;
				return Severity;
			}
		}
    }
}
