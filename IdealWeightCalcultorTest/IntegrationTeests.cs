using FluentAssertions;
using IdealWeightCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalcultorTest;

[TestClass]
public class IntegrationTeests
{
    [TestMethod]
    public void AddUser_WithGoodUser_Should_Save()
    {
        User user = new User()
        {
            Name="Ahmed",
            BirthDate=new DateTime(1089, 07, 12),
            Email = "ahmed@live.fr"
        };

        DataAccessLayer dataAccessLayer = new DataAccessLayer(new WeightContext());
        dataAccessLayer.AddUser(user);
        User userToFind = dataAccessLayer.GetUser("Ahmed");
        userToFind.Should().BeEquivalentTo(user);
    }
}
