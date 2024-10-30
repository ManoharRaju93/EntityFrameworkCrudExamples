using ServiceContracts;

namespace Services1
{
    public class CitiesServices:ICitiesContracts
    {

        private List<string> _cities;

        public CitiesServices()
        {
            _cities = new List<string>()
            {
                "PARIS",
                "USA"
            };
        }

        public List<String> GetCities()
        {
            return _cities;
        }
    }
}
