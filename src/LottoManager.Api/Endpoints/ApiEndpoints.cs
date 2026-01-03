namespace LottoManager.Api.Endpoints;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class Lottery
    {
        private const string Base = $"{ApiBase}/lottery";

        public const string Create = Base;
    }
}