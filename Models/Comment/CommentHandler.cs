using static EPiServer.Core.PageReference;

namespace CmsCommerce.Models.Comment;

public class CommentHandler : ContentReference
{
    private readonly IContentRepository _contentRepository;

    public CommentHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public void CreateAComment()
    {
        Comment comment =
            _contentRepository.Get<Comment>(RootPage, EPiServer.Globalization.ContentLanguage.PreferredCulture);
        comment.Name = "acomment";
        comment.User.Email = "user@test.com";
        comment.Body = "This is a comment";

        var contentLink = _contentRepository.Save(comment, EPiServer.DataAccess.SaveAction.Publish,
            EPiServer.Security.AccessLevel.NoAccess);
        var loadedComment = _contentRepository.Get<Comment>(contentLink);

        System.Diagnostics.Debug.Assert(comment.User.Email == loadedComment.User.Email);
        System.Diagnostics.Debug.Assert(comment.Body == loadedComment.Body);

        //return comment;
    }
}