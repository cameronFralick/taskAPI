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
        
        public List<Item> Get()
        {
            SaveManager saveManager = new SaveManager();
            return saveManager.GetTasks();
        }


        [HttpPost("AddOrUpdateTask")]
        public Item AddOrUpdateTask([FromBody] Task item)
        {
            if(item == null)
            {
                return null;
            }

            SaveManager saveManager = new SaveManager();
            var items = saveManager.GetTasks();

            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    items.RemoveAt(i);
                    items.Insert(i, item);

                    return item;
                }
            }

            items.Add(item);
            saveManager.SetList(items);

            return item;
        }

        [HttpPost("AddOrUpdateAppointment")]
        public CalendarAppointment AddOrUpdateAppointment([FromBody] CalendarAppointment item)
        {
            if (item == null)
            {
                return null;
            }

            SaveManager saveManager = new SaveManager();
            var items = saveManager.GetTasks();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == item.Name)
                {
                    items.RemoveAt(i);
                    items.Insert(i, item);

                    return item;
                }
            }

            items.Add(item);
            saveManager.SetList(items);

            return item;
        }

        [HttpPost("Delete")]
        public ActionResult<Item> Delete([FromBody] string name)
        {
            SaveManager saveManager = new SaveManager();
            var items = saveManager.GetTasks();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Name == name)
                {
                    items.RemoveAt(i);
                    saveManager.SetList(items);
                    return Ok(name);
                }
            }

            return Ok(name);
        }

        [HttpPost("UpdateList")]
        public ActionResult<List<Item>> UpdateList([FromBody] List<Item> newItems)
        {
            SaveManager saveManager = new SaveManager();
            saveManager.SetList(newItems);
            DataContext.items.Clear();
            return Ok(newItems);
        }
    }
}
