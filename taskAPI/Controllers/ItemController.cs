using Microsoft.AspNetCore.Mvc;

namespace taskAPI.Controllers
{
    [ApiController]
    [Route("Item")]
    public class ItemController : Controller
    {
        [HttpGet("test")]

        public string Test()
        {
            return "plswork";
        }

        [HttpGet("GetAll")]
        
        public ActionResult<List<Item>> Get()
        {
            Console.WriteLine("pls");
            return Ok(DataContext.items);

        }


        [HttpPost("AddOrUpdate")]
        public ActionResult<Item> AddOrUpdate([FromBody] Item item)
        {
            Console.WriteLine("Here :)");
            if(item == null)
            {
                return BadRequest();
            }

            for(int i = 0; i < DataContext.items.Count; i++)
            {
                if (DataContext.items[i].Name == item.Name)
                {
                    DataContext.items.RemoveAt(i);
                    DataContext.items.Insert(i, item);

                    return Ok(item);
                }
            }

            DataContext.items.Add(item);
            return Ok(item);
        }

        [HttpPost("Delete")]
        public ActionResult<Item> Delete([FromBody] string name)
        {
            for (int i = 0; i < DataContext.items.Count; i++)
            {
                if (DataContext.items[i].Name == name)
                {
                    DataContext.items.RemoveAt(i);
                    return Ok(name);
                }
            }

            return Ok(name);
        }

        [HttpPost("UpdateList")]
        public ActionResult<List<Item>> UpdateList([FromBody] List<Item> newItems)
        {
            DataContext.items.Clear();
            for(int i = 0; i < newItems.Count; i++)
            {
                DataContext.items.Add(newItems[i]);
            }
            return Ok(newItems);
        }
    }
}
