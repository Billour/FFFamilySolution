using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FFF.Silverlight.Entity.Model
{
    public class User
    {
        public User DeepCopy()
        {
            return new User
            {
                Id = this.Id,
                Username = this.Username,
                IsAdmin = this.IsAdmin
            };
        }

        private Guid id = Guid.NewGuid();
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Username { get; set; }

        public bool IsAdmin { get; set; }
    }
}
