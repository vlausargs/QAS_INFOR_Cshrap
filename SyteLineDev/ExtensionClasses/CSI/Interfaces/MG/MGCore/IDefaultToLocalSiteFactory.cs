﻿using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDefaultToLocalSiteFactory
    {
        IDefaultToLocalSite Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}