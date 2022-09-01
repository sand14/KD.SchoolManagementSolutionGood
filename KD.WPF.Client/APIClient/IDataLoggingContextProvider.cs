using System;

namespace KD.WPF.Client.APIClient
{
    public interface IDataLoggingContextProvider
    {
        Guid? GetCurrentUserId();
        string GetCurrentUserName();
        Guid? GetCurrentAreaId();
        string GetCurrentAreaName();
        string GetCurrentModuleName();
    }
}
