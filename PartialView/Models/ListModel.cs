namespace PartialView.Models
{
    public class ListModel
    {
        public string? ListTitle { get; set; }
        public List<string>? ListContent { get; set; } = new List<string>();
    }
}
