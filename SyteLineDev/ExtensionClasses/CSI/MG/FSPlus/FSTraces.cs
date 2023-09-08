//PROJECT NAME: FSPlusExt
//CLASS NAME: FSTraces.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSTraces")]
    public class FSTraces : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSTraceStopWrapSp(int? iTraceID, ref string Infobar)
		{
			var iSSSTraceStopWrapExt = new SSSTraceStopWrapFactory().Create(this, true);
			
			var result = iSSSTraceStopWrapExt.SSSTraceStopWrapSp(iTraceID, Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSTraceStartWrapSp(long? iMaxTraceSizeMB,
			ref int? oTraceID,
			ref string oServerName,
			ref string oTraceFile,
			ref string Infobar,
			string FilterDatabaseNameLike,
			string FilterHostNameLike,
			string FilterLoginNameLike,
			string FilterTextDataLike,
			string FilterObjectNameLike,
			int? FilterSPIDEQ)
		{
			var iSSSTraceStartWrapExt = this.GetService<ISSSTraceStartWrap>();

			var result = iSSSTraceStartWrapExt.SSSTraceStartWrapSp(iMaxTraceSizeMB,
				oTraceID,
				oServerName,
				oTraceFile,
				Infobar,
				FilterDatabaseNameLike,
				FilterHostNameLike,
				FilterLoginNameLike,
				FilterTextDataLike,
				FilterObjectNameLike,
				FilterSPIDEQ);

			oTraceID = result.oTraceID;
			oServerName = result.oServerName;
			oTraceFile = result.oTraceFile;
			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}
	}
}

