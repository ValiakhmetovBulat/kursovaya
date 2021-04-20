using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WindowsFormsApplication1
{
public  class User
    {
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public User()
    { }
    public User(string Login, string Password, string Email, string Role)
    {
    this.Login = Login;
    this.Password = Password;
    this.Role = Role;
    this.Email = Email;
    }

    }
}


