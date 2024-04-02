namespace JokeApp.Contants
{
    public class ApplicationConstants
    {
    }

    public class ResponseCodeConstants
    {
        public const string NOT_FOUND = "Not found!";
        public const string SUCCESS = "Success!";
        public const string FAILED = "Failed!";
        public const string EXISTED = "Existed!";
    }
    public class JokesCookie
    {
        public const string JokesCookieName = "voted_jokes";
    }
    public class ReponseDataJoke
    {
        public const string JOKE_NOT_FOUND = "That's all the jokes for today! Come back another day!";
    }
    public class ReponseMessageConstantsJoke
    {
        public const string JOKE_NOT_FOUND = "No jokes found.";
        public const string JOKE_EXISTED = "The joke already exists.";
        public const string UPDATE_JOKE_SUCCESS = "Successfully updated the joke.";
        public const string DELETE_JOKE_SUCCESS = "Successfully deleted the joke.";
    }
    public class ReponseMessageConstantsVote
    {
        public const string VOTE_SUCCESS = "Vote recorded successfully.";
    }
}
