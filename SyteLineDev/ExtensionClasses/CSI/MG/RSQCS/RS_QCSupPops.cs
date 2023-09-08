//PROJECT NAME: RSQCSExt
//CLASS NAME: RS_QCSupPops.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.Quality;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.RSQCS
{
	[IDOExtensionClass("RS_QCSupPops")]
	public class RS_QCSupPops : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RSQC_GetQCItemRowidSp(string i_Item,
		string i_RefType,
		string i_VendNum,
		string i_CustNum,
		int? i_OperNum,
		int? i_TestSeq,
		ref Guid? o_RowPointer,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRSQC_GetQCItemRowidExt = new RSQC_GetQCItemRowidFactory().Create(appDb);
				
				var result = iRSQC_GetQCItemRowidExt.RSQC_GetQCItemRowidSp(i_Item,
				i_RefType,
				i_VendNum,
				i_CustNum,
				i_OperNum,
				i_TestSeq,
				o_RowPointer,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				o_RowPointer = result.o_RowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
