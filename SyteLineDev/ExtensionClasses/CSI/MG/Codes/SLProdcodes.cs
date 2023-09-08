//PROJECT NAME: CodesExt
//CLASS NAME: SLProdcodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLProdcodes")]
	public class SLProdcodes : ExtensionClassBase
	{		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ChangeMarkupSp(string PProductCode,
		                          decimal? PMarkup,
		                          byte? PProceed)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProdCodeChangeMarkupExt = new ProdCodeChangeMarkupFactory().Create(appDb);
				
				var result = iProdCodeChangeMarkupExt.ProdCodeChangeMarkupSp(PProductCode,
				                                                             PMarkup,
				                                                             PProceed);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProductCodeDistAcctExistsSp(string ProductCode,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProductCodeDistAcctExistsExt = new ProductCodeDistAcctExistsFactory().Create(appDb);
				
				var result = iProductCodeDistAcctExistsExt.ProductCodeDistAcctExistsSp(ProductCode,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
