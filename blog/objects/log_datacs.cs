using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.objects
    {
    public class log_datacs
{

        string fullName, user, email;
        Boolean gander,Empty = true;
        DateTime brday;
        int typeUser = 0,id;
        public bool isEmpty()
        {
            if (String.IsNullOrEmpty(FullName))
                Empty = true;
            else if (String.IsNullOrEmpty(user))
                Empty = true;
            else if (String.IsNullOrEmpty(email))
                Empty = true;
            else if (brday == new DateTime() || brday == null)
                Empty = true;
            else if(typeUser == 0)
                Empty = true;
            else Empty = false;
            return Empty;
        }
        public Boolean isAdmin()
        {
            return TypeUser == 1970;
        }
        public string FullName { get { return fullName; } set { fullName = value; } }
        public string User { get { return user; } set { user = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Boolean Gander { get { return gander; } set { gander = value; } }
        public DateTime Bday { get { return brday; } set { brday = value; } }
        public int TypeUser { get { return typeUser; } set { typeUser = value; } }
        public int Id { get { return id; } set { id = value; } }
}
}
