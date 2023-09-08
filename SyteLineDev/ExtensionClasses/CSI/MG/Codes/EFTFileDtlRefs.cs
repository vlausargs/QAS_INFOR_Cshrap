//PROJECT NAME: CodesExt
//CLASS NAME: EFTFileDtlRefs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("EFTFileDtlRefs")]
	public class EFTFileDtlRefs : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int EFTFiledtlrefInsSp(decimal? VarBatchId,
		                              decimal? dtlSequence,
		                              string RefType,
		                              string RefObject,
		                              Guid? RefRowPointer,
		                              string VarFileName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iEFTFiledtlrefInsExt = new EFTFiledtlrefInsFactory().Create(appDb);
				
				int Severity = iEFTFiledtlrefInsExt.EFTFiledtlrefInsSp(VarBatchId,
				                                                       dtlSequence,
				                                                       RefType,
				                                                       RefObject,
				                                                       RefRowPointer,
				                                                       VarFileName);
				
				return Severity;
			}
		}
	}
}
