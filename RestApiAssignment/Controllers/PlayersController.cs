using Football;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiAssignment.Manager;

namespace RestApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private FootballPlayersManager _manager = new FootballPlayersManager();

        // GET: api/<PlayersController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll([FromQuery] string? nameFilter)
        {
            IEnumerable<FootballPlayer> playerList = _manager.GetAll(nameFilter);
            if (playerList.Count() == 0)
            {
                return NoContent();
            }
            return Ok(playerList);
        }

        // GET api/<PlayersController>/5
        [HttpGet]
        [Route("{id}")]
        public FootballPlayer? Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<PlayersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer newPlayer)
        {
            try
            {
                FootballPlayer createdPlayer = _manager.Add(newPlayer);
                return Created("api/players/" + createdPlayer.Id, createdPlayer);
            }
            catch (Exception ex)
          when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public FootballPlayer? Put(int id, [FromBody] FootballPlayer updates)
        {
            return _manager.Update(id, updates);
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public FootballPlayer? Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
