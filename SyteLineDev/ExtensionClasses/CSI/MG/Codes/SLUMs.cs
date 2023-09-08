//PROJECT NAME: CodesExt
//CLASS NAME: SLUMs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Codes
{
    [IDOExtensionClass("SLUMs")]
    public class SLUMs : CSIExtensionClassBase, IExtFTSLUMs
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UMConvQtySp(string UM,
		                       string Item,
		                       [Optional] string VendNum,
		                       string Area,
		                       byte? ConvertToBase,
		                       decimal? QtyToBeConverted,
		                       ref decimal? OutQty,
		                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUMConvQtyExt = new UMConvQtyFactory().Create(appDb);
				
				var result = iUMConvQtyExt.UMConvQtySp(UM,
				                                       Item,
				                                       VendNum,
				                                       Area,
				                                       ConvertToBase,
				                                       QtyToBeConverted,
				                                       OutQty,
				                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				OutQty = result.OutQty;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfInitUm([Optional] ref string Infobar)
		{
			var iPmfInitUmExt = new PmfInitUmFactory().Create(this, true);
			
			var result = iPmfInitUmExt.PmfInitUmSp(Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

    }
}
