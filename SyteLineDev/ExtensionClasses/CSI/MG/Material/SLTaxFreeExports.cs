//PROJECT NAME: MaterialExt
//CLASS NAME: SLTaxFreeExports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTaxFreeExports")]
    public class SLTaxFreeExports : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTaxFreeExportsSp(string StartingExportDocId,
		string EndingExportDocId,
		DateTime? CutoffDate,
		int? CutoffDateOffset,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDeleteTaxFreeExportsExt = new DeleteTaxFreeExportsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDeleteTaxFreeExportsExt.DeleteTaxFreeExportsSp(StartingExportDocId,
				EndingExportDocId,
				CutoffDate,
				CutoffDateOffset,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
