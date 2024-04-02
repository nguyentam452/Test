using AutoMapper;
using JokeApp.Contants;
using JokeApp.Dtos;
using JokeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers
{
    [ApiController]

    public class VoteController : ControllerBase
    {
        private readonly JokeAppDbXontext _context;

        public VoteController(JokeAppDbXontext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route(WebApiEndpoint.VoteEndpoint.AddJoke)]
        public IActionResult VoteJoke(VoteDto vote)
        {
            // Tạo một phiếu bầu mới
            var newVote = new Vote
            {
                JokeId = vote.JokeId,
                Liked = vote.Liked
            };

            _context.Vote.Add(newVote);
            _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

            var votedJokes = Request.Cookies[JokesCookie.JokesCookieName]?.Split(',') ?? new string[0];

            votedJokes = votedJokes.Concat(new[] { vote.JokeId }).ToArray();

            Response.Cookies.Append(JokesCookie.JokesCookieName, string.Join(',', votedJokes), new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None
            });

            return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsVote.VOTE_SUCCESS));
        }

    }
}
