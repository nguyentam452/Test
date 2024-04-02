using AutoMapper;
using JokeApp.Contants;
using JokeApp.Dtos;
using JokeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JokeApp.Controllers
{
    [ApiController]
    public class JokeController : ControllerBase
    {
        private readonly JokeAppDbXontext _context;
        private readonly IMapper _mapper;
        public JokeController(JokeAppDbXontext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        [HttpGet]
        [Route(WebApiEndpoint.JokeEndpoint.GetJokeVote)]
        public IActionResult GetRandomJoke(string id)
        {
            //var readJokes = Request.Cookies[JokesCookie.JokesCookieName]?.Split(',').ToList() ?? new List<string>();
            var listid = id?.Split(',').ToList() ?? new List<string>();

            var unreadJokes = _context.Joke.Where(j => !listid.Contains(j.Id));

            var randomJoke = unreadJokes.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            if (randomJoke == null)
            {
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, message: ReponseDataJoke.JOKE_NOT_FOUND));
            }

            return Ok(new BaseResponseModel<Joke?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: randomJoke));

        }
        
        [HttpGet]
        [Route(WebApiEndpoint.JokeEndpoint.GetAllJoke)]

        public async Task<ActionResult<IEnumerable<Joke>>> GetJokes()
        {
            var result =  await _context.Joke.ToListAsync();
            if(result.Count == 0)
            {
                return NotFound(new BaseResponseModel<string>(statusCode: StatusCodes.Status404NotFound, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsJoke.JOKE_NOT_FOUND));

            }
            else
            {
                return Ok(new BaseResponseModel<ICollection<Joke>?>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));

            }

        }
        [HttpGet]
        [Route(WebApiEndpoint.JokeEndpoint.GetJoke)]

        public async Task<ActionResult<IEnumerable<Joke>>> GetJokesById(string id)
        {
            try
            {
                var result = await _context.Joke.FindAsync(id);

                if (result == null)
                {
                    return NotFound(new BaseResponseModel<string>(statusCode: StatusCodes.Status404NotFound, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsJoke.JOKE_NOT_FOUND));
                }

                return Ok(new BaseResponseModel<Joke>(statusCode: StatusCodes.Status200OK, code: ResponseCodeConstants.SUCCESS, data: result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponseModel<string>(statusCode: StatusCodes.Status500InternalServerError, code: ResponseCodeConstants.FAILED, message: ex.Message));
            }
        }

        [HttpPost]
        [Route(WebApiEndpoint.JokeEndpoint.AddJoke)]
        public async Task<ActionResult<JokeDto>> PostJokes(JokeDto joke)
        {
            var entity = _mapper.Map<Joke>(joke);
            _context.Joke.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status201Created, code: ResponseCodeConstants.SUCCESS, data: entity.Id));

        }

        [HttpPut]
        [Route(WebApiEndpoint.JokeEndpoint.UpdateJoke)]
        public async Task<IActionResult> PutJoke(string id, JokeDto joke)
        {
            var entity = _context.Joke.Where(x => x.Id == id).FirstOrDefault();
            if(entity != null)
            {
                _mapper.Map(joke, entity);
                _context.Joke.Update(entity);
                await _context.SaveChangesAsync();
                return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsJoke.UPDATE_JOKE_SUCCESS));
            }
            else
            {
                return NotFound(new BaseResponseModel<string>(statusCode: StatusCodes.Status404NotFound, code: ResponseCodeConstants.NOT_FOUND, data: ReponseMessageConstantsJoke.JOKE_NOT_FOUND));

            }
        }

        [HttpDelete]
        [Route(WebApiEndpoint.JokeEndpoint.DeleteJoke)]
        public async Task<IActionResult> DeleteJoke(string id)
        {
            var joke = await _context.Joke.FindAsync(id);
            if (joke == null)
            {
                var result = new BaseResponseModel<string>(statusCode: StatusCodes.Status400BadRequest, code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsJoke.JOKE_NOT_FOUND);
                return BadRequest(result);
            }
            _context.Joke.Remove(joke);
            await _context.SaveChangesAsync();

            return Ok(new BaseResponseModel<string>(statusCode: StatusCodes.Status202Accepted, code: ResponseCodeConstants.SUCCESS, data: ReponseMessageConstantsJoke.DELETE_JOKE_SUCCESS));
        }

       
    }
}
