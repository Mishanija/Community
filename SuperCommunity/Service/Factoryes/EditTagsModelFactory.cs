using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.DAO.Tags.Crud;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Membership;
using SuperCommunity.Models.PageModels;

namespace SuperCommunity.Service.Factoryes
{
    public class EditTagsModelFactory : ModelFactory<EditTagsModel>
    {
        private readonly int _pictureId;

        /// <summary>
        /// Тэги, которые на данный момент есть
        /// у выбранной картинки (по id)
        /// </summary>
        private readonly List<PictureTag> _pictureTags;

        public EditTagsModelFactory(int pictureId)
        {
            _pictureId = pictureId;

            _pictureTags = new PictureTagFindDao().GetPictureTagsForPicture(pictureId);
        }

        public override EditTagsModel BuildModel()
        {
            var tags = new TagFindDao().GetAllTags();

            var selectTags = tags.Select
                (tag => new SelectTag { TagName = tag.TagName, IsSelected = IsExist(tag.TagId) }).ToList();

            var picture = new PictureFindDao().GetObjectById(_pictureId);

            return new EditTagsModel { PictureUrl = picture.PictureUrl, SelectTags = selectTags };
        }

        private bool IsExist(int tagId)
        {
            return _pictureTags.Any(pictureTag => pictureTag.TagId == tagId);
        }
    }
}