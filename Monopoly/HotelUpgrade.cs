namespace Monopoly
{
    public class HotelUpgrade : IPropertyUpgrade
    {
        private PropertyCell _property;

        public HotelUpgrade(PropertyCell property)
        {
            _property = property;
        }

        public int GetRent()
        {
            return _property.Price * 2;
        }

        public void TryUpgrade(Player player)
        {
            Console.WriteLine($"Отель на {_property.Name} уже построен, дальше улучшать некуда");
        }

        public int GetLvl()
        {
            return 4;
        }
    }
}