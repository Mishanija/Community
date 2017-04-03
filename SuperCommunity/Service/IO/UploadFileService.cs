
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Web;
using System.Windows.Forms;
using SuperCommunity.DAO.Crud;

namespace SuperCommunity.Service.IO
{
    /// <summary>
    /// Абстрактный класс для реализации загрузки файлов на сервер
    /// </summary> 
    public abstract class UploadFileService<TEntity> : IService where TEntity : EntityObject
    {
        protected readonly FileUploader UploadFile;

        protected readonly CreateDao<TEntity> CreateObject;

        protected readonly TEntity Pattern;

        protected TEntity Obj;

        /// <summary>
        /// Конструктор с параметрами 
        /// </summary>
        /// <param name="fileUploader">Загрузчик файлов. Можно определить так: 
        /// <c>new FileUploader("\\Images\\UserPhotos\\")</c></param> 
        /// <param name="createObject">Сервис, который создает объекты нужного класса. Обычно просто 
        /// создание объекта: <c>new PictureCreateDao()</c></param>
        /// <param name="pattern">Шаблон, в котором хранятся общие свойства создаваемых объектов 
        /// (например, id пользователя, который загружает эти файлы, id альбома, куда будут помещены 
        /// файлы и т.д.)</param>
        protected UploadFileService(
            FileUploader fileUploader,
            CreateDao<TEntity> createObject,
            TEntity pattern)
        {
            UploadFile = fileUploader;
            CreateObject = createObject;
            Pattern = pattern;
        }

        /// <summary>
        /// Метод загружает файлы и создает соответствующие им
        /// объекты в базе данных. 
        /// </summary>
        public void UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                foreach (var file in files)
                {
                    Obj = CopyPattern();

                    var privateName = GetPrivateName(file.FileName);

                    UploadFile.UploadFile(file, privateName);

                    CreateObject.SaveObject(Obj);
                }
            }
            catch (HttpException)
            {
                MessageBox.Show("Ошибка! Слишком большой объем фото");
            }
        }

        /// <summary>
        /// Метод должен возвращать личное имя нового файла по 
        /// его оригинальному имени. 
        /// </summary>
        protected abstract string GetPrivateName(string fileName);

        /// <summary>
        /// Метод должен возвращать объект уже определенными 
        /// общими необходимыми параметрами
        /// </summary>
        protected abstract TEntity CopyPattern();

    }
}
