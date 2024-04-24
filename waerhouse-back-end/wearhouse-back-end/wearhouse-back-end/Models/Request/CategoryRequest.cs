namespace wearhouse_back_end.Models.Request
{
    public class AddCategoryRequest
    {
        public string UserID { get; set; }
        public string Category { get; set; }
    }
    public class EditCategoryRequest
    {
        public string UserID { get; set; }
        public string CategoryID { get; set; }
        public string Category { get; set; }
    }
    public class DeleteCategoryRequest
    {
        public string UserID { get; set; }
        public string CategoryID { get; set; }
    }
}
