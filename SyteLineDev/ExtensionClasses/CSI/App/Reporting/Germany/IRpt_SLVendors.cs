﻿//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SLVendors.cs

using CSI.Data.CRUD;
using System;

namespace CSI.Reporting.Germany
{
    public interface IRpt_SLVendors : IRpt_GOBDUMediaService
    {
        (ICollectionLoadResponse Data, int? ReturnCode) Rpt_SLVendorsSp(DateTime? TransDateBeg, DateTime? TransDateEnd, string SiteID);
    }
}