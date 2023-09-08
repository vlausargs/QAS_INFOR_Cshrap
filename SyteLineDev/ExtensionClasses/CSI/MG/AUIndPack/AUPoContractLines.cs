//PROJECT NAME: AUIndPackExt
//CLASS NAME: AUPoContractLines.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Automotive;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.AUIndPack
{
	[IDOExtensionClass("AUPoContractLines")]
	public class AUPoContractLines : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int AU_ValidateOrderAndContractSp(string ContractID,
		                                         ref string Infobar,
		                                         [Optional] string CoNum,
		                                         [Optional] string PoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iAU_ValidateOrderAndContractExt = new AU_ValidateOrderAndContractFactory().Create(appDb);
				
				var result = iAU_ValidateOrderAndContractExt.AU_ValidateOrderAndContractSp(ContractID,
				                                                                           Infobar,
				                                                                           CoNum,
				                                                                           PoNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
