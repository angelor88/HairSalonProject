using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=angelo_russoniello_test;";
    }


    [TestMethod]
    public void GetAll_StylistDbStartsEmpty_0()
    {
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void GetName_ReturnsStylistName_String()
{
    string testName = "John Smith";
    Stylist testStylist = new Stylist(testName);

    string result = testStylist.GetName();

    Assert.AreEqual(testName, result);
}

[TestMethod]
public void Save_StylistSavesToDatabase_Stylist()
{

    Stylist testStylist = new Stylist("John Smith");
    testStylist.Save();

    List<Stylist> result = Stylist.GetAll();
    List<Stylist> testList = new List<Stylist>{testStylist};

    CollectionAssert.AreEqual(result, testList);
 }

 [TestMethod]
 public void Find_FindsStylistInDatabase_Stylist()
 {
     Stylist testStylist = new Stylist("John Smith");
     testStylist.Save();

     Stylist foundStylist = Stylist.Find(testStylist.GetId());

     Assert.AreEqual(testStylist, foundStylist);
 }
    //
    // [TestMethod]
    // public void Equals_ReturnsTrueIfStylistsAreTheSame_Stylist()
    // {
    //   Stylist firstStylist = new Stylist ("Victoria", 1);
    //   Stylist secondStylist = new Stylist ("Silver", 1);
    //   Assert.AreEqual(firstStylist, secondStylist);
    // }
  }

}
