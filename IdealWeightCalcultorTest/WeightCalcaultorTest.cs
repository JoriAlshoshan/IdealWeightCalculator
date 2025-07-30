using FakeItEasy;
using FluentAssertions;
using Moq;


namespace IdealWeightCalculator.Test;

[TestClass]
public class WeightCalcaultorTest
{
    public TestContext TestContext { get; set; }

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        context.WriteLine("In class initializer");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {

    }

    [TestInitialize]
    public void TestInitialize()
    {
        TestContext.WriteLine("in test Initilaize");
    }

    [TestCleanup]
    public void TestCleanup()
    {

    }

    // Given_When_Then
    [TestMethod]
    [Description("This test is about checking if the ideal body weight " +
        "of a man with 180 CM in height is equals to 72.5")]
    [Owner("JoriAlshoshan")]
    [Priority(1)]
    [TestCategory("WeightCategory")]
    public void GetIdealBodyWeight_WithSex_M_And_Height_180_Return_72_5()
    {
        // 3 AAA

        // Arrange 
        WeightCalculator sut = new WeightCalculator
        {
            Sex = 'm',
            Height = 180
        };

        // Act 
        double actual = sut.GetIdealBodyWeight();
        double expected = 72.5;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("This test is about checking if the ideal body weight " +
        "of a women with 180 CM in height is equals to 65")]
    [Owner("JoriAlshoshan")]
    [Priority(1)]
    [TestCategory("WeightCategory")]
    public void GetIdealBodyWeight_WithSex_W_And_Height_180_Return_65()
    {
        // 3 AAA

        // Arrange 
        WeightCalculator sut = new WeightCalculator
        {
            Sex = 'w',
            Height = 180
        };

        // Act 
        double actual = sut.GetIdealBodyWeight();
        double expected = 65;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    [Description("This test is about checking if the sex argument " +
        " isn't valid by throwing an exception")]
    [Owner("JoriAlshoshan")]
    [Priority(1)]
    [TestCategory("WeightCategory")]
    public void GetIdealBodyWeight_WithBadSex_And_Height_180_Throw_Exception()
    {
        // 3 AAA

        // Arrange 
        WeightCalculator sut = new WeightCalculator
        {
            Sex = 'r',
            Height = 180
        };

        // Act 
        double actual = sut.GetIdealBodyWeight();
        double expected = 0;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [Description("This test is about using some Assert methods")]
    [Owner("JoriAlshoshan")]
    [Priority(2)]
    [TestCategory("AssertCategory")]
    public void Assert_Tests()
    {
        //Assert.AreNotEqual(100, 90);
        //WeightCalculator cal1 = new WeightCalculator();
        //WeightCalculator cal2  = new WeightCalculator();

        //Assert.AreNotSame(cal1,cal2);

        //WeightCalculator calculator = new WeightCalculator();

        //Assert.IsInstanceOfType(calculator, typeof(WeightCalculator));


        //Assert.IsNotNull(calculator);

        Assert.IsFalse(100 == 90 + 10);

    }

    [TestMethod]
    [Description("This test is about using some StringAssert methods")]
    [Owner("JoriAlshoshan")]
    [Priority(2)]
    [TestCategory("AssertCategory")]
    public void StringAssert_Test()
    {
        string name = "Khalid";

        StringAssert.Contains(name, "lid");
        name.Should().Contain(name, "lid");
        StringAssert.EndsWith(name, "id");
        StringAssert.StartsWith(name, "Kh");

    }

    [TestMethod]
    [Description("This test is about using CollectionAssert methods")]
    [Owner("JoriAlshoshan")]
    [Priority(2)]
    [TestCategory("AssertCategory")]
    [Ignore]
    public void CollectionAssert_Tests()
    {
        List<string> names = new List<string>() { "Hmaid", "Said", "Khalid", "Kamal" };
        CollectionAssert.AllItemsAreNotNull(names);
        CollectionAssert.Contains(names, "Said");
        CollectionAssert.AllItemsAreInstancesOfType(names, typeof(string));
    }

    [TestMethod]
    [Description("This test is about using FluentAssertions methods")]
    [Owner("JoriAlshoshan")]
    [Priority(3)]
    [TestCategory("AssertCategory")]
    [Timeout(3000)]
    public void FluentAssertions_Tests()
    {
        string name = "Hamid";
        name.Should().StartWith("H").And.EndWith("id");

        int num = 10;
        num.Should().BeGreaterThan(5);
        num.Should().BeLessThanOrEqualTo(10);

        List<string> names = new List<string>() { "Ahmed", "Khalid" };

        names.Should().HaveCount(2);
        names.Should().NotBeEmpty();
    }

    [TestMethod]
    public void GetIdealBodyWeightFromSource_WithGoodInputs_Return_Correct_Results()
    {
        WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository());

        List<double> actual = weightCalculator.GetIdealBodyWeightFromDataSource();
        double[] expected = { 62.5, 62.75, 74 };

        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]

    public void GetIdealBodyWeightFromDataSource_Using_Moq()
    {
        List<WeightCalculator> weights = new List<WeightCalculator>()
        {
            new WeightCalculator { Height = 175, Sex = 'w' }, // 62.5
            new WeightCalculator { Height = 167, Sex = 'm' }, // 62.75
        };

        Mock<IDataRepository> repo = new Mock<IDataRepository>();

        repo.Setup(w => w.GetWeights()).Returns(weights);

        WeightCalculator calcalutor = new WeightCalculator(repo.Object);

        var actual = calcalutor.GetIdealBodyWeightFromDataSource();

        double[] expected = { 62.5, 62.75 };

        actual.Should().Equal(expected);
    }

    [TestMethod]
    public void GetIdealBodyWeightFromDataSource_Using_FakeItEasy()
    {
        List<WeightCalculator> weights = new List<WeightCalculator>()
        {
            new WeightCalculator { Height = 175, Sex = 'w' }, // 62.5
            new WeightCalculator { Height = 167, Sex = 'm' }, // 62.75
        };

        IDataRepository repo = A.Fake<IDataRepository>();

        //repo.Setup(w => w.GetWeights()).Returns(weights);

        A.CallTo(() => repo.GetWeights()).Returns(weights);

        WeightCalculator calcalutor = new WeightCalculator(repo);

        var actual = calcalutor.GetIdealBodyWeightFromDataSource();

        double[] expected = { 62.5, 62.75 };

        actual.Should().Equal(expected);
    }

    [DataTestMethod]
    [DataRow(175, 'w', 62.5)]
    [DataRow(167, 'm', 62.75)]
    [DataRow(182, 'm', 74)]
    public void WorkingWith_Data_Driven_Tests(double height, char sex, double expected)
    {
        WeightCalculator weightCalculator = new WeightCalculator
        {
            Height = height,
            Sex = sex
        };

        var actual = weightCalculator.GetIdealBodyWeight();

        actual.Should().Be(expected);
    }

    public static List<object[]> TestCases()
    {
        return new List<object[]>
        {
            new object[]{175, 'w', 62.5},
            new object[]{167, 'm', 62.75},
            new object[]{182, 'm', 74},
        };

    }

    [DataTestMethod]
    [DynamicData(nameof(TestCases), DynamicDataSourceType.Method)]
    public void MyTestMethod(double height, char sex, double expected)
    {
        WeightCalculator weightCalculator = new WeightCalculator
        {
            Height = height,
            Sex = sex
        };

        var actual = weightCalculator.GetIdealBodyWeight();
        actual.Should().Be(expected);
    }

    // TDD 
    [TestMethod]
    public void Validate_With_BadSex_Returns_False()
    {
        WeightCalculator weightCalculator = new WeightCalculator();
        weightCalculator.Sex = 't';

        bool actual = weightCalculator.Validate();

        actual.Should().BeFalse();
    }
}
