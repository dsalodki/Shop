using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace Warehouse.Controllers
{
    public class FileWithGoodsController : Controller
    {
        private IFileWithGoodsRepo _repository;

        public FileWithGoodsController(IFileWithGoodsRepo repository)
        {
            _repository = repository;
        }

        public FileContentResult Index()
        {
            var data = _repository.GetAll();
            StringBuilder fileData = new StringBuilder();
            fileData.AppendLine("Категория;Название;Старая цена;Новая цена");
            foreach (var goodsByCategory in data)
            {
                fileData.Append(goodsByCategory.CatName).Append(";");
                var i = 0;
                foreach (var item in goodsByCategory.Items)
                {
                    i++;
                    if (i > 1)
                    {
                        fileData.Append(";");
                    }
                    fileData.AppendLine($"{i}.{item.Name};{item.Val};{item.OldPrice};{(item.NewPrice != 0 ? item.NewPrice.ToString() : string.Empty)}");
                }
            }
            var csv = fileData.ToString();
            var bytes = new UTF8Encoding().GetBytes(csv);
            var result = Encoding.UTF8.GetPreamble().Concat(bytes).ToArray();
            return File(result, "text/csv", "Report.csv");
        }
    }
}
