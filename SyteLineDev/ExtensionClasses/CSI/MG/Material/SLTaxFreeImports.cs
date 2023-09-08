//PROJECT NAME: MaterialExt
//CLASS NAME: SLTaxFreeImports.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLTaxFreeImports")]
    public class SLTaxFreeImports : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteTaxFreeImportsSp(string StartingImportDocId,
		                                  string EndingImportDocId,
		                                  DateTime? CutoffDate,
		                                  short? CutoffDateOffset,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteTaxFreeImportsExt = new DeleteTaxFreeImportsFactory().Create(appDb);
				
				int Severity = iDeleteTaxFreeImportsExt.DeleteTaxFreeImportsSp(StartingImportDocId,
				                                                               EndingImportDocId,
				                                                               CutoffDate,
				                                                               CutoffDateOffset,
				                                                               ref Infobar);
				
				return Severity;
			}
		}
    }
}
