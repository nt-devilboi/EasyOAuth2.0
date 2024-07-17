using EasyOAuth.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EasyOAuth;

// как варинат было бы круто, чтоб мы в program.cs добавляли только класс юзера, он бы сам соеденял этого юзера с токеном.
[ApiController]
[Route("/api/oauth")]
public class AuthController(
    IStrategyToken tokenAction,
    IOAuthClient ioAuthService,
    TokenLinkRepositoryBase tokenLinkRepository)
{
    //привет принцип OCP. класс закрыт для изменений и открыт для расширения.
    [HttpGet]
    public async Task<object> Auth([FromQuery] string code, [FromQuery(Name = "state")] string state)
    {
        var token = await ioAuthService.GetAccessToken(state, code);

        if (string.IsNullOrEmpty(token)) return "token not received";

        var data = await tokenLinkRepository.GetByState(state);
        await tokenAction.Execute(token, data);

        return $"token is {token}";
    }

    [HttpGet("get/oauth/requests")]
    public ActionResult<List<string>> GetRequest()
    {
        return ioAuthService.GetOAuthsRequests();
    }
}