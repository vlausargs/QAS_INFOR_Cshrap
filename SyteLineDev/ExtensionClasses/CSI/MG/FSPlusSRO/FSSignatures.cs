//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSignatures.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSignatures")]
    public class FSSignatures : ExtensionClassBase
    {


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int InsertSignatureWrapSp(byte[] Signature,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		DateTime? SignatureDate,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] decimal? Latitude,
		[Optional, DefaultParameterValue(0)] decimal? Longitude)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iInsertSignatureWrapExt = new InsertSignatureWrapFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iInsertSignatureWrapExt.InsertSignatureWrapSp(Signature,
				RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				SignatureDate,
				Infobar,
				Latitude,
				Longitude);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}

