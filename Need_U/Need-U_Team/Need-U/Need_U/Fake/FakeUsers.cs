using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_U
{
    class FakeUsers
    {
        public User Seb { get; set; }
        public User Anna { get; set; }
        public User Andres { get; set; }
        public User Oriana { get; set; }

        public FakeUsers()
        {
            FakeUserSeb();
            FakeUserOriana();
            FakeUserAnna();
            FakeUserAndres();

        }

        private void FakeUserSeb()
        {
            Seb = new User();
            Seb.UserFirstName = "Sébastien";
            Seb.UserName = "Lasarte";
            Seb.UserNickname = "Seb";

        }

        private void FakeUserAnna()
        {
            Anna = new User();
            Anna.UserFirstName = "Anna-Maria";
            Anna.UserName = "La Colombiana";
            Anna.UserNickname = "Ana";

        }

        private void FakeUserAndres()
        {
            Andres = new User();
            Andres.UserFirstName = "Andres";
            Andres.UserName = "Felipe";
            Andres.UserNickname = "Andresito";

        }

        private void FakeUserOriana()
        {
            Oriana = new User();
            Oriana.UserFirstName = "Oriana";
            Oriana.UserName = "";
            Oriana.UserNickname = "";

        }


    }
}
