using hamaraBasket.Tests;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        Domain domain = new Domain();

        [Test]
        public void ShouldReduceSellInValueByOneEOD()
        {
            // Arrange
            var newItems = domain.PrepareItemList("foo", 10, 10);

            // Act
            domain.UpdateQualityHelper(newItems);

            // Assert
            Assert.That(newItems[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void ShouldReduceQualityByOneEOD()
        {
            // Arrange
            var newItems = domain.PrepareItemList("foo", 10, 10);

            // Act
            domain.UpdateQualityHelper(newItems);

            // Assert
            Assert.That(newItems[0].Quality, Is.EqualTo(9));
        }

        [Test]
        public void ShouldDegradeQualityTwiceAsFastAfterSellByDate()
        {
            // Arrange
            var items = domain.PrepareItemList("foo", 0, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(8));
        }

        [Test]
        public void QualityShouldNeverBeNegative()
        {
            // Arrange
            var items = domain.PrepareItemList("foo", 10, 0);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void IndianWineShouldIncreaseInQuality()
        {
            // Arrange
            var items = domain.PrepareItemList("Indian Wine", 10, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(11));
        }

        [Test]
        public void QualityShouldNeverExceedFifty()
        {
            // Arrange
            var items = domain.PrepareItemList("Indian Wine", 10, 50);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }

        [Test]
        public void ForestHoneyShouldNeverDecreaseInQuality()
        {
            // Arrange
            var items = domain.PrepareItemList("Forest Honey", 10, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(10));
        }

        [Test]
        public void MovieTicketsShouldIncreaseInQualityByTwoWhenTenDaysOrLess()
        {
            // Arrange
            var items = domain.PrepareItemList("Movie Tickets", 10, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(12));
        }

        [Test]
        public void MovieTicketsShouldIncreaseInQualityByThreeWhenFiveDaysOrLess()
        {
            // Arrange
            var items = domain.PrepareItemList("Movie Tickets", 5, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void MovieTicketsShouldDropToZeroAfterShow()
        {
            // Arrange
            var items = domain.PrepareItemList("Movie Tickets", 0, 10);

            // Act
            domain.UpdateQualityHelper(items);

            // Assert
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }
}