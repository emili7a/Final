namespace Final_Project.ViewModels.CommentViewModels
{
    public class CommentAdminVM
    {
      
       
            public int Id { get; set; }
            public string FoodName { get; set; }

            public string UserName { get; set; }
            public string Message { get; set; }
            public int Rating { get; set; }
            public DateTime CreatedAt { get; set; }

            public bool IsApproved { get; set; }
        

    }
}
