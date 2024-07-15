using EasyOAuth.Handler;

namespace EasyOAuth;

public class HandlerReceive : IHandlerReceiveToken // штука разных доп махинаций с токеном, там подключить к юзеру и т.д.
{
    public void TokenHandler(string token)
    {
        throw new NotImplementedException();
    }
}