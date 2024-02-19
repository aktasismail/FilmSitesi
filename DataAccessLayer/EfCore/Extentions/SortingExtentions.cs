using System.Reflection;
using System.Text;

namespace DataAccessLayer.EfCore.Extentions
{
    public static class SortingExtentions
    {
        public static String SortingQuery<T>(string sortparameter)
        {
            var prmtr = sortparameter.Trim().Split(','); //gelen parametleri virgül ile ayır dizi oluştur
            var propertyinfo = typeof(T) //public ve intance propertyleri getir
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var stringbuilder = new StringBuilder();
            foreach (var item in prmtr)
            {
                if (string.IsNullOrWhiteSpace(item))
                    continue;
                var queryname = item.Split(' ')[0];
                // dizideki elemanların arasında boşluk var mı?
                var objects = propertyinfo.FirstOrDefault(//objeyi dizideki elemanla eşleştir
                    x => x.Name.Equals(queryname, StringComparison.InvariantCultureIgnoreCase));
                if (objects is null)
                    continue;
                var sorttype = item.EndsWith(" desc") ? "descending" : "ascending";
                //boşluktan sonra desc ise decnecding sırala

                stringbuilder.Append($"{objects.Name.ToString()} {sorttype},");
            }
            var query = stringbuilder.ToString().Trim(',', ' ');// dizi bitince sondaki virgülü kaldır
            return query;
        }
    }
}
