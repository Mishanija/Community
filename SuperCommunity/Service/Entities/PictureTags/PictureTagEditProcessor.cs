

using System.Collections.Generic;
using System.Linq;
using SuperCommunity.DAO.Pictures.Crud;
using SuperCommunity.DAO.PictureTags.Crud;
using SuperCommunity.DAO.Tags.Crud;
using SuperCommunity.Models.Entities;
using SuperCommunity.Models.Membership;
using SuperCommunity.Models.PageModels;

namespace SuperCommunity.Service.Entities.PictureTags
{
    public class PictureTagEditProcessor : IService
    {
        private List<string> _forDelete;

        private List<string> _forCreate;

        public void ToEditTags(EditTagsModel model)
        {
            // распределяет по коллекциям для добавления (если объекта еще не существует) 
            // или удаления (если объект уже существует) тэгов
            FirstStage(model.SelectTags);
            
            var pictureId = new PictureFindDao().GetPictureIdByPictureUrl(model.PictureUrl);

            var pictureTagsForPicture = new PictureTagFindDao().GetPictureTagsForPicture(pictureId);
            
            // Удаление ненужных тэгов
            new PictureTagDeleteDao().DeleteListOfPictureTags(GetPictureTagsForDelete(pictureTagsForPicture));
            
            // Создание необходимых тэгов
            new PictureTagCreateDao().CreateTagsForPicture(pictureId, GetPictureTagsForCreate(pictureTagsForPicture));
        }

        private List<int> GetPictureTagsForCreate(IEnumerable<PictureTag> pictureTags)
        {
            return _forCreate.Select(createTag => new TagFindDao().GetTagIdByTagName(createTag)).Where(tagId => tagId != 0).Where(tagId => !CheckExistTag(pictureTags, tagId)).ToList();
        }

        private List<int> GetPictureTagsForDelete(List<PictureTag> pictureTags)
        {
            // список id PictureTag для удаления
            var forDelete = new List<int>();

            if (pictureTags.Count != 0)
            {
                foreach (var deleteTag in _forDelete)
                {
                    var tagId = new TagFindDao().GetTagIdByTagName(deleteTag);

                    if (tagId != 0)
                    {
                        forDelete.AddRange(from existTag in pictureTags where existTag.TagId == tagId select existTag.PictureTagId);
                    }
                }
            }
            return forDelete;
        }

        private bool CheckExistTag(IEnumerable<PictureTag> pictureTags, int tagId)
        {
            return pictureTags.Any(pictureTag => pictureTag.TagId == tagId);
        }

        private void FirstStage(IEnumerable<SelectTag> selectTags)
        {
            _forDelete = new List<string>();

            _forCreate = new List<string>();

            foreach (var selectTag in selectTags)
            {
                if (selectTag.IsSelected)
                {
                    _forCreate.Add(selectTag.TagName);
                }
                else
                {
                    _forDelete.Add(selectTag.TagName);
                }
            }
            //_forCreate.Add("ccc");

            //_forDelete.Add("ddd");
        }

    }
}