using EasyOAuth.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace EasyOAuth;

[ApiController]
[Route("/api/oauth")]
public class AuthController(
    StrategyToken tokenAction,
    IOAuthClient oAuthService,
    ITokenLinkRepository tokenLinkRepository)
{
    [HttpGet]
    public async Task<object> Auth([FromQuery] string code, [FromQuery(Name = "state")] string state)
    {
        var token = await oAuthService.GetAccessToken(state, code);

        if (string.IsNullOrEmpty(token)) return "token not received";

        var data = await tokenLinkRepository.GetByState(state);
        await tokenLinkRepository.Remove(data);

        await tokenAction.Execute(token, data);

        return $"token is {token}";
    }

    [HttpGet("get/oauth/requests")]
    public ActionResult<List<string>> GetRequest()
    {
        return oAuthService.GetOAuthsRequests();
    }
}