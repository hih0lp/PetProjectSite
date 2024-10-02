using System.Runtime.Serialization.Formatters.Binary;

namespace PetProjectC_NeuroWeb.Modules.ProductModule.Core
{
    public class ProductOperations
    {
        public async Task AddProductToCatalog(HttpContext context)
        {
            var form = context.Request.Form;

            string productId = Guid.NewGuid().ToString();
            var descriptionImage = form["description"].ToString();
            var files = form.Files;

            using(var ms = new MemoryStream())
            {
                foreach (var file in files)
                {
                    await file.CopyToAsync(ms);
                }

                byte[] imagesBytes = ms.ToArray();
                List<string> listImages = new List<string>();


                foreach (var image in imagesBytes)
                {
                    listImages.Add(Convert.ToString(image));
                }

                using(var db = new ProductDataBase())
                {
                    var products = db.Products.ToList();
                    Product product = new Product(productId, listImages, descriptionImage);
                }
            }
            
        }
    }
}
