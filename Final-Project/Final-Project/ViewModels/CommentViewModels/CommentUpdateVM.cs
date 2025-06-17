using Final_Project.ViewModels.CommonVM;

namespace Final_Project.ViewModels.CommentViewModels
{
    public class CommentUpdateVM : BaseVM
    {
        public string Text { get; set; }
        public int BlogId { get; set; }
    }
}
