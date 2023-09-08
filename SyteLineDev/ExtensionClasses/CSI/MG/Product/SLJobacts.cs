//PROJECT NAME: ProductExt
//CLASS NAME: SLJobacts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLJobacts")]
    public class SLJobacts : ExtensionClassBase, IExtFTSLJobacts
    {

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateJobCompEsigSp(string UserName,
		string ReasonCode,
		string Job,
		string Suffix,
		string Item,
		string OperNum,
		string Qty,
		string Loc,
		[Optional] string ContainerNum,
		string Lot,
		string Project,
		ref Guid? EsigRowpointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCreateJobCompEsigExt = new CreateJobCompEsigFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCreateJobCompEsigExt.CreateJobCompEsigSp(UserName,
				ReasonCode,
				Job,
				Suffix,
				Item,
				OperNum,
				Qty,
				Loc,
				ContainerNum,
				Lot,
				Project,
				EsigRowpointer);
				
				int Severity = result.ReturnCode.Value;
				EsigRowpointer = result.EsigRowpointer;
				return Severity;
			}
		}
    }
}
