
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.DAO.Tags.Crud;

namespace SuperCommunity.Service.Entities.Tags
{
    public class DeleteTagService : IService
    {
        public void DeleteTag(int id)
        {
            var pictureTags = new PictureTagFindDao().GetPictureTagIdsByTagId(id);

            var dao = new PictureTagDeleteDao();

            dao.DeleteListOfPictureTags(pictureTags);

            new TagDeleteDao().DeleteTag(id);
        }
    }
}