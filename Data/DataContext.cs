using BasicCrudApi.Models;

namespace BasicCrudApi.Data;

public class DataContext
{
    public static List<User> Users = new List<User>();
    public static List<Post> Posts = new List<Post>();
    public static List<Comment> Comments = new List<Comment>();
}