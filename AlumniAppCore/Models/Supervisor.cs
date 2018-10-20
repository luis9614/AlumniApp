using System;
namespace AlumniAppCore.Models
{
	public class Supervisor : User
    {
        public Supervisor()
        {
        }

        public override void SetPermissions()
        {
            this.Permissions[(int)FeatureEnumeration.OWN_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.OWN_PROFILE] = true;
            this.Permissions[(int)FeatureEnumeration.BASIC_INFO] = true;
            this.Permissions[(int)FeatureEnumeration.ALL_CALS] = false;
            this.Permissions[(int)FeatureEnumeration.DOWNLOAD_CALS] = false;
        }
    }
}
