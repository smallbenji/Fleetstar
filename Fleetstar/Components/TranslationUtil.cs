namespace Fleetstar.Components
{
    public class TranslationUtil
    {

        public TranslationUtil()
        {
            
        }
        
        public string GetText(string locale, string group, string key)
        {
            return $"{locale}.{group}.{key}";
        }
    }
}