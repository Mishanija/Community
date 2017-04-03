
using System.Linq;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.DAO.Tags.Crud;
using SuperCommunity.Models;
using SuperCommunity.Service.Entities.Tags;

namespace SuperCommunity.Service.Factoryes
{
    public class TagCloudModelFactory : ModelFactory<TagCloudModel>
    {
        public override TagCloudModel BuildModel()
        {
            var tags = new TagFindDao().GetAllTags();

            var dao = new PictureTagFindDao();

            var taglist = tags.Select(tag => new TagModel
            {
                PicturesCount = dao.GetPicturesCount(tag.TagId), 
                Tag = tag
            }).ToList();

            return new TagCloudModel{TagsList = taglist};
        }
    }
}