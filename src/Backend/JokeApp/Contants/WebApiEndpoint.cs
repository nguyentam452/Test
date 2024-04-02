namespace JokeApp.Contants
{
    public class WebApiEndpoint
    {
        public const string AreaName = "api";

        public static class JokeEndpoint
        {
            private const string BaseEndpoint = "~/" + AreaName + "/joke";
            public const string GetJoke = BaseEndpoint + "/get-single" + "/{id}";
            public const string GetAllJoke = BaseEndpoint + "/get-all";
            public const string GetJokeVote = BaseEndpoint + "/get-joke";
            public const string AddJoke = BaseEndpoint + "/add";
            public const string UpdateJoke = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteJoke = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class VoteEndpoint
        {
            private const string BaseEndpoint = "~/" + AreaName + "/vote";
            public const string AddJoke = BaseEndpoint + "/add";
        }
    }
}
