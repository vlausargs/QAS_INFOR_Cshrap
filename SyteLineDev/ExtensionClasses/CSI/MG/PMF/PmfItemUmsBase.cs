//PROJECT NAME: PmfExt
//CLASS NAME: PmfItemUmsBase.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.ProcessManufacturing;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PMF
{
	[IDOExtensionClass("PmfItemUmsBase")]
	public class PmfItemUmsBase : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PmfGetItemUmCnvFactor(string Item,
		string Um,
		decimal? FillQty,
		string FillUM,
		decimal? Density,
		[Optional] ref double? CnvToStock,
		[Optional] ref double? CnvFromStock)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPmfGetItemUmCnvFactExt = new PmfGetItemUmCnvFactFactory().Create(appDb);
				
				var result = iPmfGetItemUmCnvFactExt.PmfGetItemUmCnvFactor(Item,
				Um,
				FillQty,
				FillUM,
				Density,
				CnvToStock,
				CnvFromStock);
				
				int Severity = result.ReturnCode.Value;
				CnvToStock = result.CnvToStock;
				CnvFromStock = result.CnvFromStock;
				return Severity;
			}
		}
	}
}
