//PROJECT NAME: MG
//CLASS NAME: co_product_batchs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Product
{
	[IDOExtensionClass("co_product_batchs")]
	public class co_product_batchs : ExtensionClassBase
	{



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SetMethodSp(string MethodValInput)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSetMethodExt = new SetMethodFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSetMethodExt.SetMethodSp(MethodValInput);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
