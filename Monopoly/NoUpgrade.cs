namespace Monopoly
{
    public class NoUpgrade : IPropertyUpgrade
    {
        private PropertyCell _property;

        public NoUpgrade(PropertyCell property)
        {
            _property = property;
        }

        public int GetRent()
        {
            return _property.Price / 10;
        }

        public void TryUpgrade(Player player)
        {
            if (player.HasMonopoly(_property.Color) && player.Money >= _property.Price / 2)
            {
                _property.Upgrade = new HouseUpgrade(_property);
                player.Money -= _property.Price / 2;
                Console.WriteLine($"Построен 1-й домик на {_property.Name}");
            }
        }

        public int GetLvl()
        {
            return 0;
        }
    }
}