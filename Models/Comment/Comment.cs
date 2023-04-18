namespace CmsCommerce.Models.Comment;

public class CommentUser : BlockData
{
    public virtual string Email { get; set; }
    public virtual string UserName { get; set; }
}

public class Comment : IContent
{
    public virtual CommentUser User { get; set; }
    public virtual string Body { get; set; }

    public virtual DateTime Created { get; set; }
    public int ContentTypeID { get; set; }
    public bool IsDeleted { get; set; }
    public string Name { get; set; }
    public ContentReference ContentLink { get; set; }
    public ContentReference ParentLink { get; set; }
    public Guid ContentGuid { get; set; }
    public PropertyDataCollection Property { get; } = new PropertyDataCollection();
    public bool IsNull => Property.Count == 0;
}