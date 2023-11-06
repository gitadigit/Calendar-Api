using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Calender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        static int count = 1;
        private static List<Event> events = new List<Event> { new Event { Id = count++, Title = "event 3", Start = new DateTime(2023, 09, 16), End = new DateTime(2023, 09, 14) } } ;

        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<EventsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
          //  int count = value.Id;

            events.Add(new Event { Id = count++, Title = value.Title, Start = value.Start, End = value.End });
            return ;
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            var eventId = events.Find(eventId => eventId.Id == id);
            eventId.Title=value.Title;
            eventId.Start = value.Start;
            eventId.End = value.End;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eventId = events.Find(eventId => eventId.Id == id);
            events.Remove(eventId);
        }
    }
}
