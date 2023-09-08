﻿using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDayEndOfFactory
    {
        IDayEndOf Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}