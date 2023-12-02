using System.Collections.Generic;
using NUnit.Framework;
// tests user class
public class UserTest {
    
    // tests user constructor
    [Test]
    public void constructorTest() {
        User u1 = new User("oscar", "password");
        Assert.True(u1.getUsername().Equals("oscar"));
        Assert.True(u1.getPassword().Equals("password"));
    }
} 
