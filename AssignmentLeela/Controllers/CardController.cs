using AssignmentLeela.Common;
using AssignmentLeela.Manager;
using AssignmentLeela.POCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentLeela.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        

        private readonly ICardManager _cardManager;

        public CardController(ICardManager cardManager)
        {
            _cardManager = cardManager;
        }

        [HttpPost]
        [Route("GetSortedDeck")]
        public async Task<IActionResult> GetSortedDeck([FromBody] List<string> inputList)
        {
            try
            {
                //List<string> inputList = JsonConvert.DeserializeObject<List<string>>(inputWrapper.inputCards);
                List<string> sortedDeck = await _cardManager.SortDeckOfCards(inputList);
                return Ok(sortedDeck);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message.ToString());
            }
        }

        
    }
}
