namespace Monopoly
{
    public class HouseUpgrade : IPropertyUpgrade
    {
        private PropertyCell _property;
        private int _houseCount;

        public HouseUpgrade(PropertyCell property, int houseCount = 1)
        {
            _property = property;
            _houseCount = houseCount;
        }

        public int GetRent()
        {
            return (_property.Price / 10) * (_houseCount + 1);
        }

        public void TryUpgrade(Player player)
        {
            if (_houseCount < 3 && player.Money >= _property.Price / 2)
            {
                _houseCount++;
                player.Money -= _property.Price / 2;
                Console.WriteLine($"Построен {_houseCount}-й домик на {_property.Name}");
            }
            else if (_houseCount == 3 && player.Money >= _property.Price)
            {
                _property.Upgrade = new HotelUpgrade(_property);
                player.Money -= _property.Price;
                Console.WriteLine($"Построен отель на {_property.Name}");
            }
        }

        public int GetLvl()
        {
            return _houseCount;
        }
    }
}