using lab10;
using lab12_1;
using lab121;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lab12_1.Tests
{
    [TestClass]
    public class MyListTests
    {
        [TestMethod]
        public void Data_SetAndGetCorrectValue()
        {
            // Arrange
            Carriage c = new Carriage(new IdNumber(1), 123, 200);
            Point<Carriage> p = new Point<Carriage>();

            // Act
            p.Data = c;

            // Assert
            Assert.AreEqual(c, p.Data);
        }

        [TestMethod]
        public void Data_SetNullValue()
        {
            // Arrange
            Point<Carriage> p = new Point<Carriage>();

            // Act
            p.Data = null;

            // Assert
            Assert.IsNull(p.Data);
        }

        [TestMethod]
        public void Next_SetAndGetCorrectValue()
        {
            // Arrange
            Point<Carriage> p1 = new Point<Carriage>();
            Point<Carriage> p2 = new Point<Carriage>();
            Carriage c = new Carriage(new IdNumber(1), 123, 200);

            // Act
            p1.Next = p2;
            p2.Data = c;

            // Assert
            Assert.AreEqual(p2, p1.Next);
            Assert.AreEqual(c, p1.Next.Data);
        }

        [TestMethod]
        public void Next_SetNullValue()
        {
            // Arrange
            Point<Carriage> p = new Point<Carriage>();

            // Act
            p.Next = null;

            // Assert
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void Pred_SetAndGetCorrectValue()
        {
            // Arrange
            Point<Carriage> p1 = new Point<Carriage>();
            Point<Carriage> p2 = new Point<Carriage>();
            Carriage c = new Carriage(new IdNumber(1), 123, 200);

            // Act
            p1.Pred = p2;
            p2.Data = c;

            // Assert
            Assert.AreEqual(p2, p1.Pred);
            Assert.AreEqual(c, p1.Pred.Data);
        }

        [TestMethod]
        public void Pred_SetNullValue()
        {
            // Arrange
            Point<Carriage> p = new Point<Carriage>();

            // Act
            p.Pred = null;

            // Assert
            Assert.IsNull(p.Pred);
        }

        [TestMethod]
        public void Constructor_DefaultInitialization()
        {
            // Arrange
            Point<Carriage> p = new Point<Carriage>();

            // Assert
            Assert.AreEqual(default(Carriage), p.Data);
            Assert.IsNull(p.Pred);
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void Constructor_WithDataInitialization()
        {
            // Arrange
            Carriage c = new Carriage(new IdNumber(1), 123, 200);

            // Act
            Point<Carriage> p = new Point<Carriage>(c);

            // Assert
            Assert.AreEqual(c, p.Data);
            Assert.IsNull(p.Pred);
            Assert.IsNull(p.Next);
        }

        [TestMethod]
        public void ToString_WithDataNotNull_ReturnsDataToString()
        {
            // Arrange
            Carriage c = new Carriage(new IdNumber(1), 123, 200);
            Point<Carriage> p = new Point<Carriage>(c);

            // Act
            string result = p.ToString();

            // Assert
            Assert.AreEqual(c.ToString(), result);
        }

        [TestMethod]
        public void ToString_WithDataNull_ReturnsEmptyString()
        {
            // Arrange
            Point<Carriage> p = new Point<Carriage>();

            // Act
            string result = p.ToString();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void MakeRandomData_WithDataInitialized_ReturnsPointWithData()
        {
            // Arrange
            Carriage carriage = new Carriage();
            carriage.RandomInit(); // Инициализация данных объекта Carriage

            // Act
            Point<Carriage> point = Point<Carriage>.MakeRandomData();

            // Assert
            Assert.IsNotNull(point.Data);
            Assert.AreEqual(carriage.GetType(), point.Data.GetType());
        }

        [TestMethod]
        public void MakeRandomItem_WithDataInitialized_ReturnsData()
        {
            // Act
            Carriage carriage = Point<Carriage>.MakeRandomItem();

            // Assert
            Assert.IsNotNull(carriage);
            Assert.IsInstanceOfType(carriage, typeof(Carriage));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MakeRandomItem_WithoutIInitInterface_ThrowsException()
        {
            // Act & Assert
            int result = Point<int>.MakeRandomItem();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MakeRandomData_WithoutIInitInterface_ThrowsException()
        {
            // Act & Assert
            Point<int> point = Point<int>.MakeRandomData();
        }

        [TestMethod]
        public void Constructor_DefaultInitialization2()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>();

            // Assert
            Assert.IsNull(myList.beg);
        }

        [TestMethod]
        public void Constructor_DefaultInitialization3()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>();

            // Assert
            Assert.IsNull(myList.end);
        }

        [TestMethod]
        public void AddToBegin_WhenListIsEmpty_AddsItemAtBegin()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage = new Carriage(new IdNumber(1), 1, 100);

            // Act
            myList.AddToBegin(carriage);

            // Assert
            Assert.AreEqual(1, myList.Count);
            Assert.IsNotNull(myList.beg);
            Assert.AreEqual(carriage, myList.beg.Data);
            Assert.AreEqual(myList.beg, myList.end);
            Assert.IsNull(myList.beg.Next);
            Assert.IsNull(myList.beg.Pred);
        }

        [TestMethod]
        public void AddToBegin_WhenListIsNotEmpty_AddsItemAtBegin()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToBegin(carriage1);

            // Act
            myList.AddToBegin(carriage2);

            // Assert
            Assert.AreEqual(2, myList.Count);
            Assert.IsNotNull(myList.beg);
            Assert.IsNotNull(myList.end);
            Assert.AreEqual(carriage2, myList.beg.Data);
            Assert.AreEqual(carriage1, myList.end.Data);
            Assert.IsNotNull(myList.beg.Next);
            Assert.AreEqual(myList.end, myList.beg.Next);
            Assert.AreEqual(myList.beg, myList.end.Pred);
            Assert.IsNull(myList.beg.Pred);
            Assert.IsNull(myList.end.Next);
        }

        [TestMethod]
        public void AddToEnd_WhenListIsEmpty_AddsItemAtEnd()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage = new Carriage(new IdNumber(1), 1, 100);

            // Act
            myList.AddToEnd(carriage);

            // Assert
            Assert.AreEqual(1, myList.Count);
            Assert.IsNotNull(myList.end);
            Assert.AreEqual(carriage, myList.end.Data);
            Assert.AreEqual(myList.beg, myList.end);
            Assert.IsNull(myList.end.Next);
            Assert.IsNull(myList.end.Pred);
        }

        [TestMethod]
        public void AddToEnd_WhenListIsNotEmpty_AddsItemAtEnd()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToEnd(carriage1);

            // Act
            myList.AddToEnd(carriage2);

            // Assert
            Assert.AreEqual(2, myList.Count);
            Assert.IsNotNull(myList.end);
            Assert.AreEqual(carriage2, myList.end.Data);
            Assert.AreEqual(carriage1, myList.beg.Data);
            Assert.IsNotNull(myList.end.Pred);
            Assert.AreEqual(myList.beg, myList.end.Pred);
            Assert.IsNull(myList.end.Next);
            Assert.IsNotNull(myList.beg.Next);
            Assert.AreEqual(myList.end, myList.beg.Next);
        }

        [TestMethod]
        public void DeepClone_WhenListIsEmpty_ReturnsEmptyList()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();

            // Act
            MyList<Carriage> clonedList = myList.DeepClone();

            // Assert
            Assert.IsNotNull(clonedList);
            Assert.AreEqual(0, clonedList.Count);
            Assert.IsNull(clonedList.beg);
            Assert.IsNull(clonedList.end);
        }

        [TestMethod]
        public void DeepClone_WhenListIsNotEmpty_ReturnsClonedList()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);

            // Act
            MyList<Carriage> clonedList = myList.DeepClone();

            // Assert
            Assert.IsNotNull(clonedList);
            Assert.AreEqual(2, clonedList.Count);
            Assert.IsNotNull(clonedList.beg);
            Assert.IsNotNull(clonedList.end);
            Assert.AreNotSame(myList.beg, clonedList.beg);
            Assert.AreNotSame(myList.end, clonedList.end);
            Assert.AreEqual(carriage1, clonedList.beg.Data);
            Assert.AreEqual(carriage2, clonedList.end.Data);
        }

        [TestMethod]
        public void Constructor_Default_CreatesEmptyList()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>();

            // Assert
            Assert.IsNotNull(myList);
            Assert.AreEqual(0, myList.Count);
            Assert.IsNull(myList.beg);
            Assert.IsNull(myList.end);
        }

        [TestMethod]
        public void Constructor_WithSize_CreatesListWithSpecifiedSize()
        {
            // Arrange
            int size = 5;

            // Act
            MyList<Carriage> myList = new MyList<Carriage>(size);

            // Assert
            Assert.IsNotNull(myList);
            Assert.AreEqual(size, myList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_WithNegativeSize_ThrowsException()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>(-1);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void Constructor_WithNonNullCollection_CreatesListWithSpecifiedElements()
        {
            // Arrange
            Carriage[] carriages = new Carriage[]
            {
                new Carriage(new IdNumber(1), 1, 100),
                new Carriage(new IdNumber(2), 2, 200),
                new Carriage(new IdNumber(3), 3, 300)
            };

            // Act
            MyList<Carriage> myList = new MyList<Carriage>(carriages);

            // Assert
            Assert.IsNotNull(myList);
            Assert.AreEqual(carriages.Length, myList.Count);
            Assert.IsNotNull(myList.beg);
            Assert.IsNotNull(myList.end);

            // Проверяем, что элементы списка созданы правильно
            Point<Carriage>? current = myList.beg;
            for (int i = 0; i < carriages.Length; i++)
            {
                Assert.IsNotNull(current);
                Assert.IsNotNull(current.Data);
                Assert.AreEqual(carriages[i], current.Data);
                current = current.Next;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_WithNullCollection_ThrowsException()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>(null);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_WithEmptyCollection_ThrowsException()
        {
            // Arrange & Act
            MyList<Carriage> myList = new MyList<Carriage>(new Carriage[0]);

            // Assert is handled by ExpectedException
        }

        [TestMethod]
        public void PrintList_WhenListIsEmpty_PrintsEmptyListMessage()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                myList.PrintList();
                string expected = "Лист пуст" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void PrintList_WhenListIsNotEmpty_PrintsElementsInList()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                myList.PrintList();
                string expected = $"{carriage1}" + Environment.NewLine + $"{carriage2}" + Environment.NewLine;
                Assert.AreEqual(expected, sw.ToString());
            }
        }

        [TestMethod]
        public void IsEmpty_WhenListIsEmpty_ReturnsTrue()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();

            // Act
            bool isEmpty = myList.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsEmpty_WhenListIsNotEmpty_ReturnsFalse()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            myList.AddToEnd(new Carriage());

            // Act
            bool isEmpty = myList.IsEmpty();

            // Assert
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        public void RemoveFirst_WhenListIsEmpty_DoesNotChangeList()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();

            // Act
            myList.RemoveFirst(0);

            // Assert
            Assert.IsTrue(myList.IsEmpty());
        }

        [TestMethod]
        public void RemoveFirst_WhenIndexIsZero_RemovesFirstElement()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);

            // Act
            myList.RemoveFirst(0);

            // Assert
            Assert.AreEqual(carriage2, myList.beg.Data);
            Assert.AreEqual(carriage2, myList.beg.Data);
            Assert.AreEqual(2, myList.Count);
        }

        [TestMethod]
        public void RemoveFirst_WhenIndexIsLast_RemovesLastElement()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);

            // Act
            myList.RemoveFirst(1);

            // Assert
            Assert.AreEqual(carriage1, myList.beg.Data);
            Assert.AreEqual(null, myList.beg.Next);
            Assert.AreEqual(2, myList.Count);
        }

        [TestMethod]
        public void RemoveFirst_WhenIndexIsMiddle_RemovesMiddleElement()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            Carriage carriage3 = new Carriage(new IdNumber(3), 3, 300);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);
            myList.AddToEnd(carriage3);

            // Act
            myList.RemoveFirst(1);

            // Assert
            Assert.AreEqual(carriage1, myList.beg.Data);
            Assert.AreEqual(carriage3, myList.beg.Next.Data);
            Assert.AreEqual(3, myList.Count);
        }

        [TestMethod]
        public void AddToOddPositions_WhenListIsEmpty_AddsElementAsFirstNode()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage = new Carriage(new IdNumber(1), 1, 100);

            // Act
            myList.AddToOddPositions(carriage);

            // Assert
            Assert.AreEqual(1, myList.Count);
            Assert.IsNotNull(myList.beg);
            Assert.IsNotNull(myList.end);
            Assert.AreEqual(carriage, myList.beg.Data);
            Assert.AreEqual(carriage, myList.end.Data);
            Assert.IsNull(myList.beg.Pred);
            Assert.IsNull(myList.end.Next);
        }

        [TestMethod]
        public void AddToOddPositions_WhenListHasMultipleElements_AddsElementToOddPositions()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            Carriage carriage3 = new Carriage(new IdNumber(3), 3, 300);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);
            myList.AddToEnd(carriage3);

            Carriage newCarriage = new Carriage(new IdNumber(4), 4, 400);

            // Act
            myList.AddToOddPositions(newCarriage);

            // Assert
            Assert.AreEqual(7, myList.Count);
        }

        [TestMethod]
        public void Clear_WhenListIsNotEmpty_ClearsTheList()
        {
            // Arrange
            MyList<Carriage> myList = new MyList<Carriage>();
            Carriage carriage1 = new Carriage(new IdNumber(1), 1, 100);
            Carriage carriage2 = new Carriage(new IdNumber(2), 2, 200);
            Carriage carriage3 = new Carriage(new IdNumber(3), 3, 300);
            myList.AddToEnd(carriage1);
            myList.AddToEnd(carriage2);
            myList.AddToEnd(carriage3);

            // Act
            myList.Clear();

            // Assert
            Assert.IsTrue(myList.IsEmpty());
            Assert.IsNull(myList.beg);
            Assert.IsNull(myList.end);
            Assert.AreEqual(0, myList.Count);
        }
    }
}