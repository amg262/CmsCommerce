namespace CmsCommerce.Models.Comment;

public class CommentUser : BlockData
{
    public virtual string Email { get; set; }
    public virtual string UserName { get; set; }
}