
namespace CoreLayer.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key); //Hər iki Get Eynidir.
        void Add(string key, object value,int duration); //Gələcət Data- object. Duration - keşdə qalacaq zaman müddəti
        bool IsAdd(string key); //Keş də varmı? Əgər varsa Keşdən gətir yoxsa datanı gətir keşə əlavə et
        void Remove(string key); //Keşdən silmə
        void RemoveByPattern(string pattern);
    }
}
