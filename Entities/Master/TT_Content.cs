namespace TechTree_MVC.Entities.Master
{
    public class TT_Content
    {
        public int    Id                      { get; set; }
        public string Title                   { get; set; }
        public string HTMLContent             { get; set; }
        public string VideoLink               { get; set; }
        public TT_M_CategoryItem CategoryItem { get; set; }
    }
}
