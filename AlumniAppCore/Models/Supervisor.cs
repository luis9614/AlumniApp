﻿using System;
namespace AlumniAppCore.Models
{
	public class Supervisor : User
    {
        public Supervisor(string Name, string LastName, string SecondLastName, string FullName, string Address, string EMail, string Password, string UserName, int IdUser)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.SecondLastName = SecondLastName;
            this.FullName = FullName;
            this.Address = Address;
            this.EMail = EMail;
            this.Password = Password;
            this.UserName = UserName;
            this.IdUser = IdUser;
            this.IdAccountType = 3;
            SetPermissions();
        }

        public override void SetPermissions()
        {
            this.Permissions[(int)FeatureEnumeration.OWN_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.OWN_PROFILE] = true;
            //this.Permissions[(int)FeatureEnumeration.BASIC_INFO] = true;
            this.Permissions[(int)FeatureEnumeration.ALL_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.DOWNLOAD_CALS] = false;
        }

        public override string ToString()
        {
            return "Supervisor\n" + base.ToString();
        }
    }
}
