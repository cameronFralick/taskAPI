namespace taskAPI.Controllers
{
    public class DataContext
    {
        public static List<Item> items = new List<Item>
        {
            new Task("name", "desc", "deadline", true),
            new Task("name2", "desc2", "deadline2", true)
        };
    }
}
